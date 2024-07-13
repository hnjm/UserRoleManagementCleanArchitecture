using MediatR;


namespace Application.Features.Auth.Commands.Register
{
    public class RegisterCommandRequest : IRequest<Unit>
    {
        // UserForRegisterDto oluşturup burada çağrılabilir.
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
