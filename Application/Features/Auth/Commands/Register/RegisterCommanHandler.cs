using Application.Exceptions.Types;
using Application.Features.Auth.Rules;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterCommanHandler : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IMapper _mapper;

        public RegisterCommanHandler(UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper, AuthBusinessRules authBusinessRules)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<RegisterCommandResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserEmailShouldBeNotExists(request.Email);

            User user = _mapper.Map<User>(request);

            IdentityResult createdUser = await _userManager.CreateAsync(user, request.Password);

            // Role var mı ? BusinessRules eklenmeli mi ?
            if (!await _roleManager.RoleExistsAsync("user"))
            {
                await _roleManager.CreateAsync(new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "user",
                    NormalizedName = "USER",
                    Description = "Bu bir user rolüdür.",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
                await _userManager.AddToRoleAsync(user, "user");
            }

            RegisterCommandResponse response = _mapper.Map<RegisterCommandResponse>(user);
            response.Message = "İşlem Başarılı.";
            return response;          
        }
    }
}
