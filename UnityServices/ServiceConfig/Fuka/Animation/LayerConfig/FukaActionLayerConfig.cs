using UnityEngine;
namespace Yulinti.UnityServices.ServiceConfig {
    [System.Serializable]
    public class FukaActionLayerConfig {
        [Header("FukaActionLayerConfig/Actionレイヤー")]
        [SerializeField] private FukaCrouchAnimationConfig _crouchAnimationConfig;

        public FukaCrouchAnimationConfig CrouchAnimationConfig => _crouchAnimationConfig;
    }
}