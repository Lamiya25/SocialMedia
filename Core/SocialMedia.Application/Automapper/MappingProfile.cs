using AutoMapper;
using SocialMedia.Application.DTOs.User;
using SocialMedia.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<UserListDto, User>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                   .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                   .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                   .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                   .ForMember(dest => dest.About, opt => opt.MapFrom(src => src.About))
                   .ForMember(dest => dest.IsPrivate, opt => opt.MapFrom(src => src.IsPrivate))
                   .ForPath(dest => dest.ProfileImage.Path, opt => opt.MapFrom(src => src.ProfileImage))
                   .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                   .ReverseMap();
        }
    }
}