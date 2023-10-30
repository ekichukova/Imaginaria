namespace TaxesApi
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using TaxesApi.RequestModels;
    using TaxesService;
    using TaxesService.ServiceModels;

    public class CalculatorController : ControllerBase
    {
        private readonly ITaxCalculatorService _taxCalculator;
        public CalculatorController(ITaxCalculatorService taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        [HttpGet("calculate")]
        public IActionResult Calculate(TaxPayerRequest request)
        {
            try
            {
                var taxes = _taxCalculator.Calculate(new TaxPayerModel
                {
                    FullName = request.FullName,
                    SSN = request.SSN,
                    GrossIncome = request.GrossIncome.Value,
                    CharitySpent = request.CharitySpent,
                    DateOfBirth = request.BirthDate

                });

                return CreatedAtAction(nameof(Calculate), taxes);
            }
            catch (ArgumentException argEx)
            {
                return BadRequest(argEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }
    }
}
