using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.Imperium.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeAnimationum", menuName = "Yulinti/Rex/ConfiguratioPuellaeAnimationum")]
    public sealed class ConfiguratioPuellaeAnimationum : ScriptableObject, IConfiguratioPuellaeAnimationum {
        [SerializeField] private ConfiguratioPuellaeAnimationisBasis[] animationes;

        public IConfiguratioPuellaeAnimationis[] Animationes => animationes;
    }
}
