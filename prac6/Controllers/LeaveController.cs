using Microsoft.AspNetCore.Mvc;
using prac6.Models;

namespace prac6.Controllers
{
    public class LeaveController : Controller
    {
        public IActionResult Index()
        {
            return View(LeaveRequestStore.All.ToList());
        }

        public IActionResult Apply()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Apply(
            string name,
            string address,
            string department,
            string contactInfo,
            string from,
            string to,
            string reason)
        {
            var leave = LeaveRequestStore.Add(new LeaveRequest
            {
                Name = name,
                Address = address,
                Department = department,
                ContactInfo = contactInfo,
                From = from,
                To = to,
                Reason = reason
            });

            TempData["Id"] = leave.Id;

            return RedirectToAction("Confirmation");
        }

        public IActionResult Details(int id)
        {
            var leave = LeaveRequestStore.Find(id);
            return leave is null ? NotFound() : View(leave);
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}