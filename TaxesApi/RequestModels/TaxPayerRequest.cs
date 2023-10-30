namespace TaxesApi.RequestModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TaxPayerRequest
    {
      //  [Required]
        [RegularExpression("^([a-zA-Z]{2,}\\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\\s?([a-zA-Z]{1,})?)", ErrorMessage = "Invalid name.")]
        public string FullName { get; set; } = "Emiliya Kichukova";
        public DateTime? BirthDate { get; set; } = DateTime.Now;

      //  [Required]
        public decimal? GrossIncome { get; set; }

       // [Required(AllowEmptyStrings = false)]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "The SSN should be between 5 and 10 characters long.")]
        public string SSN { get; set; } = "123456";
        public decimal CharitySpent { get; set; }

    }
}
