using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public interface IResolvorPunctumViae {
        ErrorAut<IPunctumViae> Resolvo(
            IPunctumViae pAntecedens,
            IPunctumViae[] pConsequens
        );
    }
}