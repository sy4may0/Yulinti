using Animancer;
namespace Yulinti.UnityServices.ServiceConfig {
    public interface IFukaAnimationConfig {
        AnimancerComponent Animancer { get; }
        FukaBaseLayerConfig BaseLayerConfig { get; }
        FukaActionLayerConfig ActionLayerConfig { get; }
    }
}