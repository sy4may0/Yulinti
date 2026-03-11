using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.Imperium.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioCivisStatusCorporisMotus", menuName = "Yulinti/Rex/ConfiguratioCivisStatusCorporisMotus")]
    public class ConfiguratioCivisStatusCorporisMotus : ConfiguratioCivisStatusCorporisBasis, IConfiguratioCivisStatusCorporisMotus {
        [SerializeField] private IDCivisStatusCorporisModiMotus idModiMotus;

        public IDCivisStatusCorporisModiMotus IdModiMotus => idModiMotus;
    }
}