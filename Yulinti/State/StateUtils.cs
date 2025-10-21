using UnityEngine;
using Animancer;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public static class StateUtils {
        /// <summary>
        /// ステートを変更するコールバック
        /// IAnimationPaln.Stop()に渡す。
        /// IAnimationPlan.Stop(onCompleted: () => {
        ///     StateUtils.ChangeStateCallback(runtime, nextState, fadeOverride);
        /// });
        /// </summary>
        /// <param name="runtime">MoveRuntime</param>
        /// <param name="nextState">次のステート</param>
        /// <param name="fadeOverride">フェード時間のオーバーライド（nullの場合はデフォルトのフェード時間を使用）</param>
        public static void ChangeStateCallback(
            MoveRuntime runtime,
            IMoveState nextState,
            float? fadeOverride = null
        ) {
            IMoveState currentState = runtime.CurrentState;
            if (nextState == null) return;
            if (currentState == null) {
                runtime.CurrentState = nextState;
                runtime.CurrentState.Enter(runtime);
                return;
            } 

            if (currentState.LayerIndex == 0 && nextState.LayerIndex == 0) {
                EnterNextState(runtime, nextState);
                return;
            }

            IAnimationPlan currentAnimationPlan = runtime.CurrentState.GetAnimationPlan();
            IAnimationPlan nextAnimationPlan = nextState.GetAnimationPlan();
            if (currentAnimationPlan == null) {
                EnterNextStateWithAnimation(runtime, nextState);
                return;
            }

            currentAnimationPlan.Stop(() => {
                // 次ステートが同じアニメーションのケース(Mixer速度制御ステートとか)は、アニメーションを停止しない。
                bool layerDown = nextState.LayerIndex < runtime.CurrentState.LayerIndex;
                bool layerUp = nextState.LayerIndex > runtime.CurrentState.LayerIndex;
                bool sameLayer = nextState.LayerIndex == runtime.CurrentState.LayerIndex;
                bool sameAnimation = 
                    currentAnimationPlan != null &&
                    nextAnimationPlan != null &&
                    ReferenceEquals(currentAnimationPlan, nextAnimationPlan);

                if (layerDown) {
                    currentAnimationPlan?.StopLayer(fadeOverride);
                    EnterNextState(runtime, nextState);
                } else if (layerUp) {
                    EnterNextStateWithAnimation(runtime, nextState);
                } else {
                    if (sameAnimation) {
                        EnterNextState(runtime, nextState);
                    } else {
                        EnterNextStateWithAnimation(runtime, nextState);
                    }
                }
            });
        }

        public static void EnterNextState(
            MoveRuntime runtime,
            IMoveState nextState
        ) {
            runtime.CurrentState.Exit(runtime);
            runtime.CurrentState = nextState;
            runtime.CurrentState.Enter(runtime);
        }

        public static void EnterNextStateWithAnimation(
            MoveRuntime runtime,
            IMoveState nextState
        ) {
            runtime.CurrentState.Exit(runtime);
            runtime.CurrentState = nextState;
            runtime.CurrentState.Enter(runtime);
            runtime.CurrentState.GetAnimationPlan().Play();
        }
    }
}