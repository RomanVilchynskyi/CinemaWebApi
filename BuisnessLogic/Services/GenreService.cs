using AutoMapper;
using BuisnessLogic.DTOs;
using BuisnessLogic.Helpers;
using BuisnessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Services
{

    public class GenreService : IGenreService
    {
        private readonly CinemaDbContext ctx;
        private readonly IMapper mapper;

        public GenreService(CinemaDbContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }
        public async Task<GenreDto> Create(GenreDto model)
        {
            var entity = mapper.Map<Genre>(model);

            ctx.Genre.Add(entity);
            await ctx.SaveChangesAsync();

            return mapper.Map<GenreDto>(entity);
        }

        public async Task Delete(int id)
        {
            var item = await GetEntityById(id);

            ctx.Genre.Remove(item);
            await ctx.SaveChangesAsync(true);
        }

        public async Task Edit(GenreDto model)
        {
            ctx.Genre.Update(mapper.Map<Genre>(model));
            await ctx.SaveChangesAsync();
        }

        public async Task<IList<GenreDto>> Get(int pageNumber = 1)
        {
            var items = await PagedList<Genre>.CreateAsync(ctx.Genre, pageNumber, 5);

            return mapper.Map<IList<GenreDto>>(items);
        }

        public async Task<GenreDto> GetById(int id)
        {
            var item = await GetEntityById(id);

            return mapper.Map<GenreDto>(item);
        }

        private async Task<Genre> GetEntityById(int id)
        {
            if (id < 0)
                throw new HttpException("Id can not be negative.", HttpStatusCode.BadRequest); // 400

            var item = await ctx.Genre.FindAsync(id);

            if (item == null)
                throw new HttpException($"Category with id:{id} not found.", HttpStatusCode.NotFound); // 404

            return item;
        }
    }
}
