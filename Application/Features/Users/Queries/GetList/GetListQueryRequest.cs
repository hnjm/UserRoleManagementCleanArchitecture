using Application.Features.Users.Dtos;
using MediatR;

namespace Application.Features.Users.Queries.GetList
{
    public class GetListQueryRequest :IRequest<GetListQueryResponse>
    {
        // Sayfalama bilgisi var ise eklenebilir.
    }
}
