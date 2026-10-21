using Microsoft.AspNetCore.Mvc;
using prac6.Models;

namespace prac6.Controllers;

public class TrainingController : Controller
{
    public IActionResult Training() => View(TrainingStore.ProgramsList);

    [HttpGet]
    public IActionResult Register(int id)
    {
        var program = TrainingStore.Find(id);
        return program is null ? NotFound() : View(program);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(int id, string? employeeName)
    {
        if (TrainingStore.Find(id) is null)
        {
            return NotFound();
        }

        if (!string.Equals(
                employeeName?.Trim(),
                EmployeeProfileStore.Current.Name,
                StringComparison.OrdinalIgnoreCase))
        {
            ModelState.AddModelError(nameof(employeeName), "Enter the name on your employee profile.");
            return View(TrainingStore.Find(id));
        }

        if (!TrainingStore.TryRegister(id))
        {
            TempData["TrainingError"] = "This session is full. Choose another training program.";
            return RedirectToAction(nameof(Training));
        }

        TempData["TrainingMessage"] = "Your training registration is confirmed.";
        return RedirectToAction(nameof(Training));
    }

    public IActionResult Schedule() => View(TrainingStore.ProgramsList.OrderBy(program => program.StartDate).ToList());

    public IActionResult Certificate() => View(TrainingStore.Certificates);
}
