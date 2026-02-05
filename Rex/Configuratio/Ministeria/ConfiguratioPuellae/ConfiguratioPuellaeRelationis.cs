using UnityEngine;
using Yulinti.Unity.Contractus;

namespace Yulinti.Rex {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeRelationis : IConfiguratioPuellaeRelationis {
        [SerializeField] private ConfiguratioPuellaeRelationisTerrae terrae;

        public IConfiguratioPuellaeRelationisTerrae Terrae => terrae;
    }
}
