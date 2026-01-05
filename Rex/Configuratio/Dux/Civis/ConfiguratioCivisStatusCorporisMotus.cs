using UnityEngine;
using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Rex {
    [CreateAssetMenu(fileName = "ConfiguratioCivisStatusCorporisMotus", menuName = "Yulinti/Rex/ConfiguratioCivisStatusCorporisMotus")]
    public class ConfiguratioCivisStatusCorporisMotus : ConfiguratioCivisStatusCorporisBasis, IConfiguratioCivisStatusCorporisMotus {
        [SerializeField] private IDCivisStatusCorporisModiMotus idModiMotus;

        public IDCivisStatusCorporisModiMotus IdModiMotus => idModiMotus;
    }
}