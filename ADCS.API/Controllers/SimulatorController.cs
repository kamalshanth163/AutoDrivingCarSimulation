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

        // Returns current position of the Car

        [HttpPost("execution")]
        public async Task<string> Execute([FromBody] Instruction instruction) 
        {
            var simulation = await _simulatorService.Execute(instruction);
            return simulation.CarEnd.GetCurrentPosition();
        }

        // Returns detailed information (Field, Initial and Current Positions of the Car)

        [HttpPost("detailed-execution")]
        public async Task<Simulation> DetailedExecute([FromBody] Instruction instruction) 
        {
            return await _simulatorService.Execute(instruction);
        }
    }
}
