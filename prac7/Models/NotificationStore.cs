namespace prac6.Models;

public static class NotificationStore
{
    private static readonly List<NotificationItem> Notifications =
    [
        new NotificationItem
        {
            Id = 1,
            Title = "Quarterly town hall",
            Message = "Join the company town hall in the main conference room. A remote meeting link will be shared before the event.",
            Category = "Announcement",
            PublishedAt = DateTime.Today.AddDays(-1)
        },
        new NotificationItem
        {
            Id = 2,
            Title = "Review your leave balance",
            Message = "Please review your leave balance and submit any planned leave requests through the Leave section.",
            Category = "Leave Reminder",
            PublishedAt = DateTime.Today
        },
        new NotificationItem
        {
            Id = 3,
            Title = "Upcoming public holiday",
            Message = "The office will be closed for the upcoming public holiday. Contact HR if you have questions about the holiday schedule.",
            Category = "Holiday Reminder",
            PublishedAt = DateTime.Today.AddDays(-2)
        }
    ];

    public static IReadOnlyList<NotificationItem> All =>
        Notifications.OrderByDescending(notification => notification.PublishedAt).ToList();

    public static NotificationItem? Find(int id) =>
        Notifications.FirstOrDefault(notification => notification.Id == id);
}
