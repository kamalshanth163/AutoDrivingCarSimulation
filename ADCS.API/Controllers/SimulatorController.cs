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

        [HttpPost]
        public Simulation Execute([FromBody] Instruction instruction)
        {
            return _simulatorService.Execute(instruction);
        }
    }
}
