using FluentValidation;

namespace Application.Features.Auth.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().MinimumLength(8).EmailAddress();          

            RuleFor(x => x.Password).NotEmpty().MinimumLength(4);

            RuleFor(x => x.ConfirmPassword).NotEmpty().MinimumLength(4).Equal(x => x.Password);
        }
    }
}
