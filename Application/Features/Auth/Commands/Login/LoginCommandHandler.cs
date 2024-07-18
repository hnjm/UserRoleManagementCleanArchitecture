using Application.Abstracts.Tokens;
using Application.Features.Auth.Rules;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        public LoginCommandHandler(UserManager<User> userManager, AuthBusinessRules authBusinessRules, ITokenService tokenService, IConfiguration configuration)
        {
            _userManager = userManager;
            _authBusinessRules = authBusinessRules;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await _userManager.FindByEmailAsync(request.Email);
            bool checkPassword = await _userManager.CheckPasswordAsync(user, request.Password);

            await _authBusinessRules.EmailOrPasswordShouldNotBeInvalid(user, checkPassword);

            IList<string> roles = await _userManager.GetRolesAsync(user);

            JwtSecurityToken token = await _tokenService.CreateToken(user, roles); ;
            string refreshToken = _tokenService.GenerateRefreshToken();

            _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

            await _userManager.UpdateAsync(user);
            await _userManager.UpdateSecurityStampAsync(user);

            string _token = new JwtSecurityTokenHandler().WriteToken(token);

            await _userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);

            return new LoginCommandResponse
            {
                Token = _token,
                RefreshToken = refreshToken,
                Expiration = token.ValidTo
            };
        }
    }
}
