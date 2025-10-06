using BuisnessLogic.DTOs;

namespace BuisnessLogic.Interfaces
{
    public interface IGenreService
    {
        Task <IList<GenreDto>> Get(int pageNumber);
        Task<GenreDto> GetById(int id);
        Task<GenreDto> Create(GenreDto model);
        Task Edit(GenreDto model);
        Task Delete(int id);
    }
}
