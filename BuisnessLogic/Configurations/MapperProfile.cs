using AutoMapper;
using BuisnessLogic.DTOs;
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
        }
    }
}
