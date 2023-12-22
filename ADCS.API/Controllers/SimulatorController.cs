using ADCS.Application;
using ADCS.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ADCS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimulatorController : ControllerBase
    {
        private readonly ISimulatorService _simulatorService;
        public SimulatorController(ISimulatorService simulatorService)
        {
            _simulatorService = simulatorService;
        }


        [HttpPost("{detailed}")]
        public async Task<ActionResult> Execute([FromBody] Instruction instruction, bool detailed = false) 
        {
            var simulation = await _simulatorService.Execute(instruction);

            if (detailed)
            {
                // Returns detailed information (Field, Initial and Current Positions of the Car)
                return Ok(simulation);
            }

            // Returns current position of the Car
            return Ok(simulation.CarEnd.GetCurrentPosition());
        }
    }
}
