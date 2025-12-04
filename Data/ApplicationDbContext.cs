using Iyde.Attendance.Variant3.Models;
using Microsoft.EntityFrameworkCore;

namespace Iyde.Attendance.Variant3.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Store> Stores => Set<Store>();
    public DbSet<Attendances> Attendances => Set<Attendances>();
    public DbSet<WorkDay> WorkDays => Set<WorkDay>();
}