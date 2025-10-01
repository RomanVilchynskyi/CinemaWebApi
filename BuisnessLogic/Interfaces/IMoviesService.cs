using BuisnessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Interfaces
{
    public interface IMoviesService
    {
        IList<MovieDto> GetAll();
        MovieDto? Get(int id);
        MovieDto Create(CreateMovieDto model);
        void Edit(EditMovieDto model);
        void Delete(int id);
    }
}
