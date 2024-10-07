using Microsoft.AspNetCore.Mvc;
using CalculatorAPI.Interfaces;

namespace CalculatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpGet("add")]
        public IActionResult Add(double a, double b)
        {
            var result = _calculatorService.Add(a, b);
            return Ok("Sum: "+result);
        }

        [HttpGet("subtract")]
        public IActionResult Subtract(double a, double b)
        {
            var result = _calculatorService.Subtract(a, b);
            
            if (result < 0) {
                return BadRequest("Result is Negative. "+result);
            }
            return Ok("Difference: "+result);
        }

        [HttpGet("multiply")]
        public IActionResult Multiply(double a, double b)
        {
            var result = _calculatorService.Multiply(a, b);
            return Ok("Product: "+result);
        }

        [HttpGet("divide")]
        public IActionResult Divide(double a, double b)
        {
            try
            {
                var result = _calculatorService.Divide(a, b);
                return Ok("Quotient: "+result);
            }
            catch (DivideByZeroException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
