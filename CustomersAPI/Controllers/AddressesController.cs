using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomersAPI.Data;
using CustomersAPI.Models;
using CustomersAPI.Models.DTOs.AddressDto;
using AutoMapper;

namespace CustomersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AddressesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressReadDto>>> GetAddresses()
        {
          if (_context.Addresses == null)
          {
              return NotFound();
          }
            return await _context.Addresses
                .Include(a => a.Neighborhood)
                .ThenInclude(n => n.City)
                .ThenInclude(c => c.Country)
                .Select(a => new AddressReadDto
                {
                    CustomerId = a.CustomerId,
                    NeighborhoodName = a.Neighborhood.Description,
                    CityName = a.Neighborhood.City.Description,
                    CountryName = a.Neighborhood.City.Country.Description,
                    Number = a.Number,
                    Street = a.Street,
                    Observations = a.Observations
                }).ToListAsync();
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
          if (_context.Addresses == null)
          {
              return NotFound();
          }
            var address = await _context.Addresses.FindAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        // PUT: api/Addresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, Address address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }

            _context.Entry(address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
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

        // POST: api/Addresses
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(AddressCreateDto addressDto)
        {
          if (_context.Addresses == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Addresses'  is null.");
          }

            if (!_context.Customers.Any(c => c.Id == addressDto.CustomerId))
                return BadRequest("Wrong customer...");

            if (!_context.Neighborhoods.Any(n => n.Id == addressDto.NeighborhoodId))
                return BadRequest("Wrong neighborhood...");

            var address = _mapper.Map<AddressCreateDto, Address>(addressDto);
            address.CreatedAt = DateTime.Now;

            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = address.Id }, address);
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            if (_context.Addresses == null)
            {
                return NotFound();
            }
            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressExists(int id)
        {
            return (_context.Addresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
