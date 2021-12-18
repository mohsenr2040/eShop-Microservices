using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Data.Repository
{
    public interface IRepository<TDocument> where TDocument : IDocument, new()
    {
        public IEnumerable<TDocument> GetAll();
        Task<TDocument> AddAsync(TDocument entity);
        Task<List<TDocument>> AddRangeAsync(List<TDocument> entities);
        Task<TDocument> UpdateAsync(TDocument entity);
        Task UpdateRangeAsync(List<TDocument> entities);
    }
}
