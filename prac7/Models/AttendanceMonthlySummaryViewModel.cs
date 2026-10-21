namespace prac6.Models;

public class AttendanceMonthlySummaryViewModel
{
    public int Year { get; init; }
    public int Month { get; init; }
    public IReadOnlyList<AttendanceRecord> Records { get; init; } = [];
    public int AttendanceCount => Records.Count;
    public int EmployeeCount => Records.Select(record => record.EmployeeName)
        .Distinct(StringComparer.OrdinalIgnoreCase)
        .Count();
    public decimal TotalHours => Records.Sum(record => record.HoursWorked);
}
