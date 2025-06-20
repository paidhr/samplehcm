namespace PaidHr.Data.Entities;

public class Payroll
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public int SalaryId { get; set; }
    public Salary Salary { get; set; }
    public ICollection<Tax> Taxes { get; set; } = new List<Tax>();
    public DateTime DateCreated { get; set; }
    public bool IsProcessed { get; set; }
}