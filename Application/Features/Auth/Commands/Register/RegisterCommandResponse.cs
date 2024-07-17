
namespace Application.Features.Auth.Commands.Register
{
    public class RegisterCommandResponse
    {
        public string Message { get; set; } = "İşlem Başarılı.";
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
