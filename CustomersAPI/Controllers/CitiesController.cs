using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomersAPI.Data;
using CustomersAPI.Models;
using CustomersAPI.Models.DTOs.CityDtos;
using CustomersAPI.Models.DTOs.CountryDtos;
using AutoMapper;
using CustomersAPI.Models.DTOs.NeighborhoodDtos;

namespace CustomersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CitiesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityReadDto>>> GetCities()
        {
          if (_context.Cities == null)
          {
              return NotFound();
          }
            var cities = await _context.Cities.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<City>, IEnumerable<CityReadDto>>(cities));
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
          if (_context.Cities == null)
          {
              return NotFound();
          }
            var city = await _context.Cities.FindAsync(id);

            if (city == null)
            {
                return NotFound();
            }

            return city;
        }

        // PUT: api/Cities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(int id, City city)
        {
            if (id != city.Id)
            {
                return BadRequest();
            }

            _context.Entry(city).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
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

        // POST: api/Cities
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(CityCreateDto cityDto)
        {
          if (_context.Cities == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Cities'  is null.");
          }

            if (!_context.Countries.Any(c => c.Id == cityDto.CountryId))
                return BadRequest("Wrong country");


            var city = _mapper.Map<CityCreateDto, City>(cityDto);
            city.CreatedAt = DateTime.Now;

            _context.Cities.Add(city);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCity", new { id = city.Id }, city);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            if (_context.Cities == null)
            {
                return NotFound();
            }
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CityExists(int id)
        {
            return (_context.Cities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
