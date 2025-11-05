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
        private StateID _currentStateID;
        private StateContainer _currentState;

        public StateMachine() {
            _stateContainers = new Dictionary<StateID, StateContainer>();
        }

        public StateID CurrentStateID => _currentStateID;

        public void AddState(StateID stateID, StateContainer stateContainer) {
            _stateContainers[stateID] = stateContainer;
        }
        public void Initialize(MoveRuntimeReadOnly moveRuntimeRO) {
            if (_stateContainers.TryGetValue(StateID.Idle, out StateContainer idleState)) {
                _currentState = idleState;
                _currentStateID = StateID.Idle;
                _currentState.State.Enter(moveRuntimeRO);
                _currentState.AnimationPlan.Play();
            } else {
                Debug.LogError("IdleState not found");
            }
        }

        public MovePlan PlanMove(MoveRuntimeReadOnly moveRuntimeRO) {
            return _currentState.State.Tick(moveRuntimeRO);
        }

        public void PostMove(MoveRuntimeReadOnly moveRuntimeRO) {
            InjectSpeed(moveRuntimeRO);
        }

        public void TryTransition(MoveRuntimeReadOnly moveRuntimeRO) {
            StateID nextId = _currentState.State?.TryTransition(moveRuntimeRO) ?? StateID.None;
            if (nextId == StateID.None) return;

            if (!_stateContainers.TryGetValue(nextId, out StateContainer nextS)) return;

            StateContainer currS = _currentState;
            IAnimationPlan  currAP = currS.AnimationPlan;
            IAnimationPlan  nextAP = nextS.AnimationPlan;

            if (currS.State == null || currAP == null) {
                EnterNextState(moveRuntimeRO, currS, nextS, currAP, nextAP);
                return;
            }

            currAP.Stop(() => {
                EnterNextState(moveRuntimeRO, currS, nextS, currAP, nextAP);
                InjectSpeed(moveRuntimeRO);
                _currentStateID = nextId;
            });
        }

        private void EnterNextState(MoveRuntimeReadOnly moveRuntimeRO, StateContainer currS, StateContainer nextS, IAnimationPlan currAP, IAnimationPlan nextAP) {
            int layerCmp = Math.Sign(nextS.State.LayerIndex - currS.State.LayerIndex);
            bool sameAP = ReferenceEquals(currAP, nextAP);


            if (layerCmp < 0) {   // LayerDown
                currAP?.StopLayer();
                EnterNextStateNoAnimation(moveRuntimeRO, nextS);
            } else if (layerCmp > 0) {   // LayerUp
                EnterNextStateWithAnimation(moveRuntimeRO, nextS);
            } else {  // SameLayer
                if (sameAP) {
                    EnterNextStateNoAnimation(moveRuntimeRO, nextS);
                } else {
                    EnterNextStateWithAnimation(moveRuntimeRO, nextS);
                }
            }
        }

        private void EnterNextStateWithAnimation(MoveRuntimeReadOnly moveRuntimeRO, StateContainer nextState) {
            _currentState?.State?.Exit(moveRuntimeRO);
            _currentState = nextState;
            _currentState?.State?.Enter(moveRuntimeRO);
            _currentState?.AnimationPlan?.Play();
        }

        private void EnterNextStateNoAnimation(MoveRuntimeReadOnly moveRuntimeRO, StateContainer nextState) {
            _currentState?.State?.Exit(moveRuntimeRO);
            _currentState = nextState;
            _currentState?.State?.Enter(moveRuntimeRO);
        }

        private void InjectSpeed(MoveRuntimeReadOnly moveRuntimeRO) {
            _currentState?.AnimationPlan?.InjectSpeed(moveRuntimeRO.CurrentSpeedHorizontal);
        }
    }
}