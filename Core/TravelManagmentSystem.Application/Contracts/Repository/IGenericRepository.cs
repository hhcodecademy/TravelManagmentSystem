
using TravelManagmentSystem.Domain.Entities;

namespace TravelManagmentSystem.Application.Contracts.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task AddAsync(T entity);
        public void Update(T entity);
        public Task<T> GetAsync(Guid id);
        public IQueryable<T> GetAll();
        public void Remove(T entity);
    }
}
