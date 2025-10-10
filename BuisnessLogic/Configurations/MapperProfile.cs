using AutoMapper;
using BuisnessLogic.DTOs;
using BuisnessLogic.DTOs.Accounts;
using DataAccess.Data.Entities;

namespace BuisnessLogic.Configurations
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<GenreDto, Genre>().ReverseMap();
            CreateMap<CreateMovieDto, Movie>();
            CreateMap<EditMovieDto, Movie>();
            CreateMap<MovieDto, Movie>().ReverseMap();

            CreateMap<RegisterModel, User>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(model => model.Email))
                .ForMember(x => x.PasswordHash, opt => opt.Ignore());
        }
    }
}
