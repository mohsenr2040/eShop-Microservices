﻿using OrderApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> AddAsync(TEntity entity);
        Task<List<TEntity>> AddRangeAsync(List<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);

        Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entities);
    }
}
