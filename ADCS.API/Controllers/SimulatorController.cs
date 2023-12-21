using ADCS.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ADCS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimulatorController : ControllerBase
    {
        [HttpPost]
        public async Task<Simulation> Execute([FromBody] Instruction instruction)
        {
            throw new NotImplementedException();
        }
    }
}
