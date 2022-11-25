using FluentValidationDemo.Data;
using Microsoft.EntityFrameworkCore;

namespace FluentValidationDemo.InterfaceRepositories
{
    public interface IBaseRepository
    {
        public Task Create<TEntity>(TEntity entity) where TEntity : class;
        public Task Update<TEntity>(TEntity entity) where TEntity : class;
        public Task<bool> Exist<TEntity>(object Id) where TEntity : class;
        public Task Delete<TEntity>(object Id) where TEntity : class;
        public Task<TEntity> Get<TEntity>(object Id) where TEntity : class;
        public ApplicationContext GetDbContext();
    }
}
