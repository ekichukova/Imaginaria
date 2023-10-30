namespace TaxesService.ServiceModels
{
    using System;

    public class TaxPayerModel
    {
        public string FullName { get; set; }
        public string SSN { get; set; }
        public decimal GrossIncome { get; set; }
        public decimal CharitySpent { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
