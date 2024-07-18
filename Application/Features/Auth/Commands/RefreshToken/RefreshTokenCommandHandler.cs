using Application.Abstracts.Tokens;
using Application.Features.Auth.Rules;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly AuthBusinessRules _authBusinessRules;

        public RefreshTokenCommandHandler(UserManager<User> userManager, ITokenService tokenService, AuthBusinessRules authBusinessRules)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            ClaimsPrincipal? principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            string email = principal.FindFirstValue(ClaimTypes.Email);

            User? user = await _userManager.FindByEmailAsync(email);
            IList<string> roles = await _userManager.GetRolesAsync(user);

            await _authBusinessRules.RefreshTokenShouldNotBeExpired(user.RefreshTokenExpiryTime);

            JwtSecurityToken newAccesToken = await _tokenService.CreateToken(user, roles);
            string newRefreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            return new()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccesToken),
                RefreshToken = newRefreshToken
            };
        }
    }
}
