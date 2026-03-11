using UnityEngine;
using Yulinti.Officia.Contractus;

using Yulinti.ImperiumDelegatum.Contractus;
namespace Yulinti.Imperium.Configuratio {
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