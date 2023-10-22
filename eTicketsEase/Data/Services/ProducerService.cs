using eTicketsEase.Data.Base;
using eTicketsEase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketsEase.Data.Services
{
    public class ProducerService:EntityBaseRepository<Producer>,IProducerService
    {
        public ProducerService(AppDbContext db):base(db)
        {

        }
    }
}
