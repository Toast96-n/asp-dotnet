using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using prac6.Models;

namespace prac6.Controllers;

public class AttendanceController : Controller
{
    public IActionResult Index() => View(AttendanceStore.All);

    public IActionResult Mark() => View(new AttendanceEntryViewModel());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Mark(AttendanceEntryViewModel model)
    {
        if (model.Date.Date > DateTime.Today)
        {
            ModelState.AddModelError(nameof(model.Date), "Attendance cannot be marked for a future date.");
        }

        var hasCheckIn = TimeOnly.TryParseExact(
            model.CheckIn,
            "HH:mm",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out var checkIn);

        if (!hasCheckIn)
        {
            ModelState.AddModelError(nameof(model.CheckIn), "Enter a check-in time in HH:mm format.");
        }

        TimeOnly? checkOut = null;
        if (!string.IsNullOrWhiteSpace(model.CheckOut))
        {
            if (!TimeOnly.TryParseExact(
                    model.CheckOut,
                    "HH:mm",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var parsedCheckOut))
            {
                ModelState.AddModelError(nameof(model.CheckOut), "Enter a check-out time in HH:mm format.");
            }
            else if (hasCheckIn && parsedCheckOut <= checkIn)
            {
                ModelState.AddModelError(nameof(model.CheckOut), "Check-out must be later than check-in.");
            }
            else
            {
                checkOut = parsedCheckOut;
            }
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var record = new AttendanceRecord
        {
            EmployeeName = model.EmployeeName.Trim(),
            Date = model.Date.Date,
            CheckIn = model.Date.Date.Add(checkIn.ToTimeSpan()),
            CheckOut = checkOut.HasValue ? model.Date.Date.Add(checkOut.Value.ToTimeSpan()) : null
        };

        if (!AttendanceStore.TryAddOrComplete(record))
        {
            ModelState.AddModelError(nameof(model.EmployeeName), "Attendance already exists for this employee on this date. If the check-in is incomplete, enter a check-out time to complete it.");
            return View(model);
        }

        return RedirectToAction(nameof(Index));
    }

    public IActionResult History() => View(AttendanceStore.All);

    public IActionResult Summary(int? year, int? month)
    {
        var today = DateTime.Today;
        var selectedYear = year ?? today.Year;
        var selectedMonth = month ?? today.Month;
        if (selectedYear < 1 || selectedYear > 9999 || selectedMonth < 1 || selectedMonth > 12)
        {
            return BadRequest("Select a valid year and month.");
        }

        var records = AttendanceStore.All
            .Where(record => record.Date.Year == selectedYear && record.Date.Month == selectedMonth)
            .ToList();

        return View(new AttendanceMonthlySummaryViewModel
        {
            Year = selectedYear,
            Month = selectedMonth,
            Records = records
        });
    }
}
