using UnityEngine;
using System;
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

        public StateRuntimePayload(
            float deltaTime,
            float currentSpeedHorizontal,
            float currentSpeedVertical,
            float currentYaw,
            bool isGrounded
        ) {
            DeltaTime = deltaTime;
            CurrentSpeedHorizontal = currentSpeedHorizontal;
            CurrentSpeedVertical = currentSpeedVertical;
            CurrentYaw = currentYaw;
            IsGrounded = isGrounded;
        }
    }

    public class StateContainer {
        public readonly IMoveState State;
        public readonly IAnimationPlan AnimationPlan;

        public StateContainer(IMoveState state, IAnimationPlan animationPlan) {
            State = state;
            AnimationPlan = animationPlan;
        }
    }

    public class StateMachine {
        private readonly Dictionary<StateID, StateContainer> _stateContainers;
        private StateContainer _currentState;

        public StateMachine() {
            _stateContainers = new Dictionary<StateID, StateContainer>();
        }

        public void AddState(StateID stateID, StateContainer stateContainer) {
            _stateContainers[stateID] = stateContainer;
        }
        public void Initialize(StateRuntimePayload payload) {
            if (_stateContainers.TryGetValue(StateID.Idle, out StateContainer idleState)) {
                _currentState = idleState;
                _currentState.State.Enter(payload);
                _currentState.AnimationPlan.Play();
            } else {
                Debug.LogError("IdleState not found");
            }
        }

        public MovePlan PlanMove(StateRuntimePayload payload) {
            return _currentState.State.Tick(payload);
        }

        public void PostMove(StateRuntimePayload payload) {
            InjectSpeed(payload);
        }

        public void TryTransition(StateRuntimePayload payload) {
            StateID nextId = _currentState.State?.TryTransition(payload) ?? StateID.None;
            if (nextId == StateID.None) return;

            if (!_stateContainers.TryGetValue(nextId, out StateContainer nextS)) return;

            StateContainer currS = _currentState;
            IAnimationPlan  currAP = currS.AnimationPlan;
            IAnimationPlan  nextAP = nextS.AnimationPlan;

            if (currS.State == null || currAP == null) {
                EnterNextState(payload, currS, nextS, currAP, nextAP);
                return;
            }

            currAP.Stop(() => {
                EnterNextState(payload, currS, nextS, currAP, nextAP);
                InjectSpeed(payload);
            });
        }

        private void EnterNextState(StateRuntimePayload payload, StateContainer currS, StateContainer nextS, IAnimationPlan currAP, IAnimationPlan nextAP) {
            int layerCmp = Math.Sign(nextS.State.LayerIndex - currS.State.LayerIndex);
            bool sameAP = ReferenceEquals(currAP, nextAP);

            if (layerCmp < 0) {   // LayerDown
                currAP?.StopLayer();
                EnterNextStateNoAnimation(payload, nextS);
            } else if (layerCmp > 0) {   // LayerUp
                EnterNextStateWithAnimation(payload, nextS);
            } else {  // SameLayer
                if (sameAP) {
                    EnterNextStateNoAnimation(payload, nextS);
                } else {
                    EnterNextStateWithAnimation(payload, nextS);
                }
            }
        }

        private void EnterNextStateWithAnimation(StateRuntimePayload payload, StateContainer nextState) {
            _currentState?.State?.Exit(payload);
            _currentState = nextState;
            _currentState?.State?.Enter(payload);
            _currentState?.AnimationPlan?.Play();
        }

        private void EnterNextStateNoAnimation(StateRuntimePayload payload, StateContainer nextState) {
            _currentState?.State?.Exit(payload);
            _currentState = nextState;
            _currentState?.State?.Enter(payload);
        }

        private void InjectSpeed(StateRuntimePayload payload) {
            _currentState?.AnimationPlan?.InjectSpeed(payload.CurrentSpeedHorizontal);
        }
    }
}