using UnityEngine;

namespace Yulinti.CharacterController {
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

            IAnimationPlan currentAnimationPlan = runtime.CurrentState.GetAnimationPlan();
            if (
                currentAnimationPlan != null &&
                nextState.LayerIndex < runtime.CurrentState.LayerIndex
            ) {
                currentAnimationPlan.StopLayer(fadeOverride);
            }

            runtime.CurrentState.Exit(runtime);
            runtime.CurrentState = nextState;
            runtime.CurrentState.Enter(runtime);
        }
    }
}