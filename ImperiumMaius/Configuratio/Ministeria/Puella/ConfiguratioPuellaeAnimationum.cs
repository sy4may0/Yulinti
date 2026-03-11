using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeAnimationum", menuName = "Yulinti/Configuratio/Ministeria/Puella/ConfiguratioPuellaeAnimationum")]
    public sealed class ConfiguratioPuellaeAnimationum : ScriptableObject, IConfiguratioPuellaeAnimationum {
        [SerializeField] private ConfiguratioPuellaeAnimationisBasis[] animationes;

        public IConfiguratioPuellaeAnimationis[] Animationes => animationes;
    }
}
