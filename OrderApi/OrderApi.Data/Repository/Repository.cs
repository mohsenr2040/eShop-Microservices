using OrderApi.Data.Context;
using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Data.Repository
{
    public class Repository<TDocument> : IRepository<TDocument> where TDocument : IDocument, new()
    {
        protected readonly OrderContext _orderContext;
        public Repository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }
        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }

        https://medium.com/@marekzyla95/mongo-repository-pattern-700986454a0e
        public async Task<TDocument> AddAsync(TDocument entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _orderContext.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)))(entity);
                await _orderContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved {ex.Message}");
            }
        }

        public async Task<List<TDocument>> AddRangeAsync(List<TDocument> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _orderContext.AddRangeAsync(entities);
                await _orderContext.SaveChangesAsync();
                return  entities;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entities)} could not be saved {ex.Message}");
            }
        }

        public IEnumerable<TDocument> GetAll()
        {
            try
            {
                return _orderContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities {ex.Message}");
            }
        }

        public async Task<TDocument> UpdateAsync(TDocument entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
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

        public async Task UpdateRangeAsync(List<TDocument> entities)
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
