using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.ConfiguratioDucis {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeStatusIncubitusAmbulationis {
        [Header("ConfiguratioPuellaeStatusIncubitusAmbulationis/IncubitusAmbulationis状態の設定")]
        [SerializeField] private IDPuellaeAnimationisCorporis _idAnimationis = IDPuellaeAnimationisCorporis.Crouch;
        [SerializeField] private float _velocitasDesiderata = 0.9f;
        [SerializeField] private float _acceleratio = 10f;
        [SerializeField] private float _deceleratio = 20f;
        [SerializeField] private bool _estLevigatum = true;

        public IDPuellaeAnimationisCorporis IdAnimationis => _idAnimationis;
        public float VelocitasDesiderata => _velocitasDesiderata;
        public float Acceleratio => _acceleratio;
        public float Deceleratio => _deceleratio;
        public bool EstLevigatum => _estLevigatum;
    }
}