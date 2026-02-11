using UnityEngine;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus;

namespace Yulinti.Regnum.Configuratio {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeRelationisTerrae : IConfiguratioPuellaeRelationisTerrae {
        [SerializeField] private LayerMask raycastStratum;

        public LayerMask RaycastStratum => raycastStratum;
    }
}
