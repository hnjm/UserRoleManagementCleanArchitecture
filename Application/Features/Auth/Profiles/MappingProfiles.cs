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
            CreateMap<RegisterCommandRequest, User>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email)); 
                /*.ForMember(dest => dest.PasswordHash, opt => opt.Ignore()); */ // PasswordHash burada doldurulmamalı, UserManager kullanılmalı.             
        }
    }
}
