namespace TaxesService.TaxRuleEngine
{
    using TaxesService.ServiceModels;

    public class PreTaxDeductionRule : ITaxRule
    {
        public decimal CalculateTaxes(IJurisdictionTaxes taxes, IncomeModel income)
        {
            var charityRule = new CharityTaxRule();
            var charityDeduction = charityRule.CalculateTaxes(taxes, income);

            if (income.GrossIncome - charityDeduction <= taxes.MinTaxableIncome)
            {
                return 0;
            }
            else
            {
                return taxes.MinTaxableIncome + charityDeduction;
            }
        }
    }
}
