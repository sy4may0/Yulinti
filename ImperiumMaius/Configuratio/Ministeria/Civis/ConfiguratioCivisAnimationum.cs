using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioCivisAnimationum", menuName = "Yulinti/Configuratio/Ministeria/Civis/ConfiguratioCivisAnimationum")]
    public sealed class ConfiguratioCivisAnimationum : ScriptableObject, IConfiguratioCivisAnimationum {
        [SerializeField] private ConfiguratioCivisAnimationis[] animationes;

        public IConfiguratioCivisAnimationis[] Animationes => animationes;
    }
}
