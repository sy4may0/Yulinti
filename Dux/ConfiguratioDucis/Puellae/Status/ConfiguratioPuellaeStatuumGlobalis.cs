using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.ConfigratioDucis {
    [System.Serializable]
    public sealed class ConfiguratioPuellaeStatuumGlobalis {
        [Header("ConfiguratioPuellaeStatus/Puellae状態の基本設定")]
        [Tooltip("移動入力デッドゾーン（二乗値）")]
        [SerializeField] private float _limenInputQuadratum = 0.001f;
        [Tooltip("速度スムージング時間の上限")]
        [SerializeField] private float _tempusLevigatumMax = 1.0f;
        [Tooltip("速度スムージング時間の下限")]
        [SerializeField] private float _tempusLevigatumMin = 0.05f;
        [Tooltip("回転スムージング時間")]
        [SerializeField] private float _tempusLevigatumRotationis = 0.2f;
        [Tooltip("重力加速度")]
        [SerializeField] private float _acceleratioGravitatis = 9.8f;
        [Tooltip("垂直速度最大値(Grounder想定)")]
        [SerializeField] private float _velocitasVerticalisMax = -50f;
        [Tooltip("接地時既定垂直速度")]
        [SerializeField] private float _velocitasContactus = -2f;

        [Header("ConfiguratioPuellaeStatus/基礎アニメーション設定")]
        [SerializeField] private IDPuellaeAnimationisFundamenti _idAnimationisFun = IDPuellaeAnimationisFundamenti.StandardBase;

        public float LimenInputQuadratum => _limenInputQuadratum;
        public float TempusLevigatumMax => _tempusLevigatumMax;
        public float TempusLevigatumMin => _tempusLevigatumMin;
        public float TempusLevigatumRotationis => _tempusLevigatumRotationis;
        public float AcceleratioGravitatis => _acceleratioGravitatis;
        public float VelocitasVerticalisMax => _velocitasVerticalisMax;
        public float VelocitasContactus => _velocitasContactus;

        public IDPuellaeAnimationisFundamenti IdAnimationisFun => _idAnimationisFun;
    }
}