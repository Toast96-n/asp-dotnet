using System.ComponentModel.DataAnnotations;

namespace prac6.Models;

public class EmployeeRecord
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(250)]
    public string Address { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Department { get; set; } = string.Empty;

    [Required]
    [Phone]
    [StringLength(32)]
    [Display(Name = "Contact number")]
    public string Contact { get; set; } = string.Empty;
}
