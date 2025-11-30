using UnityEngine;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal interface ICivis {
        void Oriri();
        void Evanescere();
        ICivisLociNavMesh NavMesh { get; }

        bool EstActivum { get; }
        Vector3 LegoPositionem { get; }
        Quaternion LegoRotationem { get; }
        Vector3 LegoScalam { get; }
    }
}


