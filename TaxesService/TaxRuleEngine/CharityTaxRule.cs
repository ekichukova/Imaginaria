namespace TaxesService.TaxRuleEngine
{
    using System;
    using TaxesService.ServiceModels;

    public class CharityTaxRule : ITaxRule
    {
        public decimal CalculateTaxes(IJurisdictionTaxes taxes, IncomeModel income)
        {
            var maxCharityDeductableAmmount = Math.Round(taxes.CharitySpentMaxPercentage * income.GrossIncome / 100, 2);
            if (income.CharitySpent > maxCharityDeductableAmmount)
            {
                return maxCharityDeductableAmmount;
            }
            else
            {
                return income.CharitySpent;
            }
        }
    }
}
