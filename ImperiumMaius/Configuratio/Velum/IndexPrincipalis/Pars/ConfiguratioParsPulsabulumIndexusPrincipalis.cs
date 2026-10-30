using UnityEngine;
using Yulinti.Auctoritas.Contractus;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;
using UnityEngine.UIElements;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioParsPulsabulumIndexusPrincipalis", menuName = "Yulinti/Configuratio/Velum/IndexPrincipalis/Pars/ConfiguratioParsPulsabulumIndexusPrincipalis")]
    public sealed class ConfiguratioParsPulsabulumIndexusPrincipalis : ScriptableObject, IConfiguratioParsPulsabulumIndexusPrincipalis {
        [SerializeField] private UsusIndexusPrincipalis _usus;
        [SerializeField] private int _magnitudoLitterarum = 48;
        [SerializeField] private IDTextus _textus;
        [SerializeField] private VisualTreeAsset _examplar;

        public UsusIndexusPrincipalis Usus => _usus;
        public int MagnitudoLitterarum => _magnitudoLitterarum;
        public IDTextus Textus => _textus;
        public VisualTreeAsset Examplar => _examplar;
    }
}
