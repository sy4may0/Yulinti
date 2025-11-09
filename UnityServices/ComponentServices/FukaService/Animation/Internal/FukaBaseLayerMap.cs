using UnityEngine;
using Yulinti.UnityServices.CoreServices;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.UnityServices.ServiceContracts;
using Yulinti.UnityServices.ComponentServices.FukaService.Animation.Internal;

namespace Yulinti.UnityServices.ComponentServices.FukaService.Animation.Internal {
    public sealed class FukaBaseLayerMap {
        private readonly FukaAnimationPlan[] _animationPlans;

        public FukaBaseLayerMap(FukaBaseLayerConfig baseLayerConfig) {
            int length = (int)FukaBaseLayerAnimationID.Count;
            _animationPlans = new FukaAnimationPlan[length];

            _animationPlans[(int)FukaBaseLayerAnimationID.None] = null;
            _animationPlans[(int)FukaBaseLayerAnimationID.StandardBase] = new FukaAnimationPlan(baseLayerConfig.StandardBaseAnimationConfig);

            for (int i = 1; i < length; i++) {
                if (_animationPlans[i] == null) {
                    ErrorHandleService.Fatal($"FukaBaseLayerAnimationID {(FukaBaseLayerAnimationID)i} のアニメーションプランが見つかりません。FukaBaseLayerConfigの設定を確認してください。");
                }
            }
        }

        public FukaAnimationPlan Get(FukaBaseLayerAnimationID animationID) => _animationPlans[(int)animationID];
    }
}

