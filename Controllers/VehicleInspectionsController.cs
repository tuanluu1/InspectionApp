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
    public class VehicleInspectionsController : Controller
    {
        private readonly ASPStateContext _context;

        public VehicleInspectionsController(ASPStateContext context)
        {
            _context = context;
        }

        // GET: VehicleInspections
        public async Task<IActionResult> Index()
        {
            var aSPStateContext = _context.VehicleInspections.Include(v => v.VehicleMakerNavigation);
            return View(await aSPStateContext.ToListAsync());
        }

        // GET: VehicleInspections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleInspection = await _context.VehicleInspections
                .Include(v => v.VehicleMakerNavigation)
                .FirstOrDefaultAsync(m => m.RowId == id);
            if (vehicleInspection == null)
            {
                return NotFound();
            }

            return View(vehicleInspection);
        }

        // GET: VehicleInspections/Create
        public IActionResult Create()
        {
            ViewData["VehicleMaker"] = new SelectList(_context.VehicleMakers, "MakerId", "Maker");
            return View();
        }

        // POST: VehicleInspections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RowId,Vin,VehicleMaker,VehicleYear,VehicleModel,InspectionDate,InspectorName,InspectionLocation,PassFail,Notes")] VehicleInspection vehicleInspection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleInspection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleMaker"] = new SelectList(_context.VehicleMakers, "MakerId", "Maker", vehicleInspection.VehicleMaker);
            return View(vehicleInspection);
        }

        // GET: VehicleInspections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleInspection = await _context.VehicleInspections.FindAsync(id);
            if (vehicleInspection == null)
            {
                return NotFound();
            }
            ViewData["VehicleMaker"] = new SelectList(_context.VehicleMakers, "MakerId", "Maker", vehicleInspection.VehicleMaker);
            return View(vehicleInspection);
        }

        // POST: VehicleInspections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RowId,Vin,VehicleMaker,VehicleYear,VehicleModel,InspectionDate,InspectorName,InspectionLocation,PassFail,Notes")] VehicleInspection vehicleInspection)
        {
            if (id != vehicleInspection.RowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleInspection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleInspectionExists(vehicleInspection.RowId))
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
            ViewData["VehicleMaker"] = new SelectList(_context.VehicleMakers, "MakerId", "Maker", vehicleInspection.VehicleMaker);
            return View(vehicleInspection);
        }

        // GET: VehicleInspections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleInspection = await _context.VehicleInspections
                .Include(v => v.VehicleMakerNavigation)
                .FirstOrDefaultAsync(m => m.RowId == id);
            if (vehicleInspection == null)
            {
                return NotFound();
            }

            return View(vehicleInspection);
        }

        // POST: VehicleInspections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleInspection = await _context.VehicleInspections.FindAsync(id);
            _context.VehicleInspections.Remove(vehicleInspection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleInspectionExists(int id)
        {
            return _context.VehicleInspections.Any(e => e.RowId == id);
        }
    }
}
