using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.ConfiguratioDucis {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeStatuumGlobalis {
        [SerializeField] private float _limenInputQuadratum = 0.001f;
        [SerializeField] private float _tempusLevigatumMax = 1.0f;
        [SerializeField] private float _tempusLevigatumMin = 0.05f;
        [SerializeField] private float _tempusLevigatumRotationis = 0.2f;
        [SerializeField] private float _acceleratioGravitatis = 9.8f;
        [SerializeField] private float _velocitasVerticalisMax = -50f;
        [SerializeField] private float _velocitasContactus = -9.8f;

        [SerializeField] private IDPuellaeAnimationisContinuata _idAnimationisFun = IDPuellaeAnimationisContinuata.StandardBase;

        public float LimenInputQuadratum => _limenInputQuadratum;
        public float TempusLevigatumMax => _tempusLevigatumMax;
        public float TempusLevigatumMin => _tempusLevigatumMin;
        public float TempusLevigatumRotationis => _tempusLevigatumRotationis;
        public float AcceleratioGravitatis => _acceleratioGravitatis;
        public float VelocitasVerticalisMax => _velocitasVerticalisMax;
        public float VelocitasContactus => _velocitasContactus;

        public IDPuellaeAnimationisContinuata IdAnimationisFun => _idAnimationisFun;
    }
}
