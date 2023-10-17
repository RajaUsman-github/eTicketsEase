using eTicketsEase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketsEase.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _db;

        public ActorsService(AppDbContext db)
        {
            _db = db;
        }
        public async Task AddAsync(Actor actor)
        {
            await _db.Actors.AddAsync(actor);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _db.Actors.FirstOrDefaultAsync(n => n.Id == id);
            _db.Actors.Remove(result);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
           return await _db.Actors.ToListAsync();
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            return await _db.Actors.FirstOrDefaultAsync(n=>n.Id == id);
        }

        public async Task<Actor> updateAsync( Actor newActor)
        {
            _db.Actors.Update(newActor);
            await _db.SaveChangesAsync();
            return newActor;
        }
    }
}
