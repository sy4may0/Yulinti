using UnityEngine;
using Animancer;

namespace Yulinti.UnityServices.ServiceConfig {
    [System.Serializable]
    public class FukaAnimationConfig : IFukaAnimationConfig {
        [Header("FukaAnimationConfig/アニメーション設定")]
        [SerializeField] private AnimancerComponent _animancer;
        [SerializeField] private FukaBaseLayerConfig _baseLayerConfig;
        [SerializeField] private FukaActionLayerConfig _actionLayerConfig;

        public AnimancerComponent Animancer => _animancer;
        public FukaBaseLayerConfig BaseLayerConfig => _baseLayerConfig;
        public FukaActionLayerConfig ActionLayerConfig => _actionLayerConfig;
    }
}