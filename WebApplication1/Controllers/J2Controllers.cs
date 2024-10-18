using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace J2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2Controller : ControllerBase
    {
        
        [HttpGet("ChiliPeppers")]
        public IActionResult CalculateSpiciness([FromQuery] string Ingredients)
        {
            
            Dictionary<string, int> pepperShu = new Dictionary<string, int>
            {
                { "Poblano", 1500 },
                { "Mirasol", 6000 },
                { "Serrano", 15500 },
                { "Cayenne", 40000 },
                { "Thai", 75000 },
                { "Habanero", 125000 }
            };

            int totalSpiciness = 0;

            // Split the Ingredients string into a list of peppers
            string[] peppers = Ingredients.Split(',');

            // Calculate total spiciness
            foreach (var pepper in peppers)
            {
                string trimmedPepper = pepper.Trim(); 
                if (pepperShu.ContainsKey(trimmedPepper))
                {
                    totalSpiciness += pepperShu[trimmedPepper];
                }
                else
                {
                    return BadRequest($"Invalid pepper name: {trimmedPepper}");
                }
            }

            // Return total spiciness as the response
            return Ok(totalSpiciness);
        }
         [HttpPost("Calculate")]
        public IActionResult CalculateShiftySum([FromForm] int number, [FromForm] int shifts)
        {
            int shiftySum = 0;
            for (int i = 0; i <= shifts; i++)
            {
                shiftySum += number * (int)Math.Pow(10, i); // Shift the number by i positions
            }
            return Ok(shiftySum);
        }
    }
}