using UnityEngine;
using Animancer;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.UnityServices.Internal.AnimationUtils;

namespace Yulinti.UnityServices.ComponentServices.FukaService.Animation.Internal {
    public sealed class FukaAnimationPlan {
        private readonly IAnimationPlan _animationPlan;

        public FukaAnimationPlan(IFukaAnimationClipConfig animationConfig) {
            if (animationConfig.Animation is LinearMixerTransition) {
                _animationPlan = new AnimationPlanSpeedInjectable(
                    animationConfig.Animation as LinearMixerTransition,
                    animationConfig.FadeTime, animationConfig.Easing,
                    animationConfig.Sync, animationConfig.IsBlocking
                );
            } else {
                _animationPlan = new AnimationPlan(
                    animationConfig.Animation, 
                    animationConfig.FadeTime, animationConfig.Easing,
                    animationConfig.Sync, animationConfig.IsBlocking
                );
            }
        }

        public IAnimationPlan AnimationPlan => _animationPlan;
    }
}