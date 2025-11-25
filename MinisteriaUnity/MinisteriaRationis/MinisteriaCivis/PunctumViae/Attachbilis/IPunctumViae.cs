using UnityEngine;
namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public interface IPunctumViae {
        IDPunctumViaeTypi Typus { get; };
        bool EstActivum { get; };
        Vector3 Positio { get; };
        void PonoResolvor(IResolvorPunctumViae resolvorPunctumViae);
        void Activare();
        void Deactivare();
        ErrorAut<IPunctumViae> Resolvo(IPunctumViae pAntecedens);
    }
}