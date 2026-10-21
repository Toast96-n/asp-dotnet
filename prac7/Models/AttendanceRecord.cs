namespace prac6.Models;

public class AttendanceRecord
{
    public int Id { get; set; }
    public string EmployeeName { get; init; } = string.Empty;
    public DateTime Date { get; init; }
    public DateTime CheckIn { get; init; }
    public DateTime? CheckOut { get; set; }
    public decimal HoursWorked => CheckOut.HasValue
        ? Math.Round((decimal)(CheckOut.Value - CheckIn).TotalHours, 2)
        : 0;
}
