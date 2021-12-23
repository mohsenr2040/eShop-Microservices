using MongoDB.Driver;
using OrderApi.Data.Context;
using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly OrderContext _orderContext;
        public Repository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _orderContext.AddAsync(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved {ex.Message}");
            }
        }

        public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _orderContext.AddRangeAsync(entities);
                return entities;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entities)} could not be saved {ex.Message}");
            }
        }

        public  IEnumerable<TEntity> GetAll()
        {
           return  _orderContext.Set<TEntity>(); 
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }

            try
            {
                _orderContext.Update(entity);
                await _orderContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated {ex.Message}");
            }
        }

        public async Task UpdateRangeAsync(List<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateRangeAsync)} entities must not be null");
            }

            try
            {
                _orderContext.UpdateRange(entities);
                await _orderContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entities)} could not be updated {ex.Message}");
            }
        }

        
    }
}
