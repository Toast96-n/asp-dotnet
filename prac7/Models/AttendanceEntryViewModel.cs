using System.ComponentModel.DataAnnotations;

namespace prac6.Models;

public class AttendanceEntryViewModel
{
    [Required]
    [StringLength(100)]
    public string EmployeeName { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateTime Date { get; set; } = DateTime.Today;

    [Required]
    public string CheckIn { get; set; } = DateTime.Now.ToString("HH:mm");

    public string? CheckOut { get; set; }
}
