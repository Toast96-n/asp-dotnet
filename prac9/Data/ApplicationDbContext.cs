using Microsoft.EntityFrameworkCore;
using prac6.Models;

namespace prac6.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    public DbSet<EmployeeRecord> Employees => Set<EmployeeRecord>();
}
