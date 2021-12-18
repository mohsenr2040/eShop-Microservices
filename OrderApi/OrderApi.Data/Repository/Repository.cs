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
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly IMongoOrderContext _orderContext;
        protected IMongoCollection<TEntity> _dbCollection;
        public Repository(IMongoOrderContext orderContext)
        {
            _orderContext = orderContext;
            _dbCollection = _orderContext.GetCollection<TEntity>(typeof(TEntity).Name);
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _dbCollection.InsertOneAsync(entity);
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
                await _dbCollection.InsertManyAsync(entities);
                return entities;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entities)} could not be saved {ex.Message}");
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var all = await _dbCollection.FindAsync(Builders<TEntity>.Filter.Empty);
            return await all.ToListAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }

            try
            {
                await _dbCollection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", entity.Id),entity);
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
                foreach(var entity in entities)
                {
                    await _dbCollection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", entity.Id), entity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entities)} could not be updated {ex.Message}");
            }
        }

        
    }
}
