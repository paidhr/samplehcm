namespace PaidHr.Interfaces;

public interface ITaxService
{
    Task<decimal> CalculateTaxAsync(decimal grossIncome);
    Task StoreTaxRateAsync(decimal rate);
}