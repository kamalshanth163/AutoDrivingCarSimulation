using ADCS.Domain;

namespace ADCS.Application
{
    public interface ISimulatorService
    {
        Simulation Execute(Instruction instruction);
    }
}
