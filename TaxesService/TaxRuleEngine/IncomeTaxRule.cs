namespace TaxesService.TaxRuleEngine
{
    using System;
    using TaxesService.ServiceModels;

    public class IncomeTaxRule : ITaxRule
    {
        public decimal CalculateTaxes(IJurisdictionTaxes taxes, IncomeModel income)
        {

            var charityDeduction = new CharityTaxRule().CalculateTaxes(taxes, income);

            if (income.GrossIncome - charityDeduction <= taxes.MinTaxableIncome)
            {
                return 0;
            }

            var preTaxDeductions = new PreTaxDeductionRule().CalculateTaxes(taxes, income);
            var incomeTaxBase = income.GrossIncome - preTaxDeductions;
            return Math.Round(incomeTaxBase * taxes.IncomeTaxPercent / 100, 2);

        }
    }
}
