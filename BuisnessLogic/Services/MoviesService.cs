using AutoMapper;
using BuisnessLogic.DTOs;
using BuisnessLogic.Helpers;
using BuisnessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using DataAccess.Repositories;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BuisnessLogic.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IRepository<Movie> repo;
        private readonly IMapper mapper;

        public MoviesService(IRepository<Movie> repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task<MovieDto> Create(CreateMovieDto model)
        {
            var entity = mapper.Map<Movie>(model);
            //await ctx.Movies.AddAsync(entity);
            //await ctx.SaveChangesAsync();

            await repo.AddAsync(entity);
            return mapper.Map<MovieDto>(entity);
        }

        public async Task Delete(int id)
        {
            var item = await repo.GetByIdAsync(id);
            if (item == null)
                throw new Exception($"Movie with id {id} not found.");

            await repo.DeleteAsync(id);
        }

        public async Task Edit(EditMovieDto model)
        {
            await repo.UpdateAsync(mapper.Map<Movie>(model));
        }

        public async Task<MovieDto> Get(int id)
        {
            if (id < 0)
                return null;
            var item = await repo.GetByIdAsync(id);

            if (item == null)
                return null;

            return mapper.Map<MovieDto>(item);
        }
            
        public async Task<IList<MovieDto>> GetAll(int? filterGenreId, string? searchTitle, int? searchYear, int? rating, bool sortByAsc, int pageNumber = 1)
        {
            //IQueryable<Movie> query = ctx.Movies.Include(x => x.Genre);

            //if (filterGenreId != null)
            //    query = query.Where(x => x.GenreId == filterGenreId);

            //if (!string.IsNullOrWhiteSpace(searchTitle))
            //    query = query.Where(x => x.Title.ToLower().Contains(searchTitle.ToLower()));

            //if (searchYear != null)
            //    query = query.Where(x => x.Year == searchYear);

            //if (rating != null)
            //    query = query.Where(x => x.Rating == rating);

            //query = sortByAsc ? query.OrderBy(x => x.Rating) : query.OrderByDescending(x => x.Rating);
            var filterEx = PredicateBuilder.New<Movie>(true);

            if (filterGenreId != null)
                filterEx = filterEx.And(x => x.GenreId == filterGenreId);
            if (!string.IsNullOrWhiteSpace(searchTitle))
                filterEx = filterEx.And(x => x.Title.ToLower().Contains(searchTitle.ToLower()));
            var items = await repo.GetAllAsync(pageNumber: pageNumber, filtering: filterEx, includes: nameof(Movie.Genre));
            return mapper.Map<IList<MovieDto>>(items);
        }
    }
}
