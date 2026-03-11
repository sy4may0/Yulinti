using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.Imperium.Configuratio {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeRelationis : IConfiguratioPuellaeRelationis {
        [SerializeField] private ConfiguratioPuellaeRelationisTerrae terrae;

        public IConfiguratioPuellaeRelationisTerrae Terrae => terrae;
    }
}
