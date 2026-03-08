using UnityEngine;
using Yulinti.Unity.Contractus;

namespace Yulinti.Regnum.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioCivisAnimationum", menuName = "Yulinti/Rex/ConfiguratioCivisAnimationum")]
    public sealed class ConfiguratioCivisAnimationum : ScriptableObject, IConfiguratioCivisAnimationum {
        [SerializeField] private ConfiguratioCivisAnimationis[] animationes;

        public IConfiguratioCivisAnimationis[] Animationes => animationes;
    }
}
