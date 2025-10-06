using AutoMapper;
using BuisnessLogic.DTOs;
using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
