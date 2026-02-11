using UnityEngine;
using Yulinti.Unity.Contractus;

using Yulinti.Exercitus.Contractus;
namespace Yulinti.Regnum.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPunctumViae", menuName = "Yulinti/Rex/ConfiguratioPunctumViae")]
    public sealed class ConfiguratioPunctumViae : ScriptableObject, IConfiguratioPunctumViae {
        [SerializeField] private IDPunctumViaeTypi[] _crematorium;
        [SerializeField] private IDPunctumViaeTypi[] _natorium;
        [SerializeField] private IDPunctumViaeTypi[] _aditrium;

        public IDPunctumViaeTypi[] Crematorium => _crematorium;
        public IDPunctumViaeTypi[] Natorium => _natorium;
        public IDPunctumViaeTypi[] Aditrium => _aditrium;
    }
}