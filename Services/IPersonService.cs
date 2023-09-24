using HNG_Task_2_NET.Models;
using Microsoft.AspNetCore.Mvc;

namespace HNG_Task_2_NET.Services
{
    public interface IPersonService
    {
        Task<List<Person>> GetPersonsAsync();
        Task<Person> GetPersonAsync(int id);
        Task<Person> CreatePersonAsync(Person person);
        Task<Person> UpdatePersonAsync(int id, Person person);
        Task<Person> DeletePersonAsync(int id);
        Task<Person> GetPersonByNameAsync(string name);

    }
}
