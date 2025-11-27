using UnityEngine;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public interface IPunctumViae {
        IDPunctumViaeTypi Typus { get; }
        bool EstActivum { get; }
        Vector3 Positio { get; }
        void PonoResolvor(IResolvorPunctumViae resolvorPunctumViae);
        void Activare();
        void Deactivare();
        ErrorAut<IPunctumViae> Resolvo(IPunctumViae pAntecedens);
        void Initio();
    }
}