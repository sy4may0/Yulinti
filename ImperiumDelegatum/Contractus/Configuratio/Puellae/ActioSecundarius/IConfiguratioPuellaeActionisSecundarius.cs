using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IConfiguratioPuellaeActionisSecundarius {
        float RaycastAltitudo { get; }
        float RaycastDistantia { get; }
        float PesYCorrectivus { get; }
        float DigitusPedisYCorrectivus { get; }
        float MaxElevatio { get; }
    }
}
