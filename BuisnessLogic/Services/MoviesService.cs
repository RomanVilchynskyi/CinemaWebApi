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

        public IList<MovieDto> GetAll()
        {
            var items = ctx.Movies
                           .Include(x => x.Genre)
                           .ToList();

            return mapper.Map<IList<MovieDto>>(items);
        }
    }
}
