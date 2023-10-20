using eTicketsEase.Data.Base;
using eTicketsEase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketsEase.Data.Services
{
    public class ActorsService :EntityBaseRepository<Actor>, IActorsService
    {
        public ActorsService(AppDbContext db) :base(db)
        {
        }
    }
}
