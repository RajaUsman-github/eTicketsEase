﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketsEase.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _db;
        public EntityBaseRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
            EntityEntry entityEntry = _db.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _db.Set<T>().FirstOrDefaultAsync(a => a.Id == id);
        }

        public async  Task<T> updateAsync(T entity)
        {
            EntityEntry entityEntry =  _db.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
