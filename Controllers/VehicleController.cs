using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InspectionApp.Models;

namespace InspectionApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly ASPStateContext _context;

        public VehicleController(ASPStateContext context)
        {
            _context = context;
        }

        // GET: api/Vehicle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleInspection>>> GetVehicleInspections()
        {
            return await _context.VehicleInspections.ToListAsync();
        }

        // GET: api/Vehicle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleInspection>> GetVehicleInspection(int id)
        {
            var vehicleInspection = await _context.VehicleInspections.FindAsync(id);

            if (vehicleInspection == null)
            {
                return NotFound();
            }

            return vehicleInspection;
        }

        // PUT: api/Vehicle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("UpdateVehicleDetails")]
        public async Task<IActionResult> PutVehicleInspection(int id, VehicleInspection vehicleInspection)
        {
            if (id != vehicleInspection.RowId)
            {
                return BadRequest();
            }

            _context.Entry(vehicleInspection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleInspectionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VehicleAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("InsertVehicleDetails")]
        public async Task<ActionResult<VehicleInspection>> PostVehicleInspection(VehicleInspection vehicleInspection)
        {
            _context.VehicleInspections.Add(vehicleInspection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicleInspection", new { id = vehicleInspection.RowId }, vehicleInspection);
        }

        // DELETE: api/Vehicle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleInspection(int id)
        {
            var vehicleInspection = await _context.VehicleInspections.FindAsync(id);
            if (vehicleInspection == null)
            {
                return NotFound();
            }

            _context.VehicleInspections.Remove(vehicleInspection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehicleInspectionExists(int id)
        {
            return _context.VehicleInspections.Any(e => e.RowId == id);
        }
    }
}
