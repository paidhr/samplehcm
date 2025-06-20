using Microsoft.EntityFrameworkCore;
using PaidHr.Data.Entities;

namespace PaidHr.Repository;

public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Payroll> Payrolls { get; set; }
    public DbSet<Salary> Salaries { get; set; }
    public DbSet<Tax> Taxes { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.BankAccount)
            .WithOne(b => b.Employee)
            .HasForeignKey<BankAccount>(b => b.EmployeeId);

        modelBuilder.Entity<Employee>()
            .HasMany(e => e.Payrolls)
            .WithOne(p => p.Employee);

        modelBuilder.Entity<Employee>()
            .HasMany(e => e.LeaveRequests)
            .WithOne(l => l.Employee);

        modelBuilder.Entity<Payroll>()
            .HasOne(p => p.Salary)
            .WithOne(s => s.Payroll)
            .HasForeignKey<Salary>(s => s.PayrollId);

        modelBuilder.Entity<Payroll>()
            .HasMany(p => p.Taxes)
            .WithOne(t => t.Payroll);
    }
}