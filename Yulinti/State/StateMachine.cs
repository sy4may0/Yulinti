using UnityEngine;
using System.Collections.Generic;

namespace Yulinti.CharacterControllSuite {
    public enum StateID {
        None,
        Idle,
        Walk,
        Run,
        CrouchIdle,
        CrouchWalk
    }

    public struct StateRuntimePayload {
        public readonly float DeltaTime;
        public readonly float CurrentSpeedHorizontal;
        public readonly float CurrentSpeedVertical;
        public readonly float CurrentYaw;
        public readonly bool IsGrounded;
    }

    public class StateContainer {
        public IMoveState State;
        public IAnimationPlan AnimationPlan;
    }

    public class StateMachine {
        private readonly Dictionary<StateID, StateContainer> _stateContainers;
        private StateContainer _currentState;

        public StateMachine() {
            _stateContainers = new Dictionary<StateID, StateContainer>();
        }

        public void AddState(StateID stateID, IMoveState state, IAnimationPlan animationPlan) {
            _stateContainers[stateID] = new StateContainer {
                State = state,
                AnimationPlan = animationPlan
            };
        }
        public void Awake(StateRuntimePayload payload) {
            if (_stateContainers.TryGetValue(StateID.Idle, out StateContainer idleState)) {
                _currentState = idleState;
                _currentState.State.Enter(payload);
                _currentState.AnimationPlan.Play();
            } else {
                Debug.LogError("IdleState not found");
            }
        }

        public MovePlan planMove(StateRuntimePayload payload) {
            return _currentState.State.Tick(payload);
        }

        public void AfterMove(StateRuntimePayload payload) {
            injectSpeed(payload);
        }

        public void TryTransition(StateRuntimePayload payload) {
            StateID nextId = _currentState.State?.TryTransition(payload) ?? StateID.None;
            if (nextId == StateID.None) return;

            if (!_StateContainers.TryGetValue(nextId, out StateContainer nextS)) return;

            StateContainer currS = _currentState;
            IAnimationPlan  currAP = currS.AnimationPlan;
            IAnimationPlan  nextAP = nextS.AnimationPlan;

            if (currS.State == null || currAP == null) {
                EnterNextState(currS, nextS, currAP, nextAP);
                return;
            }

            currAP.Stop(() => {
                EnterNextState(currS, nextS, currAP, nextAP);
                injectSpeed();
            })
        }

        private void EnterNextState(StateContainer currS, StateContainer nextS, IAnimationPlan currAP, IAnimationPlan nextAP) {
            int layerCmp = Math.Sign(nextS.State.LayerIndex - currS.State.LayerIndex);
            bool sameAP = ReferenceEquals(currAP, nextAP);

            if (layerCmp < 0) {   // LayerDown
                currAP?.StopLayer();
                EnterNextStateNoAnimation(nextS);
            } else if (layerCmp > 0) {   // LayerUp
                EnterNextStateWithAnimation(nextS);
            } else {  // SameLayer
                if (sameAP) {
                    EnterNextStateNoAnimation(nextS);
                } else {
                    EnterNextStateWithAnimation(nextS);
                }
            }
        }

        private void EnterNextStateWithAnimation(StateContainer nextState) {
            EnterNextState(nextState);
            _currentState?.AnimationPlan?.Play();
        }

        private void EnterNextStateNoAnimation(StateContainer nextState) {
            _currentState?.State?.Exit(payload);
            _currentState = nextState;
            _currentState?.State?.Enter(payload);
        }

        private void injectSpeed(StateRuntimePayload payload) {
            if (_currentState?.AnimationPlan is IAnimationSpeedInjectable speedInjectable) {
                speedInjectable.InjectSpeed(payload.CurrentSpeedHorizontal);
            }
        }
    }
}