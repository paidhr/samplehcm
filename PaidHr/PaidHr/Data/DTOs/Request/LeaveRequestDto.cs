namespace PaidHr.Data.DTOs.Request;

public class LeaveRequestDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int EmployeeId { get; set; }
    public string Comment { get; set; }
    public string Status { get; set; }
    public string LeaveType { get; set; }
}