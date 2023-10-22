using eTicketsEase.Data;
using eTicketsEase.Data.Services;
using eTicketsEase.Models;
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
        private readonly IProducerService _service;

        public ProducersController(AppDbContext db,IProducerService service)
        {
            _db = db;
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {          
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePicturUrl,FullName,Bio")]Producer producer)
        {
            if (!ModelState.IsValid) { return View(); }
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if(data == null)
            {
                return View("NotFound");
            }
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null)
            {
                return View("NotFound");
            }
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id ,[Bind("Id,ProfilePicturUrl,FullName,Bio")]Producer producer)
        {
           
            if (!ModelState.IsValid)
            {
                return View(producer);
            }
            if (id == producer.Id)
            {
                await _service.updateAsync(producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null)
            {
                return View("NotFound");
            }
            return View(data);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(data.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
