using Application.Features.Users.Dtos;

namespace Application.Features.Users.Queries.GetList
{
    public class GetListQueryResponse
    {
       public IList<GetListUserDto> Users { get; set; }
    }
}
