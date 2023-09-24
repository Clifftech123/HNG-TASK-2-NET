using HNG_Task_2_NET.Data;
using Microsoft.AspNetCore.Mvc;
using HNG_Task_2_NET.Models;
using HNG_Task_2_NET.Services;

namespace HNG_Task_2_NET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        // GET: api/Persons
        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            // Retrieve all persons from the database
            var persons = await _personService.GetPersonsAsync();
            // Return the list of persons as an HTTP response
            return Ok(persons);
        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            // Find the person with the specified ID in the database
            var person = await _personService.GetPersonAsync(id);

            // If the person is not found, return a 404 Not Found response


            // Return the person as an HTTP response
            return Ok(person);
        }

        // GET: api/Persons/ByName?
        [HttpGet("ByName")]
        public async Task<IActionResult> GetPersonByName([FromQuery] string name)
        {
            // Find the first person with the specified name in the database

            var person = await _personService.GetPersonByNameAsync(name);
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

            var createdPerson = await _personService.CreatePersonAsync(person);

            // Add the person to the database



            return CreatedAtAction("GetPerson", new { id = createdPerson.Id }, createdPerson);
        }

        // PUT: api/Persons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, [FromBody] Person person)
        {
            // If the ID in the URL does not match the ID in the person object, return a 400 Bad Request response
            await _personService.UpdatePersonAsync(id, person);


            // Return a 204 No Content response
            return NoContent();
        }

        // DELETE: api/Persons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            await _personService.DeletePersonAsync(id);

            return NoContent();
        }

        //private bool PersonExists(int id)
        //{
        //    // Check if a person with the specified ID exists in the database
        //    return _context.Set<Person>().Any(e => e.Id == id);
        //}
    }

}