using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeFormarum", menuName = "Yulinti/Configuratio/Exercitus/Puella/ConfiguratioPuellaeFormarum")]
    public sealed class ConfiguratioPuellaeFormarum : ScriptableObject, IConfiguratioPuellaeFormarum {
        [SerializeField] private ConfiguratioPuellaeFormae[] formarum;

        public IConfiguratioPuellaeFormae[] Formarum => formarum;
    }
}