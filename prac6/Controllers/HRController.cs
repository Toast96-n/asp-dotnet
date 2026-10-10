using Microsoft.AspNetCore.Mvc;

namespace prac6.Controllers;

public class HRController : Controller
{
    public IActionResult LeavePolicy() => View();

    public IActionResult HolidayList() => View();

    public IActionResult HRContacts() => View();

    public IActionResult Help() => View();
}
