using Microsoft.AspNetCore.Mvc;
using prac6.Models;

namespace prac6.Controllers;

public class ReportController : Controller
{
    public IActionResult Index()
    {
        var leaveRequests = LeaveRequestStore.All;
        var attendanceRecords = AttendanceStore.All;
        var employeeCount = leaveRequests.Select(request => request.Name)
            .Concat(attendanceRecords.Select(record => record.EmployeeName))
            .Where(name => !string.IsNullOrWhiteSpace(name))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .Count();

        return View(new ReportDashboardViewModel
        {
            TotalLeaveRequests = leaveRequests.Count,
            PendingLeaveRequests = leaveRequests.Count(request => request.Status == "Pending"),
            AttendanceRecords = attendanceRecords.Count,
            EmployeesWithRecords = employeeCount
        });
    }

    public IActionResult LeaveReport() =>
        View(LeaveRequestStore.All.OrderByDescending(request => request.Id).ToList());

    public IActionResult AttendanceReport() => View(AttendanceStore.All);

    public IActionResult EmployeeSummary()
    {
        var leaveRequests = LeaveRequestStore.All;
        var attendanceRecords = AttendanceStore.All;
        var employeeNames = leaveRequests.Select(request => request.Name)
            .Concat(attendanceRecords.Select(record => record.EmployeeName))
            .Where(name => !string.IsNullOrWhiteSpace(name))
            .Distinct(StringComparer.OrdinalIgnoreCase);

        var summary = employeeNames
            .Select(name =>
            {
                var employeeLeaves = leaveRequests
                    .Where(request => string.Equals(request.Name, name, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                var employeeAttendance = attendanceRecords
                    .Where(record => string.Equals(record.EmployeeName, name, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                return new EmployeeSummaryItem
                {
                    EmployeeName = name,
                    Department = employeeLeaves.FirstOrDefault()?.Department ?? "—",
                    LeaveRequestCount = employeeLeaves.Count,
                    AttendanceDays = employeeAttendance.Count,
                    HoursWorked = employeeAttendance.Sum(record => record.HoursWorked)
                };
            })
            .OrderBy(employee => employee.EmployeeName)
            .ToList();

        return View(summary);
    }
}
