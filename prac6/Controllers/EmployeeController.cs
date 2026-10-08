using Microsoft.AspNetCore.Mvc;

namespace LeaveApplication.Controllers
{
    public class EmployeeController : Controller
    {
        static List<string[]> employees = new List<string[]>
        {
            new string[] { "1", "Rahul", "Vadodara", "IT", "9876543210" },
            new string[] { "2", "Amit", "Ahmedabad", "HR", "9876501234" }
        };

        public IActionResult Employees()
        {
            return View(employees);
        }

        public IActionResult Profile(int id)
        {
            var employee = employees.FirstOrDefault(x => x[0] == id.ToString());

            TempData["Id"] = employee[0];
            TempData["Name"] = employee[1];
            TempData["Address"] = employee[2];
            TempData["Department"] = employee[3];
            TempData["Contact"] = employee[4];

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(
            string name,
            string address,
            string department,
            string contact)
        {
            string id = (employees.Count + 1).ToString();

            employees.Add(new string[]
            {
                id,
                name,
                address,
                department,
                contact
            });

            return RedirectToAction("Employees");
        }

        public IActionResult Edit(int id)
        {
            var employee = employees.FirstOrDefault(x => x[0] == id.ToString());

            TempData["Id"] = employee[0];
            TempData["Name"] = employee[1];
            TempData["Address"] = employee[2];
            TempData["Department"] = employee[3];
            TempData["Contact"] = employee[4];

            return View();
        }

        [HttpPost]
        public IActionResult Edit(
            int id,
            string name,
            string address,
            string department,
            string contact)
        {
            var employee = employees.FirstOrDefault(x => x[0] == id.ToString());

            employee[1] = name;
            employee[2] = address;
            employee[3] = department;
            employee[4] = contact;

            return RedirectToAction("Employees");
        }
    }
}