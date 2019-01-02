using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Remotion.Linq.Utilities;

namespace RestWithASPNET.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        // GET api/values/5
        [HttpGet("sum/{firstNumber}/{secundNumber}")]
        public IActionResult Sum(string firstNumber, string secundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secundNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secundNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        // GET api/values/5
        [HttpGet("subtraction/{firstNumber}/{secundNumber}")]
        public IActionResult Subtraction(string firstNumber, string secundNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secundNumber))
            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secundNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string number)
        {
            decimal decimalValue;

            if (decimal.TryParse(number, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool IsNumeric(string strNumber)
        {
            double number;

            bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out number);

            return isNumber;
        }

    }
}
