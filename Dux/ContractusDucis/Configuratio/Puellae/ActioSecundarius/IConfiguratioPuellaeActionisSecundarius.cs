using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioPuellaeActionisSecundarius {
        float RaycastAltitudo { get; }
        float RaycastDistantia { get; }
        float PesYCorrectivus { get; }
        float DigitusPedisYCorrectivus { get; }
        float MaxElevatio { get; }
    }
}
