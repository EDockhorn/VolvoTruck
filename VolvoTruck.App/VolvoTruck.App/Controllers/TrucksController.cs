using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VolvoTruck.App.Models;

namespace VolvoTruck.App.Controllers
{
    public class TrucksController : Controller
    {
        private readonly VolvoTruckAppContext _context;

        public TrucksController(VolvoTruckAppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Trucks.ToListAsync());
        }
        public async Task<List<Truck>> ListTrucks()
        {
            return await _context.Trucks.ToListAsync();
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();

            var Truck = await _context.Trucks
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Truck == null) return NotFound();

            return View(Truck);
        }

        public IActionResult Create()
        {
            ViewBag.modelYear = ModelYearLists();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Truck Truck)
        {
            if (!ModelState.IsValid) return View(Truck);

            _context.Add(Truck);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var Truck = await _context.Trucks.FindAsync(id);
            if (Truck == null) return NotFound();

            ViewBag.modelYear = ModelYearLists();

            return View(Truck);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Truck Truck)
        {
            if (id != Truck.Id) return NotFound();

            if (!ModelState.IsValid) return View(Truck);

            try
            {
                _context.Update(Truck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(Truck);
            }
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var Truck = await _context.Trucks
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Truck == null) return NotFound();

            return View(Truck);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var Truck = await _context.Trucks.FindAsync(id);
            _context.Trucks.Remove(Truck);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public List<int> ModelYearLists()
        {
            return new List<int>(Enumerable.Range(DateTime.Now.Year, ((DateTime.Now.Year + 1) - DateTime.Now.Year) + 1));
        }
    }
}
