using Microsoft.AspNetCore.Mvc;
using prac6.Models;

namespace prac6.Controllers;

public class PayrollController : Controller
{
    public IActionResult Index()
    {
        return View(new PayrollDashboardViewModel
        {
            AnnualSalary = PayrollStore.AnnualSalary,
            LatestPayslip = PayrollStore.Payslips[0],
            Payslips = PayrollStore.Payslips
        });
    }

    public IActionResult Payslip() => View(PayrollStore.Payslips);

    public IActionResult SalaryDetails() => View(PayrollStore.AnnualSalary);

    public IActionResult Deductions() => View(PayrollStore.Deductions);
}
