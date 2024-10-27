using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagmentSystem.Application.Contracts.Repository;
using TravelManagmentSystem.Domain.Entities;
using TravelManagmentSystem.Persistence.Context;

namespace TravelManagmentSystem.Persistence.Repository
{
    public class GenericRepository<T>(AppDbContext _dbContext) : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> _dbSet = _dbContext.Set<T>();
        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public async Task<T> GetAsync(Guid id) => await _dbSet.FindAsync(id);
        public IQueryable<T> GetAll() => _dbSet.AsQueryable().AsNoTracking();
        public void Remove(T entity) => _dbSet.Remove(entity);
        public void Update(T entity)
        {
            var oldEntity = _dbSet.Find(entity.Id);
            _dbSet.Entry(oldEntity).State = EntityState.Detached;
            _dbSet.Entry(entity).State = EntityState.Added;
            _dbSet.Update(entity);
        }
    }
}
