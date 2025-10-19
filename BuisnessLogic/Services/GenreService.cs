using AutoMapper;
using BuisnessLogic.DTOs;
using BuisnessLogic.Helpers;
using BuisnessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using DataAccess.Repositories;
using System.Net;

namespace BuisnessLogic.Services
{

    public class GenreService : IGenreService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Genre> repo;

        public GenreService(IMapper mapper, IRepository<Genre> repo)
        {
            this.mapper = mapper;
            this.repo = repo;
        }
        public async Task<GenreDto> Create(GenreDto model)
        {
            var entity = mapper.Map<Genre>(model);            
            await repo.AddAsync(entity);

            return mapper.Map<GenreDto>(entity);
        }

        public async Task Delete(int id)
        {
            var item = await GetEntityById(id);
            await repo.DeleteAsync(id);
        }

        public async Task Edit(GenreDto model)
        {
            var entity = mapper.Map<Genre>(model);
            await repo.UpdateAsync(entity);
        }

        public async Task<IList<GenreDto>> Get(int pageNumber = 1)
        {
            var items = await repo.GetAllAsync(pageNumber, 5);

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

            var item = await repo.GetByIdAsync(id);

            if (item == null)
                throw new HttpException($"Category with id:{id} not found.", HttpStatusCode.NotFound); // 404

            return item;
        }
    }

    
}
