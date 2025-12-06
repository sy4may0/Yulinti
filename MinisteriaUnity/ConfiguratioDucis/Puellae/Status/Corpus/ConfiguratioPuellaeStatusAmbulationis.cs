using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.ConfiguratioDucis {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeStatusAmbulationis {
        [SerializeField] private IDPuellaeAnimationisContinuata _idAnimationis = IDPuellaeAnimationisContinuata.None;
        [SerializeField] private float _velocitasDesiderata = 1.2f;
        [SerializeField] private float _acceleratio = 20f;
        [SerializeField] private float _deceleratio = 10f;
        [SerializeField] private bool _estLevigatum = true;

        public IDPuellaeAnimationisContinuata IdAnimationis => _idAnimationis;
        public float VelocitasDesiderata => _velocitasDesiderata;
        public float Acceleratio => _acceleratio;
        public float Deceleratio => _deceleratio;
        public bool EstLevigatum => _estLevigatum;
    }
}
