using eTicketsEase.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketsEase.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext _db;

        public ProducersController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _db.Producers.ToListAsync();
            return View(data);
        }
    }
}
