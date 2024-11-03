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
    public class UserRepository(AppDbContext _dbContext) : IUserRepository
    {
      private readonly DbSet<AppUser> _users = _dbContext.Set<AppUser>();
        public async Task AddAsync(AppUser entity)=>await _users.AddAsync(entity);
            
        

        public IQueryable<AppUser> GetAll()=> _users.AsQueryable().AsNoTracking();

        public async Task<AppUser> GetAsync(Guid id) => await _users.FindAsync(id);

        public void Remove(AppUser entity)=>_users.Remove(entity);

        public void Update(AppUser entity)
        {
            var oldEntity = _users.Find(entity.Id);
            _users.Entry(oldEntity).State = EntityState.Detached;
            _users.Entry(entity).State = EntityState.Added;
            _users.Update(entity);
        }
    }
}
