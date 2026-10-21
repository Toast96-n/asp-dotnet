namespace prac6.Models;

public static class AttendanceStore
{
    private static readonly List<AttendanceRecord> Records = [];
    private static readonly object SyncRoot = new();

    public static IReadOnlyList<AttendanceRecord> All
    {
        get
        {
            lock (SyncRoot)
            {
                return Records
                    .OrderByDescending(record => record.Date)
                    .ThenByDescending(record => record.CheckIn)
                    .ToList();
            }
        }
    }

    public static bool TryAddOrComplete(AttendanceRecord record)
    {
        lock (SyncRoot)
        {
            var existingRecord = Records.FirstOrDefault(existing =>
                    existing.Date.Date == record.Date.Date &&
                    string.Equals(existing.EmployeeName, record.EmployeeName, StringComparison.OrdinalIgnoreCase));
            if (existingRecord is not null)
            {
                if (existingRecord.CheckOut.HasValue || !record.CheckOut.HasValue)
                {
                    return false;
                }

                existingRecord.CheckOut = record.CheckOut;
                return true;
            }

            record.Id = Records.Count == 0 ? 1 : Records.Max(existing => existing.Id) + 1;
            Records.Add(record);
            return true;
        }
    }
}
