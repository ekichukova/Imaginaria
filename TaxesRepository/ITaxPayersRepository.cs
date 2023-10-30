namespace TaxesRepository
{
    using TaxesRepository.DatabaseModels;

    public interface ITaxPayersRepository
    {
        public TaxPayer GetTaxPayerBySSN(string SSN);
        public string AddTaxPayer(TaxPayer taxPayer);
    }
}