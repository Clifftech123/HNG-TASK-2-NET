using System.ComponentModel.DataAnnotations;

namespace HNG_Task_2_NET.Models;
public class Person
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Email { get; set; }  = null!;

    [MaxLength(15)]
    public string Phone { get; set; }   = null!;

}