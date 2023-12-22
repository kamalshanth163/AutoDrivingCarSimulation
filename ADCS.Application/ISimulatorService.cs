using ADCS.Domain;

namespace ADCS.Application
{
    public interface ISimulatorService
    {
        Task<Simulation> Execute(Instruction instruction);
    }
}
