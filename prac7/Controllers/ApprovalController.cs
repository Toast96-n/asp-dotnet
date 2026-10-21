using Microsoft.AspNetCore.Mvc;
using prac6.Models;

namespace prac6.Controllers;

public class ApprovalController : Controller
{
    public IActionResult Status()
    {
        return View(LeaveRequestStore.All.OrderByDescending(request => request.Id).ToList());
    }

    public IActionResult Pending()
    {
        return View(GetByStatus("Pending"));
    }

    public IActionResult Approved()
    {
        return View(GetByStatus("Approved"));
    }

    public IActionResult Rejected()
    {
        return View(GetByStatus("Rejected"));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Approve(int id) => UpdateStatus(id, "Approved");

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Reject(int id) => UpdateStatus(id, "Rejected");

    private static List<LeaveRequest> GetByStatus(string status) =>
        LeaveRequestStore.All
            .Where(request => request.Status == status)
            .OrderByDescending(request => request.Id)
            .ToList();

    private IActionResult UpdateStatus(int id, string status)
    {
        var request = LeaveRequestStore.Find(id);
        if (request is null)
        {
            return NotFound();
        }

        if (request.Status != "Pending")
        {
            return BadRequest("Only pending leave requests can be approved or rejected.");
        }

        request.Status = status;
        return RedirectToAction("Pending");
    }
}
