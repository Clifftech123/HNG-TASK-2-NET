using HNG_Task_2_NET.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HNG_Task_2_NET.Models;

namespace HNG_Task_2_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PersonsController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Persons
        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            // Retrieve all persons from the database
            var persons = await _context.Set<Person>().ToListAsync();

            // Return the list of persons as an HTTP response
            return Ok(persons);
        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            // Find the person with the specified ID in the database
            var person = await _context.Set<Person>().FindAsync(id);

            // If the person is not found, return a 404 Not Found response
            if (person == null)
            {
                return NotFound();
            }

            // Return the person as an HTTP response
            return Ok(person);
        }

        // GET: api/Persons/ByName?
        [HttpGet("ByName")]
        public async Task<IActionResult> GetPersonByName([FromQuery] string name)
        {
            // Find the first person with the specified name in the database
            var person = await _context.Set<Person>().FirstOrDefaultAsync(p => p.Name == name);
            if (person == null)
            {
                return NotFound();
            }

            // Return the person as an HTTP response
            return Ok(person);
        }

        // POST: api/Persons
        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] Person person)
        {
            // If the person object is not valid, return a 400 Bad Request response
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Add the person to the database
            _context.Set<Person>().Add(person);
            await _context.SaveChangesAsync();


            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // PUT: api/Persons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, [FromBody] Person person)
        {
            // If the ID in the URL does not match the ID in the person object, return a 400 Bad Request response
            if (id != person.Id)
            {
                return BadRequest();
            }

            // Update the person in the database
            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // If the person is not found in the database, return a 404 Not Found response
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // Return a 204 No Content response
            return NoContent();
        }

        // DELETE: api/Persons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            // Find the person with the specified ID in the database
            var person = await _context.Set<Person>().FindAsync(id);

            // If the person is not found, return a 404 Not Found response
            if (person == null)
            {
                return NotFound();
            }

            // Remove the person from the database
            _context.Set<Person>().Remove(person);
            await _context.SaveChangesAsync();

            // Return the deleted person as an HTTP response
            return Ok(person);
        }

        private bool PersonExists(int id)
        {
            // Check if a person with the specified ID exists in the database
            return _context.Set<Person>().Any(e => e.Id == id);
        }
    }

}