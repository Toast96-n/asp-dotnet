using Microsoft.AspNetCore.Mvc;

namespace LeaveApplication.Controllers
{
    public class LeaveController : Controller
    {
        static List<string[]> leaves = new List<string[]>();

        public IActionResult Index()
        {
            return View(leaves);
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
            string id = (leaves.Count + 1).ToString();

            leaves.Add(new string[]
            {
                id,
                name,
                address,
                department,
                contactInfo,
                from,
                to,
                reason
            });

            TempData["Id"] = id;

            return RedirectToAction("Confirmation");
        }

        public IActionResult Details(int id)
        {
            var leave = leaves.FirstOrDefault(x => x[0] == id.ToString());

            TempData["Name"] = leave[1];
            TempData["Address"] = leave[2];
            TempData["Department"] = leave[3];
            TempData["ContactInfo"] = leave[4];
            TempData["From"] = leave[5];
            TempData["To"] = leave[6];
            TempData["Reason"] = leave[7];

            return View();
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}