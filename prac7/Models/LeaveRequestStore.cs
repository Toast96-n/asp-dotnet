namespace prac6.Models;

public static class LeaveRequestStore
{
    private static readonly List<LeaveRequest> Requests = [];

    public static IReadOnlyList<LeaveRequest> All => Requests;

    public static LeaveRequest Add(LeaveRequest request)
    {
        request.Id = Requests.Count + 1;
        Requests.Add(request);
        return request;
    }

    public static LeaveRequest? Find(int id) =>
        Requests.FirstOrDefault(request => request.Id == id);
}
