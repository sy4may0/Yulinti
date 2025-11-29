using UnityEngine;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal interface ICivis {
        void Oriri();
        void Evanescere();
        void IncipereMigrare();
        void Migrare();
        bool EstAdPerveni();
        void Transporto(Vector3 positio);

        bool EstActivum { get; }
        Vector3 LegoPositionem { get; }
        Quaternion LegoRotationem { get; }
        Vector3 LegoScalam { get; }
    }
}