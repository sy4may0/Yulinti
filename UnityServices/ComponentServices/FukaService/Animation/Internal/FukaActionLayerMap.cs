using UnityEngine;
using Yulinti.MinisteriaNuclei.ModeratorErrorum;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.UnityServices.ServiceContracts;
using Yulinti.UnityServices.ComponentServices.FukaService.Animation.Internal;

namespace Yulinti.UnityServices.ComponentServices.FukaService.Animation.Internal {
    public sealed class FukaActionLayerMap {
        private readonly FukaAnimationPlan[] _animationPlans;

        public FukaActionLayerMap(FukaActionLayerConfig actionLayerConfig) {
            int length = (int)FukaActionLayerAnimationID.Count;
            _animationPlans = new FukaAnimationPlan[length];

            _animationPlans[(int)FukaActionLayerAnimationID.None] = null;
            _animationPlans[(int)FukaActionLayerAnimationID.Crouch] = new FukaAnimationPlan(actionLayerConfig.CrouchAnimationConfig);

            for (int i = 1; i < length; i++) {
                if (_animationPlans[i] == null) {
                    ModeratorErrorum.Fatal($"FukaActionLayerAnimationID {(FukaActionLayerAnimationID)i} のアニメーションプランが見つかりません。FukaActionLayerConfigの設定を確認してください。");
                }
            }
        }

        public FukaAnimationPlan Get(FukaActionLayerAnimationID animationID) => _animationPlans[(int)animationID];
    }
}
