using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entity.Shared;
using Microsoft.EntityFrameworkCore;
using Entity.Context;
using Repository.Interface;

namespace Repository.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityId
    {
        private readonly AppEccommerceDbContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(AppEccommerceDbContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public void AddEntity(T entity)
        {
            _entity.Add(entity);
        }

        public async Task AddEntityAsync(T entity)
        {
            await _entity.AddAsync(entity);
        }

        public List<T> getEntity(bool track)
        {
            return track ? _entity.AsNoTracking().ToList() : _entity.ToList();
        }

        public async Task<List<T>> getEntityAsync(bool track)
        {
            return track ? await _entity.AsNoTracking().ToListAsync() : await _entity.ToListAsync();
        }

        public async Task<List<T>> getEntityAsync(Expression<Func<T, bool>> expression, bool track)
        {
            return track ? await _entity.AsNoTracking().Where(expression).ToListAsync() : await _entity.Where(expression).ToListAsync();
        }

        public List<T> getEntity(Expression<Func<T, bool>> expression, bool track)
        {
            return track ? _entity.AsNoTracking().Where(expression).ToList() : _entity.Where(expression).ToList();
        }

        public async Task<T> getEntityAsyncById(int id)
        {
            return await _entity.Where(d => d.Id == id).FirstOrDefaultAsync();
        }
        public async Task<T> getOneEntityAsync(Expression<Func<T, bool>> expression, bool track)
        {
            return track ? await _entity.AsNoTracking().Where(expression).FirstOrDefaultAsync() : await _entity.Where(expression).FirstOrDefaultAsync();
        }


        public T getEntityById(int id)
        {
            return _entity.Where(d => d.Id == id).FirstOrDefault();
        }

        public void updateEntity(T entity)
        {
            _entity.Update(entity);
        }
        public IQueryable<T> GetAsQueryableString(String includes, Expression<Func<T, bool>> predicate = null)
        {
            String[] str = includes.Split(',', StringSplitOptions.RemoveEmptyEntries);
            IQueryable<T> query = _context.Set<T>().Where(predicate);
            foreach (var includeProperty in str)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
    }
}