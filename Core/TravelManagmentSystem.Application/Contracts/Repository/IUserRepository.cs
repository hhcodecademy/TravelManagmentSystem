using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagmentSystem.Domain.Entities;

namespace TravelManagmentSystem.Application.Contracts.Repository
{
    public interface IUserRepository
    {
        public Task AddAsync(AppUser entity);
        public void Update(AppUser entity);
        public Task<AppUser> GetAsync(Guid id);
        public IQueryable<AppUser> GetAll();
        public void Remove(AppUser entity);
    }
}
