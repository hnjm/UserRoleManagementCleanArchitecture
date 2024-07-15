using Application.Exceptions.Types;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterCommanHandler : IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        public RegisterCommanHandler(UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
            {
                throw new BusinessException("Kullanıcı zaten mevcut.");
            }
            

            User user = _mapper.Map<User>(request);
            user.UserName = request.Email;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                // Role var mı ? BusinesRules eklenmeli mi ?
                if(!await _roleManager.RoleExistsAsync("user"))
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
            }

            return Unit.Value;
        }
    }
}
