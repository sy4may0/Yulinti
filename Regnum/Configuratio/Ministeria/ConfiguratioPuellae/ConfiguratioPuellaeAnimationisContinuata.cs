using UnityEngine;
using Yulinti.Unity.Contractus;
using Yulinti.Exercitus.Contractus;

namespace Yulinti.Regnum.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeAnimationisContinuata", menuName = "Yulinti/Rex/ConfiguratioPuellaeAnimationisContinuata")]
    public sealed class ConfiguratioPuellaeAnimationisContinuata : ScriptableObject, IConfiguratioPuellaeAnimationisContinuata {
        [SerializeField] private IDPuellaeAnimationisStratum _stratum;
        [SerializeField] private IDPuellaeAnimationisContinuata _id;
        [SerializeField] private ConfiguratioPuellaeAnimationisBasis[] _animationes;

        public IDPuellaeAnimationisStratum Stratum => _stratum;
        public IDPuellaeAnimationisContinuata Id => _id;
        public IConfiguratioPuellaeAnimationisUnicae[] Animationes => _animationes;
    }
}