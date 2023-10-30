namespace TaxesService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TaxesRepository;
    using TaxesRepository.DatabaseModels;
    using TaxesService.ServiceModels;
    using TaxesService.TaxRuleEngine;

    public class TaxCalculatorService : ITaxCalculatorService
    {
        private readonly ITaxPayersRepository _taxPayersRepository;
        private readonly IJurisdictionTaxes _jurisdictionTaxes;
        public TaxCalculatorService(ITaxPayersRepository taxPayersRepository, IJurisdictionTaxes jurisdictionTaxes)
        {
            _taxPayersRepository = taxPayersRepository;
            _jurisdictionTaxes = jurisdictionTaxes;
        }

        public Taxes Calculate(TaxPayerModel model)
        {
            _taxPayersRepository.AddTaxPayer(
                new TaxPayer
                {
                    FullName = model.FullName,
                    CharitySpent = model.CharitySpent,
                    DateOfBirth = model.DateOfBirth,
                    GrossIncome = model.GrossIncome,
                    SSN = model.SSN,
                });


            var incomeTaxDeduction = new IncomeTaxRule().CalculateTaxes(_jurisdictionTaxes, new IncomeModel
            {
                GrossIncome = model.GrossIncome,
                CharitySpent = model.CharitySpent
            });

            var socialContributionTaxDeduction = new SocialContributionRule().CalculateTaxes(_jurisdictionTaxes, new IncomeModel
            {
                GrossIncome = model.GrossIncome,
                CharitySpent = model.CharitySpent
            });

            return new Taxes
            {
                GrossIncome = model.GrossIncome,
                CharitySpent = model.CharitySpent,
                IncomeTax = incomeTaxDeduction,
                SocialTax = socialContributionTaxDeduction,
                TotalTax = incomeTaxDeduction + socialContributionTaxDeduction,
                NetIncome = model.GrossIncome - (incomeTaxDeduction + socialContributionTaxDeduction)
            };
        }
    }
}
