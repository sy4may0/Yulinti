using System;
using Yulinti.MinisteriaNuclei.ModeratorErrorum;
using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class FukaAnimationRW : IFukaAnimationCommand {
        private readonly FukaAnimationService _fukaAnimationService;
        public FukaAnimationRW(FukaAnimationService fukaAnimationService) {
            if (fukaAnimationService == null) {
                ModeratorErrorum.Fatal("コンポーネントサービス(FukaAnimationRW)のFukaAnimationServiceがnullです。");
            }
            _fukaAnimationService = fukaAnimationService;
        }

        public void BaseLayerPlayRequest(FukaBaseLayerAnimationID baseLayerAnimationID, Action onCompleted, bool force = false) {
            _fukaAnimationService.BaseLayerPlayRequest(baseLayerAnimationID, onCompleted, force);
        }
        public void ActionLayerPlayRequest(FukaActionLayerAnimationID actionLayerAnimationID, Action onCompleted, bool force = false) {
            _fukaAnimationService.ActionLayerPlayRequest(actionLayerAnimationID, onCompleted, force);
        }
        public void EmoteLayerPlayRequest(FukaEmoteLayerAnimationID emoteLayerAnimationID, Action onCompleted, bool force = false) {
            _fukaAnimationService.EmoteLayerPlayRequest(emoteLayerAnimationID, onCompleted, force);
        }
        public void AdditivePoseLayerPlayRequest(FukaAdditivePoseLayerAnimationID additivePoseLayerAnimationID, Action onCompleted, bool force = false) {
            _fukaAnimationService.AdditivePoseLayerPlayRequest(additivePoseLayerAnimationID, onCompleted, force);
        }
        public void ExtraLayerPlayRequest(FukaExtraLayerAnimationID extraLayerAnimationID, Action onCompleted, bool force = false) {
            _fukaAnimationService.ExtraLayerPlayRequest(extraLayerAnimationID, onCompleted, force);
        }
        public void BaseLayerForceStopRequest() {
            _fukaAnimationService.BaseLayerForceStopRequest();
        }
        public void ActionLayerForceStopRequest() {
            _fukaAnimationService.ActionLayerForceStopRequest();
        }
        public void EmoteLayerForceStopRequest() {
            _fukaAnimationService.EmoteLayerForceStopRequest();
        }
        public void AdditivePoseLayerForceStopRequest() {
            _fukaAnimationService.AdditivePoseLayerForceStopRequest();
        }
        public void ExtraLayerForceStopRequest() {
            _fukaAnimationService.ExtraLayerForceStopRequest();
        }
        public void InjectSpeed(float speed) {
            _fukaAnimationService.InjectSpeed(speed);
        }
    }
}