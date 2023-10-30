namespace Imaginaria.Tests
{
    using TaxesService.TaxRuleEngine;
    using Xunit;

    public class TaxCalculatorRulesShould
    {
        private readonly IJurisdictionTaxes _jurisdictionTaxes = new SugerCountyJurisdictionTaxes();

        [Theory(DisplayName = "Pretax deduction rule")]
        [InlineData(980,0,0)]
        [InlineData(520, 10, 0)]
        [InlineData(1000,0,0)]
        [InlineData(1000,100,0)]
        [InlineData(3600,520,1360)]
        public void PreTaxDeductionRule(decimal grossIncome,decimal charitySpend,decimal expectedTax)
        {
            var rule = new PreTaxDeductionRule().CalculateTaxes(_jurisdictionTaxes, new TaxesService.ServiceModels.IncomeModel
            {
                CharitySpent = charitySpend,
                GrossIncome = grossIncome,
            });

            Assert.Equal(expectedTax, rule);

        }

        [Theory(DisplayName = "Income tax rule")]
        [InlineData(980, 0, 0)]
        [InlineData(520, 10, 0)]
        [InlineData(3400, 0, 240)]
        [InlineData(2500, 150, 135)]
        [InlineData(3600, 520, 224)]
        public void IncomeTaxRule(decimal grossIncome, decimal charitySpend, decimal expectedTax)
        {
            var rule = new IncomeTaxRule().CalculateTaxes(_jurisdictionTaxes, new TaxesService.ServiceModels.IncomeModel
            {
                CharitySpent = charitySpend,
                GrossIncome = grossIncome,
            });

            Assert.Equal(expectedTax, rule);
        }

        [Theory(DisplayName = "Social Contributions")]
        [InlineData(980, 0, 0)]
        [InlineData(520, 10, 0)]
        [InlineData(3400, 0, 300)]
        [InlineData(2500, 150, 202.5)]
        [InlineData(3600, 520, 300)]
        public void SocialContributinsRule (decimal grossIncome, decimal charitySpend, decimal expectedTax)
        {
            var rule = new SocialContributionRule().CalculateTaxes(_jurisdictionTaxes, new TaxesService.ServiceModels.IncomeModel
            {
                CharitySpent = charitySpend,
                GrossIncome = grossIncome,
            });

            Assert.Equal(expectedTax, rule);
        }

    }
}