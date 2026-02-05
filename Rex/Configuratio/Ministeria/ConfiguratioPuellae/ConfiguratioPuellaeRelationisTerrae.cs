using UnityEngine;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus;

namespace Yulinti.Rex {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeRelationisTerrae : IConfiguratioPuellaeRelationisTerrae {
        [SerializeField] private LayerMask raycastStratum;

        public NihilAut<LayerMask> RaycastStratum => new NihilAut<LayerMask>(raycastStratum);
    }
}
