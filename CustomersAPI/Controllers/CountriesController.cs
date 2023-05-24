using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomersAPI.Data;
using CustomersAPI.Models;
using CustomersAPI.Models.DTOs.CountryDtos;
using AutoMapper;

namespace CustomersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        public CountriesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryReadDto>>> GetCountries()
        {
          if (_context.Countries == null)
          {
              return NotFound();
          }
            var countries =  await _context.Countries.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<Country>,IEnumerable<CountryReadDto>>(countries));
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
          if (_context.Countries == null)
          {
              return NotFound();
          }
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // PUT: api/Countries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }

            _context.Entry(country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
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

        // POST: api/Countries
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CountryCreateDto countryDto)
        {
          if (_context.Countries == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Countries'  is null.");
          }

            var country = _mapper.Map<CountryCreateDto,Country>(countryDto);
            country.CreatedAt = DateTime.Now;

            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            if (_context.Countries == null)
            {
                return NotFound();
            }
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return (_context.Countries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
