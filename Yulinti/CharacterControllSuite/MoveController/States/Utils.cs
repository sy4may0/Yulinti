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
            Debug.Log("Play");
            runtime.CurrentState.GetAnimationPlan().Play();
        }
    }

    // [TODO] 循環参照してるぞアホ当職が、作り直せ。
    // StateMachineを実装してロジックを整理しろ。
    // OutputStateはEnumIDで返して作れるようにしろ。ステートはEnumだけ見ろ。StateLibraryを持つな。
    // あとAttributeでIdleStateとかRunStateとかいれるな。Dictionaryで管理しろ。
    // 初期化時しかヒープを取らない(Updateからコンストラクタを呼ばない、シングルトン)ならDictionaryで問題ない。
    public sealed class BaseStateLibrary {
        public IdleState IdleState { get; set; }
        public RunState RunState { get; set; }
        public WalkState WalkState { get; set; }
        public CrouchIdleState CrouchIdleState { get; set; }
        public CrouchWalkState CrouchWalkState { get; set; }

        public BaseStateLibrary(
            MoveTuning moveTuning,
            InputProvider inputProvider,
            CameraProvider cameraProvider,
            IdleStateConfig idleStateConfig,
            WalkStateConfig walkStateConfig,
            RunStateConfig runStateConfig
        ) {
            IdleState = new IdleState(moveTuning, idleStateConfig, inputProvider, this);
            RunState = new RunState(moveTuning, runStateConfig, inputProvider, cameraProvider, this);
            WalkState = new WalkState(moveTuning, walkStateConfig, inputProvider, cameraProvider, this);
            CrouchIdleState = null;
            CrouchWalkState = null;
        }

        public void AddCrouchState(
            MoveTuning moveTuning,
            InputProvider inputProvider,
            CameraProvider cameraProvider,
            CrouchIdleStateConfig crouchIdleStateConfig,
            CrouchWalkStateConfig crouchWalkStateConfig,
            CrouchAnimationConfig crouchAnimationConfig,
            AnimancerComponent animancer
        ) {
            ThreePhaseAnimationPlan crouchAnimationPlan = new ThreePhaseAnimationPlan(
                animancer,
                1,
                null, crouchAnimationConfig.CrouchAnimationMixer, null,
                crouchAnimationConfig.FadeTime,
                crouchAnimationConfig.FadeTime,
                crouchAnimationConfig.FadeTime
            );
            CrouchIdleState = new CrouchIdleState(moveTuning, crouchIdleStateConfig, inputProvider, this, crouchAnimationPlan);
            CrouchWalkState = new CrouchWalkState(moveTuning, crouchWalkStateConfig, inputProvider, cameraProvider, this, crouchAnimationPlan);
        }

        public void InjectSpeed(float speed) {
            CrouchIdleState?.GetAnimationPlan()?.InjectSpeed(speed);
            CrouchWalkState?.GetAnimationPlan()?.InjectSpeed(speed);
        }
    }
}