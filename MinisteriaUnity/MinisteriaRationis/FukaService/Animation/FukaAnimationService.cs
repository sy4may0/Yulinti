using System;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceContracts;
using Yulinti.UnityServices.ComponentServices.FukaService.Animation.Internal;
using Yulinti.UnityServices.Internal.AnimationUtils;
using Yulinti.UnityServices.Internal.LifeCycle;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class FukaAnimationService : IServiceTickable {
        private readonly FukaBaseLayerMap _baseLayerMap;
        private readonly FukaActionLayerMap _actionLayerMap;

        private readonly AnimationLayer _baseLayer;
        private readonly AnimationLayer _actionLayer;

        public FukaAnimationService(FukaAnimationConfig animationConfig) {
            if (animationConfig == null) {
                ModeratorErrorum.Fatal("FukaAnimationServiceのアニメーション設定がnullです。");
            }
            if (animationConfig.Animancer == null) {
                ModeratorErrorum.Fatal("FukaAnimationServiceのAnimancerがnullです。");
            }

            _baseLayerMap = new FukaBaseLayerMap(animationConfig.BaseLayerConfig);
            _actionLayerMap = new FukaActionLayerMap(animationConfig.ActionLayerConfig);

            _baseLayer = new AnimationLayer(animationConfig.Animancer, 0);
            _actionLayer = new AnimationLayer(animationConfig.Animancer, 1);
        }

        public void BaseLayerPlayRequest(
            FukaBaseLayerAnimationID baseLayerAnimationID, Action onCompleted, bool force = false
        ) {
            _baseLayer.PlayRequest(_baseLayerMap.Get(baseLayerAnimationID).AnimationPlan, onCompleted, force);
        }
        public void ActionLayerPlayRequest(
            FukaActionLayerAnimationID actionLayerAnimationID, Action onCompleted, bool force = false
        ) {
            _actionLayer.PlayRequest(_actionLayerMap.Get(actionLayerAnimationID).AnimationPlan, onCompleted, force);
        }
        public void EmoteLayerPlayRequest(
            FukaEmoteLayerAnimationID emoteLayerAnimationID, Action onCompleted, bool force = false
        ) {
            // TODO: 実装
        }
        public void AdditivePoseLayerPlayRequest(
            FukaAdditivePoseLayerAnimationID additivePoseLayerAnimationID, Action onCompleted, bool force = false
        ) {
            // TODO: 実装
        }
        public void ExtraLayerPlayRequest(
            FukaExtraLayerAnimationID extraLayerAnimationID, Action onCompleted, bool force = false
        ) {
            // TODO: 実装
        }

        public void BaseLayerForceStopRequest() {
            _baseLayer.ForceStopRequest();
        }
        public void ActionLayerForceStopRequest() {
            _actionLayer.ForceStopRequest();
        }
        public void EmoteLayerForceStopRequest() {
            // TODO: 実装
        }
        public void AdditivePoseLayerForceStopRequest() {
            // TODO: 実装
        }
        public void ExtraLayerForceStopRequest() {
            // TODO: 実装
        }

        public void InjectSpeed(float speed) {
            _baseLayer.InjectSpeed(speed);
            _actionLayer.InjectSpeed(speed);
            // TODO: 実装
        }

        // Baseを基準ですべて同期する。
        private void SyncLayer() {
            float basetime = _baseLayer.GetSyncTime();
            _actionLayer.SetSyncTime(basetime);
            // TODO: 実装
        }

        public void Tick(float deltaTime) {
            _baseLayer.Tick(deltaTime);
            _actionLayer.Tick(deltaTime);
            SyncLayer();
            // TODO: 実装
        }
    }
}