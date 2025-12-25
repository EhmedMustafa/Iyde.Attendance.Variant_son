using Iyde.Attendance.Variant3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Iyde.Attendance.Variant3.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Store> Stores => Set<Store>();
    public DbSet<Attendances> Attendances => Set<Attendances>();
    public DbSet<WorkDay> WorkDays => Set<WorkDay>();

    public DbSet<AttendanceEarlyAttempt> AttendanceEarlyAttempts => Set<AttendanceEarlyAttempt>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AttendanceEarlyAttempt>()
            .HasOne(x => x.Employee)
            .WithMany()
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<AttendanceEarlyAttempt>()
            .HasOne(x => x.Store)
            .WithMany()
            .HasForeignKey(x => x.StoreId)
            .OnDelete(DeleteBehavior.Restrict);

        var dateOnlyConverter = new ValueConverter<DateOnly, DateTime>(
           d => d.ToDateTime(TimeOnly.MinValue),
           d => DateOnly.FromDateTime(d)
       );

        modelBuilder.Entity<WorkDay>()
            .Property(w => w.Date)
            .HasConversion(dateOnlyConverter);
    }

}