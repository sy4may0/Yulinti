using UnityEngine;
using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Regnum.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioCivisStatusCorporisMotus", menuName = "Yulinti/Rex/ConfiguratioCivisStatusCorporisMotus")]
    public class ConfiguratioCivisStatusCorporisMotus : ConfiguratioCivisStatusCorporisBasis, IConfiguratioCivisStatusCorporisMotus {
        [SerializeField] private IDCivisStatusCorporisModiMotus idModiMotus;

        public IDCivisStatusCorporisModiMotus IdModiMotus => idModiMotus;
    }
}