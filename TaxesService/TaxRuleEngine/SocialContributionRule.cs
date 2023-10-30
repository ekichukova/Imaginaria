namespace TaxesService.TaxRuleEngine
{
    using System;
    using TaxesService.ServiceModels;

    public class SocialContributionRule : ITaxRule
    {
        public decimal CalculateTaxes(IJurisdictionTaxes taxes, IncomeModel income)
        {
            var charityDeduction = new CharityTaxRule().CalculateTaxes(taxes, income);

            if (income.GrossIncome - charityDeduction <= taxes.MinTaxableIncome)
            {
                return 0;
            }

            var preTaxDeductions = new PreTaxDeductionRule().CalculateTaxes(taxes, income);

            var maxSocialTaxableBaseAmount = taxes.SocialContributionMaxBaseAmount - taxes.MinTaxableIncome;
            var taxableBaseAmount = income.GrossIncome - preTaxDeductions;

            var socialContributionTaxBase = Math.Min(taxableBaseAmount, maxSocialTaxableBaseAmount);

            return Math.Round(socialContributionTaxBase * taxes.SocialContributionPercentage / 100, 2);
        }
    }
}
