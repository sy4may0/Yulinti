using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.ConfiguratioDucis {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeStatusCursus {
        [Header("ConfiguratioPuellaeStatusCursus/Cursus状態の設定")]
        [SerializeField] private IDPuellaeAnimationisCorporis _idAnimationis = IDPuellaeAnimationisCorporis.None;
        [SerializeField] private float _velocitasDesiderata = 3.3f;
        [SerializeField] private float _acceleratio = 15f;
        [SerializeField] private float _deceleratio = 15f;
        [SerializeField] private bool _estLevigatum = true;

        public IDPuellaeAnimationisCorporis IdAnimationis => _idAnimationis;
        public float VelocitasDesiderata => _velocitasDesiderata;
        public float Acceleratio => _acceleratio;
        public float Deceleratio => _deceleratio;
        public bool EstLevigatum => _estLevigatum;
    }
}