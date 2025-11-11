using UnityEngine;
using Animancer;
using System;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;

namespace Yulinti.UnityServices.Internal.AnimationUtils {
    public class AnimationLayer : IAnimationLayer {
        private readonly AnimancerLayer _animancerLayer;
        private readonly int _layerIndex;
        private IAnimationPlan _currentAnimationPlan;
        private IAnimationPlan _requestedAnimationPlan;
        private Action _requestedOnCompleted;
        private bool _isRequesting;
        private bool _isForceRequesting;
        private bool _forceStopRequested;
        private bool _isLockedNext;
        private float _syncTime;

        private readonly Action _onEndHandler;

        public AnimationLayer(AnimancerComponent animancer, int layerIndex) {
            _animancerLayer = animancer.Layers[layerIndex];
            if (_animancerLayer == null) {
                ModeratorErrorum.Fatal($"アニメーションレイヤー{layerIndex}が見つかりません。");
            }
            _layerIndex = layerIndex;
            _currentAnimationPlan = null;
            _onEndHandler = OnEnd;
        }

        public int LayerIndex => _layerIndex;
        public IAnimationPlan CurrentAnimationPlan => _currentAnimationPlan;
        public bool IsBlocking => CurrentAnimationPlan?.IsBlocking ?? false;

        public void PlayRequest(IAnimationPlan animationPlan, Action onCompleted, bool force=false, bool lockNext=false) {
            if (!force && _isLockedNext) {
                return;
            }
            _isLockedNext = lockNext;
            _requestedAnimationPlan = animationPlan;
            _requestedOnCompleted = onCompleted;
            _isRequesting = true;
            _isForceRequesting = force;
        }

        public void ForceStopRequest() {
            _forceStopRequested = true;
        }

        public void InjectSpeed(float speed) {
            if (_currentAnimationPlan is IAnimationPlanSpeedInjectable speedInjectable) {
                speedInjectable.InjectSpeed(speed);
            }
        }

        public void Tick(float deltaTime) {
            if (_forceStopRequested) {
                StopLayer();
                return;
            }
            if (_isForceRequesting) {
                HandlePlayRequest();
                return;
            }

            if (IsBlocking) {
                AnimancerState currentState = _animancerLayer.CurrentState;
                if (currentState == null) {
                    HandlePlayRequest();
                    return;
                }
                if (currentState.Events(this, out AnimancerEvent.Sequence events)) {
                    events.OnEnd = _onEndHandler;
                }
                return;
            }

            HandlePlayRequest();
        }

        public float GetSyncTime() {
            return _animancerLayer.CurrentState?.NormalizedTime ?? 0f;
        }

        public void SetSyncTime(float time) {
            _syncTime = time;
        }

        // ======= INTERNAL METHODS =======
        private void ClearRequest() {
            _requestedOnCompleted = null;
            _requestedAnimationPlan = null;
            _isRequesting = false;
            _isForceRequesting = false;
            _forceStopRequested = false;
            _isLockedNext = false;
        }

        private void ClearCurrentOnEnd() {
            if (_animancerLayer.CurrentState?.Events(this, out AnimancerEvent.Sequence events) ?? false) {
                events.OnEnd = null;
            }
        }

        private void StopLayer() {
            ClearCurrentOnEnd();
            if (_currentAnimationPlan == null) {
                ClearRequest();
                return;
            }
            _animancerLayer.StartFade(0f, _currentAnimationPlan.FadeTime);
            _animancerLayer.FadeGroup.SetEasing(_currentAnimationPlan.Easing);
            _requestedOnCompleted?.Invoke();
            _currentAnimationPlan = null;
            ClearRequest();
        }

        private void SyncLayer(AnimancerState state) {
            if (_currentAnimationPlan?.Sync ?? false) {
                state.NormalizedTime = _syncTime;
            }
        }

        private void PlayAnimation() {
            ClearCurrentOnEnd();
            _currentAnimationPlan = _requestedAnimationPlan;
            AnimancerState state = _animancerLayer.Play(_currentAnimationPlan.Transition, _currentAnimationPlan.FadeTime);
            _animancerLayer.FadeGroup.SetEasing(_currentAnimationPlan.Easing);
            _requestedOnCompleted?.Invoke();
            SyncLayer(state);
            ClearRequest();
        }

        private void OnEnd() {
            if (_isRequesting) {
                HandlePlayRequest();
            } else {
                StopLayer();
            }
        }

        private void HandlePlayRequest() {
            if (!_isRequesting) {
                return;
            }
            if (_requestedAnimationPlan == null) {
                StopLayer();
                return; 
            }
            PlayAnimation();
        }
    }
}
