namespace TaxesService.TaxRuleEngine
{
    public class SugerCountyJurisdictionTaxes : IJurisdictionTaxes
    {
        public decimal MinTaxableIncome => 1000;

        public decimal SocialContributionMaxBaseAmount => 3000;

        public decimal IncomeTaxPercent => 10;

        public decimal CharitySpentMaxPercentage => 10;

        public decimal SocialContributionPercentage => 15;
    }
}
