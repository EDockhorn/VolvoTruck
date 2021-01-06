using System;
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

        // GET: Trucks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Truck = await _context.Trucks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Truck == null)
            {
                return NotFound();
            }

            return View(Truck);
        }

        // GET: Trucks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trucks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Truck Truck)
        {
            if (!ModelState.IsValid) return View(Truck);

            _context.Add(Truck);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Trucks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Truck = await _context.Trucks.FindAsync(id);
            if (Truck == null)
            {
                return NotFound();
            }
            return View(Truck);
        }

        // POST: Trucks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Truck Truck)
        {
            if (id != Truck.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Truck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TruckExists(Truck.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Truck);
        }

        // GET: Trucks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Truck = await _context.Trucks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Truck == null)
            {
                return NotFound();
            }

            return View(Truck);
        }

        // POST: Trucks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var Truck = await _context.Trucks.FindAsync(id);
            _context.Trucks.Remove(Truck);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TruckExists(Guid id)
        {
            return _context.Trucks.Any(e => e.Id == id);
        }
    }
}
