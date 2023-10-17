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
    public class ActorsController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IActorsService _actorsService;

        public ActorsController(AppDbContext db,IActorsService actorsService)
        {
            _db = db;
            _actorsService = actorsService;
        }
        public async Task<IActionResult> Index()
        {
            //comment below line code because Service implement
            //var data = await _db.Actors.ToListAsync();
            var data = await _actorsService.GetAllAsync();
            return View(data);
        }

        public  IActionResult Create()
        {
                
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePicturUrl,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
              await _actorsService.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1

        public async Task<IActionResult> Details(int id)
        {
            var actorResult =  await _actorsService.GetByIdAsync(id);
            if(actorResult == null)
            {
                return View("NotFound");
            }
            return View(actorResult);
        }
        //Get: Actors/Edit/1

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var actorResult = await _actorsService.GetByIdAsync(id);
            if (actorResult == null)
            {
                return View("NotFound");
            }
            return View(actorResult);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,FullName,ProfilePicturUrl,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _actorsService.updateAsync(actor);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var actorResult = await _actorsService.GetByIdAsync(id);
            if (actorResult == null)
            {
                return View("NotFound");
            }
            return View(actorResult);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorResult = await _actorsService.GetByIdAsync(id);
            if (actorResult == null)
            {
                return View("NotFound");
            }
            await _actorsService.DeleteAsync(actorResult.Id);
            return RedirectToAction(nameof(Index));
        }

    }
}
