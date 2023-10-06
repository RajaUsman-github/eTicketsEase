using eTicketsEase.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketsEase.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _db;

        public MoviesController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _db.Movies.ToListAsync();
            return View();
        }
    }
}
