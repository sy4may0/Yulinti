using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Contractus {
    public interface IConfiguratioPuellaeActionisSecundarius {
        float RaycastAltitudo { get; }
        float RaycastDistantia { get; }
        float PesYCorrectivus { get; }
        float DigitusPedisYCorrectivus { get; }
        float MaxElevatio { get; }
    }
}
