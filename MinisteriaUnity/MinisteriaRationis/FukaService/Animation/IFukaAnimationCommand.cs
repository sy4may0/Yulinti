using System;
using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.UnityServices.ComponentServices {
    public interface IFukaAnimationCommand {
        void BaseLayerPlayRequest(FukaBaseLayerAnimationID baseLayerAnimationID, Action onCompleted, bool force = false);
        void ActionLayerPlayRequest(FukaActionLayerAnimationID actionLayerAnimationID, Action onCompleted, bool force = false);
        void EmoteLayerPlayRequest(FukaEmoteLayerAnimationID emoteLayerAnimationID, Action onCompleted, bool force = false);
        void AdditivePoseLayerPlayRequest(FukaAdditivePoseLayerAnimationID additivePoseLayerAnimationID, Action onCompleted, bool force = false);
        void ExtraLayerPlayRequest(FukaExtraLayerAnimationID extraLayerAnimationID, Action onCompleted, bool force = false);
        void BaseLayerForceStopRequest();
        void ActionLayerForceStopRequest();
        void EmoteLayerForceStopRequest();
        void AdditivePoseLayerForceStopRequest();
        void ExtraLayerForceStopRequest();
        void InjectSpeed(float speed);
    }
}