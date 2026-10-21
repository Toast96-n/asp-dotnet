namespace prac6.Models;

public class TrainingProgram
{
    public int Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public string Location { get; init; } = string.Empty;
    public int Capacity { get; init; }
    public int Registered { get; set; }
}

public class TrainingCertificate
{
    public string Course { get; init; } = string.Empty;
    public DateTime CompletedOn { get; init; }
    public string CertificateId { get; init; } = string.Empty;
}

public static class TrainingStore
{
    private static readonly List<TrainingProgram> Programs =
    [
        new TrainingProgram
        {
            Id = 1,
            Title = "Secure Software Development",
            Description = "Practical secure coding patterns, threat modeling, and application security basics.",
            StartDate = new DateTime(2026, 11, 12),
            EndDate = new DateTime(2026, 11, 13),
            Location = "Room 204 / Online",
            Capacity = 20,
            Registered = 12
        },
        new TrainingProgram
        {
            Id = 2,
            Title = "Communication and Collaboration",
            Description = "Build effective communication habits for cross-functional teams.",
            StartDate = new DateTime(2026, 11, 20),
            EndDate = new DateTime(2026, 11, 20),
            Location = "Learning Center",
            Capacity = 18,
            Registered = 18
        },
        new TrainingProgram
        {
            Id = 3,
            Title = "Cloud Fundamentals",
            Description = "An introduction to cloud architecture, operations, and cost awareness.",
            StartDate = new DateTime(2026, 12, 3),
            EndDate = new DateTime(2026, 12, 4),
            Location = "Online",
            Capacity = 25,
            Registered = 9
        }
    ];

    public static IReadOnlyList<TrainingProgram> ProgramsList => Programs;

    public static IReadOnlyList<TrainingCertificate> Certificates { get; } =
    [
        new TrainingCertificate
        {
            Course = "Workplace Safety Essentials",
            CompletedOn = new DateTime(2026, 3, 18),
            CertificateId = "CERT-2026-0318"
        },
        new TrainingCertificate
        {
            Course = "Introduction to Data Privacy",
            CompletedOn = new DateTime(2026, 5, 22),
            CertificateId = "CERT-2026-0522"
        }
    ];

    public static TrainingProgram? Find(int id) =>
        Programs.FirstOrDefault(program => program.Id == id);

    public static bool TryRegister(int id)
    {
        var program = Find(id);
        if (program is null || program.Registered >= program.Capacity)
        {
            return false;
        }

        program.Registered++;
        return true;
    }
}
