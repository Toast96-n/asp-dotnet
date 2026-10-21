namespace prac6.Models;

public class NotificationItem
{
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
    public string Category { get; init; } = string.Empty;
    public DateTime PublishedAt { get; init; }
}
