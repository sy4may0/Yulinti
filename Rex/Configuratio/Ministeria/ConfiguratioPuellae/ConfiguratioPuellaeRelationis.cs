using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Rex {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeRelationis : IConfiguratioPuellaeRelationis {
        [SerializeField] private ConfiguratioPuellaeRelationisTerrae terrae;

        public IConfiguratioPuellaeRelationisTerrae Terrae => terrae;
    }
}
