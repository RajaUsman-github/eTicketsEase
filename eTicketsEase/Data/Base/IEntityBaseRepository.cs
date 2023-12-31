﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketsEase.Data.Base
{
    public interface IEntityBaseRepository<T> where T:class,IEntityBase,new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task<T> updateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
