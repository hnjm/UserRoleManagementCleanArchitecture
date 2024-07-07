
using MediatR;

namespace Application.Features.Users.Commands.Create
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
