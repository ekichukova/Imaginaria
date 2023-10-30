namespace TaxesService.TaxRuleEngine
{
    using TaxesService.ServiceModels;

    public interface ITaxRule
    {
        public decimal CalculateTaxes(IJurisdictionTaxes taxes, IncomeModel income);
    }
}
