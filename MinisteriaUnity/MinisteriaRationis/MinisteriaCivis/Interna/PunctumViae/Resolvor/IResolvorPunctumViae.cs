using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal interface IResolvorPunctumViae {
        ErrorAut<PunctumViae> Resolvo(
            PunctumViae pAntecedens,
            PunctumViae[] pConsequens
        );
    }
}


