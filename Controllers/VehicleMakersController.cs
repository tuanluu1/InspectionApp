using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InspectionApp.Models;

namespace InspectionApp.Controllers
{
    public class VehicleMakersController : Controller
    {
        private readonly ASPStateContext _context;

        public VehicleMakersController(ASPStateContext context)
        {
            _context = context;
        }

        // GET: VehicleMakers
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehicleMakers.ToListAsync());
        }

        // GET: VehicleMakers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleMaker = await _context.VehicleMakers
                .FirstOrDefaultAsync(m => m.MakerId == id);
            if (vehicleMaker == null)
            {
                return NotFound();
            }

            return View(vehicleMaker);
        }

        // GET: VehicleMakers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleMakers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MakerId,Maker")] VehicleMaker vehicleMaker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleMaker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleMaker);
        }

        // GET: VehicleMakers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleMaker = await _context.VehicleMakers.FindAsync(id);
            if (vehicleMaker == null)
            {
                return NotFound();
            }
            return View(vehicleMaker);
        }

        // POST: VehicleMakers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MakerId,Maker")] VehicleMaker vehicleMaker)
        {
            if (id != vehicleMaker.MakerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleMaker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleMakerExists(vehicleMaker.MakerId))
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
            return View(vehicleMaker);
        }

        // GET: VehicleMakers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleMaker = await _context.VehicleMakers
                .FirstOrDefaultAsync(m => m.MakerId == id);
            if (vehicleMaker == null)
            {
                return NotFound();
            }

            return View(vehicleMaker);
        }

        // POST: VehicleMakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleMaker = await _context.VehicleMakers.FindAsync(id);
            _context.VehicleMakers.Remove(vehicleMaker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleMakerExists(int id)
        {
            return _context.VehicleMakers.Any(e => e.MakerId == id);
        }
    }
}
