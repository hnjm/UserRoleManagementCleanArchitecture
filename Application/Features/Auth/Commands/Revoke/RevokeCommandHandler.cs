using Application.Features.Auth.Rules;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Auth.Commands.Revoke
{
    public class RevokeCommandHandler : IRequestHandler<RevokeCommandRequest, Unit>
    {
        private readonly UserManager<User> _userManager;
        private readonly AuthBusinessRules _authBusinessRules;

        public RevokeCommandHandler(UserManager<User> userManager, AuthBusinessRules authBusinessRules)
        {
            _userManager = userManager;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
        {
            User? user =await _userManager.FindByEmailAsync(request.Email);
            await _authBusinessRules.EmailAddressShouldBeValid(user);

            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);

            return Unit.Value;
        }
    }
}
