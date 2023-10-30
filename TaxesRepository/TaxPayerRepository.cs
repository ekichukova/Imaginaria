namespace TaxesRepository
{
    using System;
    using TaxesRepository.DatabaseModels;

    public class TaxPayerRepository : ITaxPayersRepository
    {
        private static List<TaxPayer> _taxPayers = new List<TaxPayer>();
        public TaxPayer GetTaxPayerBySSN(string SSN)
        {
            return _taxPayers?.FirstOrDefault(t => t.SSN == SSN);
        }

        public string AddTaxPayer(TaxPayer taxPayer)
        {
            if (GetTaxPayerBySSN(taxPayer.SSN)!=null)
            {
                // Do not provide the real reason for the exception.
                //throw new ArgumentException("Invalid tax payer.");
            }

            _taxPayers.Add(taxPayer);
            return taxPayer.SSN;
        }
    }
}

