using PaidHr.Data.DTOs.Request;
using PaidHr.Data.Entities;

namespace PaidHr.Interfaces;

public interface ILeaveManagementService
{
    Task<LeaveRequest> SubmitLeaveRequestAsync(LeaveRequestDto leaveRequest);
    Task ApproveLeaveRequestAsync(int leaveRequestId);
    Task RejectLeaveRequestAsync(int leaveRequestId);
    Task<IEnumerable<LeaveRequest>> GetLeaveRequest(int employeeId);
}