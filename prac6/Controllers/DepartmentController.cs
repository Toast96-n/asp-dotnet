using Microsoft.AspNetCore.Mvc;
using prac6.Models;

namespace prac6.Controllers;

public class DepartmentController : Controller
{
    private static readonly List<DepartmentInfo> DepartmentDirectory =
    [
        new DepartmentInfo
        {
            Id = "it",
            Name = "Information Technology",
            Description = "Maintains business systems, infrastructure, and technical support.",
            Manager = "Alex Morgan",
            Email = "it@company.example",
            Extension = "210"
        },
        new DepartmentInfo
        {
            Id = "hr",
            Name = "Human Resources",
            Description = "Supports employees, recruitment, workplace programs, and policies.",
            Manager = "Jordan Lee",
            Email = "hr@company.example",
            Extension = "220"
        },
        new DepartmentInfo
        {
            Id = "finance",
            Name = "Finance",
            Description = "Manages budgeting, accounting, payroll, and financial reporting.",
            Manager = "Casey Patel",
            Email = "finance@company.example",
            Extension = "230"
        },
        new DepartmentInfo
        {
            Id = "operations",
            Name = "Operations",
            Description = "Coordinates day-to-day services and business operations.",
            Manager = "Taylor Kim",
            Email = "operations@company.example",
            Extension = "240"
        }
    ];

    public IActionResult Departments() => View(DepartmentDirectory);

    public IActionResult Managers() => View(DepartmentDirectory);

    public IActionResult DepartmentDetails(string id)
    {
        var department = DepartmentDirectory.FirstOrDefault(
            item => string.Equals(item.Id, id, StringComparison.OrdinalIgnoreCase));
        return department is null ? NotFound() : View(department);
    }

    public IActionResult Contact() => View(DepartmentDirectory);
}
