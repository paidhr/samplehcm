using Microsoft.AspNetCore.Mvc;
using PaidHr.Interfaces;

namespace PaidHr.Client;

[ApiController]
[Route("api/[controller]")]
public class PayrollController : ControllerBase
{
    private readonly IPayrollService _payrollService;

    public PayrollController(IPayrollService payrollService)
    {
        _payrollService = payrollService;
    }

    [HttpPost("process/{employeeId}")]
    public async Task<IActionResult> ProcessPayroll(int employeeId)
    {
        var payroll = await _payrollService.ProcessPayrollAsync(employeeId);
        return Ok(payroll);
    }

    [HttpGet("{payrollId}/netpay")]
    public async Task<IActionResult> CalculateNetPay(int payrollId)
    {
        var netPay = await _payrollService.CalculateNetPayAsync(payrollId);
        return Ok(netPay);
    }
}