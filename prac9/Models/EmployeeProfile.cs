namespace prac6.Models;

public class EmployeeProfile
{
    public string EmployeeId { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string JobTitle { get; init; } = string.Empty;
    public string Department { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Phone { get; init; } = string.Empty;
    public string Manager { get; init; } = string.Empty;
    public int AnnualLeaveAllowance { get; init; }
}

public static class EmployeeProfileStore
{
    public static EmployeeProfile Current { get; } = new()
    {
        EmployeeId = "EMP-1042",
        Name = "Alex Morgan",
        JobTitle = "Software Developer",
        Department = "Information Technology",
        Email = "alex.morgan@company.example",
        Phone = "555-0104",
        Manager = "Jordan Lee",
        AnnualLeaveAllowance = 20
    };
}

public class CompanyHoliday
{
    public DateTime Date { get; init; }
    public string Name { get; init; } = string.Empty;
}

public static class CompanyHolidayStore
{
    public static IReadOnlyList<CompanyHoliday> All { get; } =
    [
        new CompanyHoliday { Date = new DateTime(2026, 1, 1), Name = "New Year's Day" },
        new CompanyHoliday { Date = new DateTime(2026, 5, 1), Name = "Labor Day" },
        new CompanyHoliday { Date = new DateTime(2026, 7, 4), Name = "Independence Day" },
        new CompanyHoliday { Date = new DateTime(2026, 12, 25), Name = "Christmas Day" }
    ];
}

public class DashboardViewModel
{
    public EmployeeProfile Profile { get; init; } = new();
    public IReadOnlyList<LeaveRequest> LeaveRequests { get; init; } = [];
    public IReadOnlyList<CompanyHoliday> UpcomingHolidays { get; init; } = [];
    public int PendingLeaveCount { get; init; }
}

public class MyLeaveViewModel
{
    public IReadOnlyList<LeaveRequest> Requests { get; init; } = [];
    public int AnnualAllowance { get; init; }
    public int ApprovedDays { get; init; }
    public int RemainingDays => Math.Max(0, AnnualAllowance - ApprovedDays);
}

public class LeaveCalendarViewModel
{
    public IReadOnlyList<LeaveRequest> LeaveRequests { get; init; } = [];
    public IReadOnlyList<CompanyHoliday> Holidays { get; init; } = [];
}
