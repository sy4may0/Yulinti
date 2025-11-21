using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.ConfigratioDucis {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeStatusAmbulationis {
        [Header("ConfiguratioPuellaeStatusAmbulationis/Ambulationis状態の設定")]
        [SerializeField] private IDPuellaeAnimationisCorporis _idAnimationis = IDPuellaeAnimationisCorporis.None;
        [SerializeField] private float _velocitasDesiderata = 1.2f;
        [SerializeField] private float _acceleratio = 20f;
        [SerializeField] private float _deceleratio = 10f;
        [SerializeField] private bool _estLevigatum = true;

        public IDPuellaeAnimationisCorporis IdAnimationis => _idAnimationis;
        public float VelocitasDesiderata => _velocitasDesiderata;
        public float Acceleratio => _acceleratio;
        public float Deceleratio => _deceleratio;
        public bool EstLevigatum => _estLevigatum;
    }
}