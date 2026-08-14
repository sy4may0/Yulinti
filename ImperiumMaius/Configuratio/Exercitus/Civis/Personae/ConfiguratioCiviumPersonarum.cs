using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(
        fileName = "ConfiguratioCiviumPersonarum",
        menuName = "Yulinti/Configuratio/Exercitus/Civis/Personae/CiviumPersonarum")]
    public sealed class ConfiguratioCiviumPersonarum : ScriptableObject, IConfiguratioCiviumPersonarum {
        [SerializeField] private ConfiguratioCivisPersonae[] configurationes;

        public IConfiguratioCivisPersonae[] Configurationes => configurationes;
    }
}