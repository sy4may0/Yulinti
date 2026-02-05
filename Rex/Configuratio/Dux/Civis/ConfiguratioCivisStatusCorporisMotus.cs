using UnityEngine;
using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Rex {
    [CreateAssetMenu(fileName = "ConfiguratioCivisStatusCorporisMotus", menuName = "Yulinti/Rex/ConfiguratioCivisStatusCorporisMotus")]
    public class ConfiguratioCivisStatusCorporisMotus : ConfiguratioCivisStatusCorporisBasis, IConfiguratioCivisStatusCorporisMotus {
        [SerializeField] private IDCivisStatusCorporisModiMotus idModiMotus;

        public IDCivisStatusCorporisModiMotus IdModiMotus => idModiMotus;
    }
}