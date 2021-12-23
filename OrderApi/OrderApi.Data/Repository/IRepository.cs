using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IEnumerable<TEntity> GetAll();

        Task<TEntity> AddAsync(TEntity entity);
        Task<List<TEntity>> AddRangeAsync(List<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);

        Task UpdateRangeAsync(List<TEntity> entities);
    }
}
