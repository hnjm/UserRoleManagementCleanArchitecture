using Application.Exceptions.Types;
using Application.Features.Auth.Constants;
using Application.Rules;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Auth.Rules
{
    public class AuthBusinessRules : BaseBusinessRules
    {
        private readonly UserManager<User> _userManager;

        public AuthBusinessRules(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task UserEmailShouldBeNotExists(string email)
        {
            var userEmail = await _userManager.FindByEmailAsync(email);
            if (userEmail != null)           
                throw new BusinessException(AuthMessages.UserMailAlreadyExists);           
        }
    }
}
