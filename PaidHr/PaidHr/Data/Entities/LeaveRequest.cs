namespace PaidHr.Data.Entities;

public class LeaveRequest
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public string Comment { get; set; }
    public string Status { get; set; }
    public string LeaveType { get; set; }
    public DateTime DateCreated { get; set; }
}