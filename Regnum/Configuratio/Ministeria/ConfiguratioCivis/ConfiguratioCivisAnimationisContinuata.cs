using UnityEngine;
using Yulinti.Unity.Contractus;
using Yulinti.Exercitus.Contractus;

namespace Yulinti.Regnum.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioCivisAnimationisContinuata", menuName = "Yulinti/Rex/ConfiguratioCivisAnimationisContinuata")]
    public sealed class ConfiguratioCivisAnimationisContinuata : ScriptableObject, IConfiguratioCivisAnimationisContinuata {
        [SerializeField] private IDCivisAnimationisStratum stratum;
        [SerializeField] private IDCivisAnimationisContinuata id;
        [SerializeField] private ConfiguratioCivisAnimationisBasis[] animationes;

        public IDCivisAnimationisStratum Stratum => stratum;
        public IDCivisAnimationisContinuata Id => id;
        public IConfiguratioCivisAnimationisUnicae[] Animationes => animationes;
    }
}