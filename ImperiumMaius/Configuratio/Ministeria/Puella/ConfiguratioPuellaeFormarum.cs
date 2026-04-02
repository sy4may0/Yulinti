using UnityEngine;
using Yulinti.Officia.Contractus;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeFormarum", menuName = "Yulinti/Configuratio/Ministeria/Puella/ConfiguratioPuellaeFormarum")]
    public sealed class ConfiguratioPuellaeFormarum : ScriptableObject, IConfiguratioPuellaeFormarum {
        [SerializeField] private ConfiguratioPuellaeFormaeOssis[] _ossa;
        [SerializeField] private ConfiguratioPuellaeFormaeFigurae[] _figurae;

        public IConfiguratioPuellaeFormaeOssis[] Ossa => _ossa;
        public IConfiguratioPuellaeFormaeFigurae[] Figurae => _figurae;
    }
}