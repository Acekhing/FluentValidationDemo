using FluentValidationDemo.Data;
using FluentValidationDemo.InterfaceRepositories;
using Microsoft.EntityFrameworkCore;

namespace FluentValidationDemo.Repository
{
    public class BaseRepository: IBaseRepository
    {
        private readonly ApplicationContext dbContext;

        public BaseRepository(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                await dbContext.AddAsync(entity);
                await dbContext.SaveChangesAsync();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task Delete<TEntity>(object Id) where TEntity : class
        {
            try
            {
                if (await Exist<TEntity>(Id))
                {
                    var entity = await Get<TEntity>(Id);
                    dbContext.Remove<TEntity>(entity);
                    await dbContext.SaveChangesAsync();
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Exist<TEntity>(object Id) where TEntity : class
        {
            var existingEntity = await dbContext.FindAsync<TEntity>(Id);
            return existingEntity != null;
        }

        public async Task<TEntity> Get<TEntity>(object Id) where TEntity : class
        {
            var result = await dbContext.FindAsync<TEntity>(Id);
            return result;
        }

        public ApplicationContext GetDbContext()
        {
            return dbContext;
        }

        public async Task Update<TEntity>(TEntity entity) where TEntity : class
        {
            try
            {
                // Existing entity is been tracked. First detached it from the context
                // Read more: https://stackoverflow.com/questions/70095949/the-instance-of-entity-type-cannot-be-tracked-because-another-instance-with-the

                dbContext.Entry(entity).State = EntityState.Detached;
                dbContext.Update(entity);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
