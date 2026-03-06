using UnityEngine;
using Yulinti.Unity.Contractus;

namespace Yulinti.Regnum.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeAnimationum", menuName = "Yulinti/Rex/ConfiguratioPuellaeAnimationum")]
    public sealed class ConfiguratioPuellaeAnimationum : ScriptableObject, IConfiguratioPuellaeAnimationum {
        [SerializeField] private ConfiguratioPuellaeAnimationisBasis[] animationes;

        public IConfiguratioPuellaeAnimationis[] Animationes => animationes;
    }
}
