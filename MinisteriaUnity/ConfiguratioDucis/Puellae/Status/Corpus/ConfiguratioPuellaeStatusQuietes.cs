using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.ConfiguratioDucis {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeStatusQuietes {
        [SerializeField] private IDPuellaeAnimationisContinuata _idAnimationis = IDPuellaeAnimationisContinuata.None;
        [SerializeField] private float _velocitasDesiderata = 0f;
        [SerializeField] private float _acceleratio = 30f;
        [SerializeField] private float _deceleratio = 20f;
        [SerializeField] private bool _estLevigatum = true;

        public IDPuellaeAnimationisContinuata IdAnimationis => _idAnimationis;
        public float VelocitasDesiderata => _velocitasDesiderata;
        public float Acceleratio => _acceleratio;
        public float Deceleratio => _deceleratio;
        public bool EstLevigatum => _estLevigatum;
    }
}
