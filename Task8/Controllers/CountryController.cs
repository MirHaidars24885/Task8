using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Task8.Models;
using Task8.Context;

namespace Task8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly maksousDbContext _context;

        public CountryController(maksousDbContext context)
        {
            _context = context;
        }

        // GET: api/country
        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _context.Countries.ToListAsync();
            return Ok(countries);
        }

        // GET: api/country/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        // POST: api/country
        [HttpPost]
        public async Task<IActionResult> CreateCountry([FromBody] Country country)
        {
            if (country == null)
            {
                return BadRequest("Country is null.");
            }

            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCountry), new { id = country.IdCountry }, country);
        }

        // PUT: api/country/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCountry(int id, [FromBody] Country country)
        {
            if (id != country.IdCountry)
            {
                return BadRequest("Country ID mismatch.");
            }

            var countryToUpdate = await _context.Countries.FindAsync(id);
            if (countryToUpdate == null)
            {
                return NotFound("Country not found.");
            }

            countryToUpdate.Name = country.Name;
            
            _context.Countries.Update(countryToUpdate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/country/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound("Country not found.");
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
