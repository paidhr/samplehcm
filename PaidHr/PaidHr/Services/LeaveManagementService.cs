

using Microsoft.EntityFrameworkCore;
using PaidHr.Data.DTOs.Request;
using PaidHr.Data.Entities;
using PaidHr.Interfaces;
using PaidHr.Repository;

namespace PaidHr.Services;

public class LeaveManagementService : ILeaveManagementService
{
    private readonly AppDbContext _context;

    public LeaveManagementService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<LeaveRequest> SubmitLeaveRequestAsync(LeaveRequestDto leaveRequestDto)
    {
        var leaveRequest = new LeaveRequest()
        {
            EmployeeId = leaveRequestDto.EmployeeId,
            StartDate = leaveRequestDto.StartDate,
            EndDate = leaveRequestDto.EndDate,
            Comment = leaveRequestDto.Comment,
            Status = "Pending",
            DateCreated = DateTime.Now,
            LeaveType = leaveRequestDto.LeaveType,
        };
        _context.LeaveRequests.Add(leaveRequest);
        await _context.SaveChangesAsync();
        return leaveRequest;
    }

    public async Task ApproveLeaveRequestAsync(int leaveRequestId)
    {
        var leave = await _context.LeaveRequests.FindAsync(leaveRequestId);
        if (leave != null)
        {
            leave.Status = "Approved";
            await _context.SaveChangesAsync();
        }
    }

    public async Task RejectLeaveRequestAsync(int leaveRequestId)
    {
        var leave = await _context.LeaveRequests.FindAsync(leaveRequestId);
        if (leave != null)
        {
            leave.Status = "Rejected";
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task<IEnumerable<LeaveRequest>> GetLeaveRequest(int employeeId)
    {
        var leave = await _context.LeaveRequests.Where(x =>x.EmployeeId==employeeId).ToListAsync();
        return leave;
    }

}