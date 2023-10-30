namespace TaxesService
{
    using TaxesService.ServiceModels;

    public interface ITaxCalculatorService
    {
        public Taxes Calculate(TaxPayerModel model);
    }
}
