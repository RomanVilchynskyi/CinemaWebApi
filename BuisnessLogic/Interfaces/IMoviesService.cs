using BuisnessLogic.DTOs;

namespace BuisnessLogic.Interfaces
{
    public interface IMoviesService
    {
        Task<IList<MovieDto>> GetAll(int? filterGenreId, string? searchTitle, int? searchYear, int? rating, bool sortByAsc, int pageNumber);
        Task <MovieDto?> Get(int id);
        Task <MovieDto> Create(CreateMovieDto model);
        Task Edit(EditMovieDto model);
        Task Delete(int id);
    }
}
