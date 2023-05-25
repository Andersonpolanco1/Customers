using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomersAPI.Data;
using CustomersAPI.Models;
using CustomersAPI.Models.DTOs.CustomerDtos;
using CustomersAPI.Models.DTOs.CityDtos;
using AutoMapper;
using CustomersAPI.Models.DTOs.AddressDto;

namespace CustomersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CustomersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerReadDto>>> GetCustomers()
        {
          if (_context.Customers == null)
          {
              return NotFound();
          }
            var customers = await _context.Customers.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<Customer>,IEnumerable<CustomerReadDto>>(customers));   
        }

        // GET: api/Customers/5/addresses
        [HttpGet("{id}/Addresses")]
        public async Task<ActionResult<AddressReadDto>> GetCustomerAddresses(int id)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }

            var addresses = await _context.Addresses
                .Include(a => a.Neighborhood)
                .ThenInclude(n => n.City)
                .ThenInclude(c => c.Country)
                .Where(a => a.CustomerId == id)
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

            return Ok(addresses is null ? new List<AddressReadDto>() : addresses);

        }


        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
          if (_context.Customers == null)
          {
              return NotFound();
          }
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(CustomerCreateDto customerDto)
        {
          if (_context.Customers == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Customers'  is null.");
          }

            var customer = _mapper.Map<CustomerCreateDto, Customer>(customerDto);
            customer.CreatedAt = DateTime.Now;
            customer.IsActive = true;
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
