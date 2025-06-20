

using PaidHr.Interfaces;
using PaidHr.Repository;

namespace PaidHr.Services;

public class TaxService: ITaxService
{
    private readonly AppDbContext _context;

    // For simplicity, store a single tax rate here
    private decimal _currentTaxRate = 0.15m;

    public TaxService(AppDbContext context)
    {
        _context = context;
    }

    public Task<decimal> CalculateTaxAsync(decimal grossIncome)
    {
        var taxAmount = grossIncome * _currentTaxRate;
        return Task.FromResult(taxAmount);
    }

    public Task StoreTaxRateAsync(decimal rate)
    {
        _currentTaxRate = rate;
        return Task.CompletedTask;
    }
}