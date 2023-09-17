using HNG_Task_2_NET.Data;
using HNG_Task_2_NET.Models;
using Microsoft.EntityFrameworkCore;

namespace HNG_Task_2_NET.Services
{
    public class PersonService
    {
        private readonly ApiDbContext _context;

        public PersonService(ApiDbContext context)
        {
            _context = context;
        }

        // Get all persons
        public async Task<List<Person>> GetPersonsAsync()
        {
            return await _context.Set<Person>().ToListAsync();

           
        }

        // Get a person by ID
        public async Task<Person> GetPersonAsync(int id)
        {
            return await _context.Set<Person>().FindAsync(id) ?? throw new Exception("Person not found.");
        }

        // Create a new person
        public async Task<Person> CreatePersonAsync(Person person)
        {
            _context.Set<Person>().Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        // Update an existing person
        public async Task<Person> UpdatePersonAsync(int id, Person person)
        {
            if (id != person.Id)
            {
                throw new ArgumentException("ID mismatch");
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    throw new Exception("Person not found.");
                }
                else
                {
                    throw;
                }
            }

            return person;
        }

        // Delete a person by ID
        public async Task<Person> DeletePersonAsync(int id)
        {
            var person = await GetPersonAsync(id);

            _context.Set<Person>().Remove(person);
            await _context.SaveChangesAsync();

            return person;
        }

        // Check if a person exists
        private bool PersonExists(int id)
        {
            return _context.Set<Person>().Any(e => e.Id == id);
        }
    }
}