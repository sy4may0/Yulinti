using UnityEngine;
using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Rex {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeStatusCorporisMotus", menuName = "Yulinti/Rex/ConfiguratioPuellaeStatusCorporisMotus")]
    public sealed class ConfiguratioPuellaeStatusCorporisMotus : ConfiguratioPuellaeStatusCorporisBasis, IConfiguratioPuellaeStatusCorporisMotus {
        [SerializeField] private IDPuellaeStatusCorporisModiMotus idModiMotus;
        [SerializeField] private float velocitasDesiderata;
        [SerializeField] private float acceleratio;
        [SerializeField] private float deceleratio;
        [SerializeField] private bool estLevigatum;

        public IDPuellaeStatusCorporisModiMotus IdModiMotus => idModiMotus;
        public float VelocitasDesiderata => velocitasDesiderata;
        public float Acceleratio => acceleratio;
        public float Deceleratio => deceleratio;
        public bool EstLevigatum => estLevigatum;
    }
}