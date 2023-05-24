using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomersAPI.Data;
using CustomersAPI.Models;
using AutoMapper;
using CustomersAPI.Models.DTOs.CityDtos;
using CustomersAPI.Models.DTOs.NeighborhoodDtos;

namespace CustomersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeighborhoodsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public NeighborhoodsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Neighborhoods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NeighborhoodReadDto>>> GetNeighborhoods()
        {
          if (_context.Neighborhoods == null)
          {
              return NotFound();
          }
            var neighborhoods = await _context.Neighborhoods.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<Neighborhood>, IEnumerable<NeighborhoodReadDto>>(neighborhoods));

        }

        // GET: api/Neighborhoods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Neighborhood>> GetNeighborhood(int id)
        {
          if (_context.Neighborhoods == null)
          {
              return NotFound();
          }
            var neighborhood = await _context.Neighborhoods.FindAsync(id);

            if (neighborhood == null)
            {
                return NotFound();
            }

            return neighborhood;
        }

        // PUT: api/Neighborhoods/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNeighborhood(int id, Neighborhood neighborhood)
        {
            if (id != neighborhood.Id)
            {
                return BadRequest();
            }

            _context.Entry(neighborhood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NeighborhoodExists(id))
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

        // POST: api/Neighborhoods
        [HttpPost]
        public async Task<ActionResult<Neighborhood>> PostNeighborhood(NeighborhoodCreateDto neighborhoodDto)
        {
          if (_context.Neighborhoods == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Neighborhoods'  is null.");
          }

            if (!_context.Cities.Any(c => c.Id == neighborhoodDto.CityId))
                return BadRequest("Wrong city");

            var neighborhood = _mapper.Map<NeighborhoodCreateDto, Neighborhood>(neighborhoodDto);
            neighborhood.CreatedAt = DateTime.Now;

            _context.Neighborhoods.Add(neighborhood);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNeighborhood", new { id = neighborhood.Id }, neighborhood);
        }

        // DELETE: api/Neighborhoods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNeighborhood(int id)
        {
            if (_context.Neighborhoods == null)
            {
                return NotFound();
            }
            var neighborhood = await _context.Neighborhoods.FindAsync(id);
            if (neighborhood == null)
            {
                return NotFound();
            }

            _context.Neighborhoods.Remove(neighborhood);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NeighborhoodExists(int id)
        {
            return (_context.Neighborhoods?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
