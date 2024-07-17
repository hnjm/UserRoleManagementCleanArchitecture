using Application.Features.Auth.Commands.Register;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Auth.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // RegisterCommandRequest'den User'a eşleme
            CreateMap<RegisterCommandRequest, User>().ReverseMap();
            CreateMap<RegisterCommandResponse, User>().ReverseMap();           
        }
    }
}
