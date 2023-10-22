using eTicketsEase.Data.Base;
using eTicketsEase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketsEase.Data.Services
{
    public class CinemaService :EntityBaseRepository<Cinema>,ICinemaService
    {
        public CinemaService(AppDbContext db) :base(db)
        {

        }
    }
}
