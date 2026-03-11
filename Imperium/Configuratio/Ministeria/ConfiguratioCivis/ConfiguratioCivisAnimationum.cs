using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.Imperium.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioCivisAnimationum", menuName = "Yulinti/Rex/ConfiguratioCivisAnimationum")]
    public sealed class ConfiguratioCivisAnimationum : ScriptableObject, IConfiguratioCivisAnimationum {
        [SerializeField] private ConfiguratioCivisAnimationis[] animationes;

        public IConfiguratioCivisAnimationis[] Animationes => animationes;
    }
}
