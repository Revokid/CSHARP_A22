using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace J1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1Controller : ControllerBase
    {
        [HttpPost(template: "delevedroid")]
        public int delevedroid([FromForm] int Deliveries, [FromForm] int Collisions)
        {
            int total = 0;
            int del = Deliveries * 50;
            int col = Collisions * 10;
            total = del - col;
            if (Deliveries > Collisions)
            {
                total = total + 500;
            }
            return total;
        }

        
         [HttpPost(template: "calculate")]
        public IActionResult CalculateBoilingPoint([FromForm] int Temperature)
        {
            // Calculate atmospheric pressure using the formula: P = 5 * T - 400
            int pressure = 5 * Temperature - 400;

            // Determine the sea level status
            int seaLevelStatus = 0;
            if (pressure < 100)
            {
                seaLevelStatus = 1;  // Above sea level
            }
            else if (pressure > 100)
            {
                seaLevelStatus = -1; // Below sea level
            }

            
            return Ok(new
            {
                Pressure = pressure,
                SeaLevelStatus = seaLevelStatus
            });
        }
    }
}