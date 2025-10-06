using AutoMapper;
using BuisnessLogic.DTOs;
using BuisnessLogic.Helpers;
using BuisnessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BuisnessLogic.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly CinemaDbContext ctx;
        private readonly IMapper mapper;

        public MoviesService(CinemaDbContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        public async Task<MovieDto> Create(CreateMovieDto model)
        {
            var entity = mapper.Map<Movie>(model);
            await ctx.Movies.AddAsync(entity);
            await ctx.SaveChangesAsync();

            return mapper.Map<MovieDto>(entity);
        }

        public async Task Delete(int id)
        {
            var item = await ctx.Movies.FindAsync(id);
            if (item == null)
                throw new Exception($"Movie with id {id} not found.");

            ctx.Movies.Remove(item);
            await ctx.SaveChangesAsync();
        }

        public async Task Edit(EditMovieDto model)
        {
            var entity = await ctx.Movies.FindAsync(model.Id);
            if (entity == null)
                throw new Exception($"Movie with id {model.Id} not found.");

            mapper.Map(model, entity);
            await ctx.SaveChangesAsync();
        }

        public async Task<MovieDto> GetById(int id)
        {
            var item = await ctx.Movies
                .Include(x => x.Genre)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
                throw new Exception($"Movie with id {id} not found.");

            return mapper.Map<MovieDto>(item);
        }

        public async Task<IList<MovieDto>> Get(int? filterGenreId, string? searchTitle, int? searchYear, int? rating, bool sortByAsc, int pageNumber = 1)
        {
            IQueryable<Movie> query = ctx.Movies.Include(x => x.Genre);

            if (filterGenreId != null)
                query = query.Where(x => x.GenreId == filterGenreId);

            if (!string.IsNullOrWhiteSpace(searchTitle))
                query = query.Where(x => x.Title.ToLower().Contains(searchTitle.ToLower()));

            if (searchYear != null)
                query = query.Where(x => x.Year == searchYear);

            if (rating != null)
                query = query.Where(x => x.Rating == rating);

            query = sortByAsc ? query.OrderBy(x => x.Rating) : query.OrderByDescending(x => x.Rating);

            var items = await PagedList<Movie>.CreateAsync(ctx.Movies, pageNumber, 10);
            return mapper.Map<IList<MovieDto>>(items);
        }
    }
}
