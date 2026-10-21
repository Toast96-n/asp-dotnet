using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prac6.Data;
using prac6.Models;

namespace prac6.Controllers
{
    public class EmployeeController(ApplicationDbContext context) : Controller
    {
        public async Task<IActionResult> Employees()
        {
            var employees = await context.Employees
                .AsNoTracking()
                .OrderBy(employee => employee.Id)
                .ToListAsync();
            return View(employees);
        }

        public async Task<IActionResult> Profile(int id)
        {
            var employee = await context.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(item => item.Id == id);
            return employee is null ? NotFound() : View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeRecord employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            context.Employees.Add(employee);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Employees));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            return employee is null ? NotFound() : View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeRecord employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            context.Employees.Update(employee);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Employees));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            if (employee is null)
            {
                return NotFound();
            }

            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Employees));
        }
    }
}