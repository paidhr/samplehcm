using Microsoft.AspNetCore.Mvc;
using PaidHr.Data.DTOs.Request;
using PaidHr.Data.Entities;
using PaidHr.Interfaces;

namespace PaidHr.Client;

[ApiController]
[Route("api/[controller]")]
public class LeaveRequestsController : ControllerBase
{
    private readonly ILeaveManagementService _leaveService;

    public LeaveRequestsController(ILeaveManagementService leaveService)
    {
        _leaveService = leaveService;
    }

    [HttpPost]
    public async Task<IActionResult> SubmitLeaveRequest(LeaveRequestDto request)
    {
        var result = await _leaveService.SubmitLeaveRequestAsync(request);
        return Ok(result);
    }

    [HttpPost("{leaveRequestId}/approve")]
    public async Task<IActionResult> Approve(int leaveRequestId)
    {
        await _leaveService.ApproveLeaveRequestAsync(leaveRequestId);
        return NoContent();
    }

    [HttpPost("{leaveRequestId}/reject")]
    public async Task<IActionResult> Reject(int leaveRequestId)
    {
        await _leaveService.RejectLeaveRequestAsync(leaveRequestId);
        return NoContent();
    }

    [HttpGet("{employeeId}")]
    public async Task<IActionResult> LeaveRequest(int employeeId)
    {
        var result = await _leaveService.GetLeaveRequest(employeeId);
        return Ok(result);
    }
}