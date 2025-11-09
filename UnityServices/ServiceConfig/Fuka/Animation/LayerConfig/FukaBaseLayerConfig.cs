using UnityEngine;

namespace Yulinti.UnityServices.ServiceConfig {
    [System.Serializable]
    public class FukaBaseLayerConfig {
        [Header("FukaBaseLayerConfig/Baseレイヤー")]
        [SerializeField] private FukaStandardBaseAnimationConfig _standardBaseAnimationConfig;

        public FukaStandardBaseAnimationConfig StandardBaseAnimationConfig => _standardBaseAnimationConfig;
    }
}