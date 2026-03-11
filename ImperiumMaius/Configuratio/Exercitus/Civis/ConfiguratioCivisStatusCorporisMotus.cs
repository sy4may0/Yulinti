using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioCivisStatusCorporisMotus", menuName = "Yulinti/Configuratio/Exercitus/Civis/ConfiguratioCivisStatusCorporisMotus")]
    public class ConfiguratioCivisStatusCorporisMotus : ConfiguratioCivisStatusCorporisBasis, IConfiguratioCivisStatusCorporisMotus {
        [SerializeField] private IDCivisStatusCorporisModiMotus idModiMotus;

        public IDCivisStatusCorporisModiMotus IdModiMotus => idModiMotus;
    }
}