using Application.Features.Users.Commands.Create;
using Application.Features.Users.Dtos;
using Application.Features.Users.Queries.GetList;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateUserCommandRequest, User>().ReverseMap();
            CreateMap<User, CreateUserCommandResponse>().ReverseMap();

            //CreateMap<User, GetListQueryResponse<GetListUserDto>>().ReverseMap();

            // Alttaki 2 mapi gözden geçir ikisinede ihtiyaç var mı test et!
            // User nesnesinden GetListUserDto nesnesine dönüşüm
            CreateMap<User, GetListUserDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));

            // IList<User> nesnesini GetListQueryResponse nesnesine dönüştürmek
            CreateMap<IList<User>, GetListQueryResponse>()
            .ConvertUsing((src, dest, context) =>
                new GetListQueryResponse
                {
                    Users = context.Mapper.Map<List<GetListUserDto>>(src)
                });
        }
    }
}
