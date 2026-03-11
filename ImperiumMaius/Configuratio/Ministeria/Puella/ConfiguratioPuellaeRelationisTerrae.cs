using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeRelationisTerrae : IConfiguratioPuellaeRelationisTerrae {
        [SerializeField] private LayerMask raycastStratum;

        public LayerMask RaycastStratum => raycastStratum;
    }
}
