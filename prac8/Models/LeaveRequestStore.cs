namespace prac6.Models;

public static class LeaveRequestStore
{
    private static readonly List<LeaveRequest> Requests =
    [
        new LeaveRequest
        {
            Id = 1,
            Name = "Alex Morgan",
            Address = "12 Oak Street",
            Department = "Information Technology",
            ContactInfo = "alex.morgan@company.example",
            From = "2026-06-15",
            To = "2026-06-17",
            Reason = "Family vacation",
            Status = "Approved"
        },
        new LeaveRequest
        {
            Id = 2,
            Name = "Alex Morgan",
            Address = "12 Oak Street",
            Department = "Information Technology",
            ContactInfo = "alex.morgan@company.example",
            From = "2026-11-09",
            To = "2026-11-10",
            Reason = "Personal appointment",
            Status = "Pending"
        },
        new LeaveRequest
        {
            Id = 3,
            Name = "Alex Morgan",
            Address = "12 Oak Street",
            Department = "Information Technology",
            ContactInfo = "alex.morgan@company.example",
            From = "2026-01-12",
            To = "2026-01-12",
            Reason = "Personal leave",
            Status = "Rejected"
        }
    ];

    public static IReadOnlyList<LeaveRequest> All => Requests;

    public static LeaveRequest Add(LeaveRequest request)
    {
        request.Id = Requests.Count == 0 ? 1 : Requests.Max(existing => existing.Id) + 1;
        Requests.Add(request);
        return request;
    }

    public static LeaveRequest? Find(int id) =>
        Requests.FirstOrDefault(request => request.Id == id);
}
