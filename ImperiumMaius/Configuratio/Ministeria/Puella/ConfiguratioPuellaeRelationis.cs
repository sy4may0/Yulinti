using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeRelationis", menuName = "Yulinti/Configuratio/Ministeria/Puella/ConfiguratioPuellaeRelationis")]
    public sealed class ConfiguratioPuellaeRelationis : ScriptableObject, IConfiguratioPuellaeRelationis {
        [SerializeField] private ConfiguratioPuellaeRelationisTerrae terrae;

        public IConfiguratioPuellaeRelationisTerrae Terrae => terrae;
    }
}
