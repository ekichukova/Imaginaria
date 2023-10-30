namespace TaxesService.ServiceModels
{
    public class Taxes
    {
        /// <summary>
        /// The amount of the gross income.
        /// </summary>
        public decimal GrossIncome { get; set; }

        /// <summary>
        /// The entire amount of the charity spent (even if not entirely accounted for).
        /// </summary>
        public decimal CharitySpent { get; set; }

        /// <summary>
        /// The amount of the income tax.
        /// </summary>
        public decimal IncomeTax { get; set; }

        /// <summary>
        /// The amount of the social tax.
        /// </summary>
        public decimal SocialTax { get; set; }

        /// <summary>
        /// The amount of the total tax to be paid.
        /// </summary>
        public decimal TotalTax { get; set; }

        /// <summary>
        /// The amount remaining for the taxpayer after the taxes.
        /// </summary>
        public decimal NetIncome { get; set; }
    }
}
