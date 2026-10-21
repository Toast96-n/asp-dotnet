namespace prac6.Models;

public class EmployeeSummaryItem
{
    public string EmployeeName { get; init; } = string.Empty;
    public string Department { get; init; } = string.Empty;
    public int LeaveRequestCount { get; init; }
    public int AttendanceDays { get; init; }
    public decimal HoursWorked { get; init; }
}
