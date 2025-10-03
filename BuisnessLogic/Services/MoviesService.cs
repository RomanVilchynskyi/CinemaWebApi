using AutoMapper;
using BuisnessLogic.DTOs;
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

        public MovieDto Create(CreateMovieDto model)
        {
            var entity = mapper.Map<Movie>(model);
            ctx.Movies.Add(entity);
            ctx.SaveChanges(); // generate id (execute INSERT SQL command)

            return mapper.Map<MovieDto>(entity);
        }

        public void Delete(int id)
        {
            if (id < 0) 
                throw new HttpException("Id can not be negative.", HttpStatusCode.BadRequest);

            var item = ctx.Movies.Find(id);

            if (item == null)
                throw new HttpException($"Product with id:{id} not found.", HttpStatusCode.NotFound);

            ctx.Movies.Remove(item);
            ctx.SaveChanges();
        }

        public void Edit(EditMovieDto model)
        {
            ctx.Movies.Update(mapper.Map<Movie>(model));
            ctx.SaveChanges();

        }

        public MovieDto? Get(int id)
        {
            if (id < 0) 
                throw new HttpException("Id can not be negative.", HttpStatusCode.BadRequest);

            var item = ctx.Movies.Find(id);

            if (item == null)
                throw new HttpException($"Product with id:{id} not found.", HttpStatusCode.NotFound);

            return mapper.Map<MovieDto>(item);
        }

        public IList<MovieDto> GetAll(int? filterGenreId, string? searchTitle, int? searchYear, int? rating, bool sortByAsc)
        {
            IQueryable<Movie> query = ctx.Movies
                           .Include(x => x.Genre);

            if(filterGenreId != null)
                query = query.Where(x => x.GenreId == filterGenreId);

            if (searchTitle != null)
                query = query.Where(x => x.Title.ToLower().Contains(searchTitle.ToLower()));

            if (searchYear != null)
                query = query.Where(x => x.Year == searchYear);

            if (rating != null)
                query = query.Where(x => x.Rating == rating);

            if(sortByAsc)
                query = query.OrderBy(x => x.Rating);
            else
                query = query.OrderByDescending(x => x.Rating);

            var items = query.ToList();
            return mapper.Map<IList<MovieDto>>(items);
        }
    }
}
