namespace TaxesService.TaxRuleEngine
{
    public interface IJurisdictionTaxes
    {
        /// <summary>
        /// The minimum taxable amount.
        /// </summary>
        public decimal MinTaxableIncome { get;}

        /// <summary>
        /// The maximum amount the social contribution tax is applicable.
        /// </summary>
        public decimal SocialContributionMaxBaseAmount { get;}

        /// <summary>
        /// The income tax percentage.
        /// </summary>
        public decimal IncomeTaxPercent { get; }

        /// <summary>
        /// The max amount spent for charity in percentage.
        /// </summary>
        public decimal CharitySpentMaxPercentage { get; }

        /// <summary>
        /// The percentage for social contribution tax.
        /// </summary>
        public decimal SocialContributionPercentage { get; }
    }
}
