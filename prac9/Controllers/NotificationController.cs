using Microsoft.AspNetCore.Mvc;
using prac6.Models;

namespace prac6.Controllers;

public class NotificationController : Controller
{
    public IActionResult Index() => View(NotificationStore.All);

    public IActionResult Announcement() =>
        View(NotificationStore.All
            .Where(notification => notification.Category == "Announcement")
            .ToList());

    public IActionResult Reminder() =>
        View(NotificationStore.All
            .Where(notification => notification.Category.EndsWith("Reminder", StringComparison.Ordinal))
            .ToList());

    public IActionResult Message(int id)
    {
        var notification = NotificationStore.Find(id);
        return notification is null ? NotFound() : View(notification);
    }
}
