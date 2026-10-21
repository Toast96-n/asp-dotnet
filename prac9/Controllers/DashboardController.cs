using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using prac6.Models;

namespace prac6.Controllers;

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        var requests = GetEmployeeLeaveRequests();
        return View(new DashboardViewModel
        {
            Profile = EmployeeProfileStore.Current,
            LeaveRequests = requests,
            PendingLeaveCount = requests.Count(request => request.Status == "Pending"),
            UpcomingHolidays = CompanyHolidayStore.All
                .Where(holiday => holiday.Date.Date >= DateTime.Today)
                .OrderBy(holiday => holiday.Date)
                .Take(3)
                .ToList()
        });
    }

    public IActionResult MyLeave()
    {
        var requests = GetEmployeeLeaveRequests();
        return View(new MyLeaveViewModel
        {
            Requests = requests,
            AnnualAllowance = EmployeeProfileStore.Current.AnnualLeaveAllowance,
            ApprovedDays = requests
                .Where(request => request.Status == "Approved")
                .Sum(GetDurationInDays)
        });
    }

    public IActionResult MyProfile() => View(EmployeeProfileStore.Current);

    public IActionResult Calendar()
    {
        return View(new LeaveCalendarViewModel
        {
            LeaveRequests = GetEmployeeLeaveRequests(),
            Holidays = CompanyHolidayStore.All.OrderBy(holiday => holiday.Date).ToList()
        });
    }

    private static List<LeaveRequest> GetEmployeeLeaveRequests() =>
        LeaveRequestStore.All
            .Where(request => string.Equals(
                request.Name,
                EmployeeProfileStore.Current.Name,
                StringComparison.OrdinalIgnoreCase))
            .OrderByDescending(request => request.From)
            .ToList();

    private static int GetDurationInDays(LeaveRequest request)
    {
        var validFrom = DateTime.TryParseExact(
            request.From, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var from);
        var validTo = DateTime.TryParseExact(
            request.To, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var to);

        return validFrom && validTo && to >= from ? (to - from).Days + 1 : 0;
    }
}
