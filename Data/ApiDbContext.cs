using HNG_Task_2_NET.Models;
using Microsoft.EntityFrameworkCore;

namespace HNG_Task_2_NET.Data ;



public class ApiDbContext : DbContext
{
  public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
  {
  }


    public DbSet<Person> People { get; set; } = null!;
   
}