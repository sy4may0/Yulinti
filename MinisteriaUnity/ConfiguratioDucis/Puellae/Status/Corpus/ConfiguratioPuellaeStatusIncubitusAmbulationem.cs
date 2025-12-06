using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.ConfiguratioDucis {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeStatusIncubitusAmbulationem {
        [SerializeField] private IDPuellaeAnimationisContinuata _idAnimationis = IDPuellaeAnimationisContinuata.Crouch;
        [SerializeField] private float _velocitasDesiderata = 0.9f;
        [SerializeField] private float _acceleratio = 10f;
        [SerializeField] private float _deceleratio = 20f;
        [SerializeField] private bool _estLevigatum = true;

        public IDPuellaeAnimationisContinuata IdAnimationis => _idAnimationis;
        public float VelocitasDesiderata => _velocitasDesiderata;
        public float Acceleratio => _acceleratio;
        public float Deceleratio => _deceleratio;
        public bool EstLevigatum => _estLevigatum;
    }
}
