using MediatR;

namespace Application.Features.Auth.Commands.Revoke
{
    public class RevokeCommandRequest : IRequest<Unit>
    {
        public string Email { get; set; }
    }
}
