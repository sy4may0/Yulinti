using Animancer;
using UnityEngine;
using System;
using Yulinti.CharacterControllSuite;

// TIPS
// _start, _loop, _stopの中身はPlay()再生されるまでnull。気をつけろ。
namespace Yulinti.CharacterControllSuite
{
    public sealed class ThreePhaseAnimationPlan : IAnimationPlan
    {
        private readonly AnimancerComponent _animancer;
        private readonly int _layerIndex;

        private ITransition _start, _loop, _stop;
        private float _fadeStart, _fadeLoop, _fadeStop;

        // ブロック方針（外から設定可能）
        public bool BlockInStart { get => _blockInStart; set => _blockInStart = value; }
        public bool BlockInStop  { get => _blockInStop;  set => _blockInStop  = value; }
        private bool _blockInStart, _blockInStop;

        // 割り込み対策
        private int _seq;

        // OnEndの共通ハンドラ（デリゲート割当1回）
        private enum PendingKind { None, ToLoop, ToCallback }
        private PendingKind _pendingKind;
        private int _pendingSeq;
        private Action _pendingCallback;
        private readonly Action _sharedOnEnd;

        public bool IsBlocking { get; private set; }

        public ThreePhaseAnimationPlan(
            AnimancerComponent animancer,
            int layerIndex,
            ITransition startClip,
            ITransition loopClip,
            ITransition stopClip,
            float fadeStart,
            float fadeLoop,
            float fadeStop)
        {
            _animancer = animancer;
            _layerIndex = layerIndex;
            _start = startClip; _loop = loopClip; _stop = stopClip;
            _fadeStart = fadeStart; _fadeLoop = fadeLoop; _fadeStop = fadeStop;
            _blockInStart = false;
            _blockInStop = false;
            IsBlocking = false;

            _sharedOnEnd = OnEndShared; // ここで1回だけ作る
        }

        public void UpdateClips(ITransition start, ITransition loop, ITransition stop)
        { _start = start; _loop = loop; _stop = stop; }

        public void UpdateFades(float fadeStart, float fadeLoop, float fadeStop)
        { _fadeStart = fadeStart; _fadeLoop = fadeLoop; _fadeStop = fadeStop; }

        // === Play: Start→(OnEnd)→Loop ===
        public void Play()
        {
            if (_animancer == null) return;
            if (_layerIndex < 0) return;

            int my = ++_seq;
            var layer = _animancer.Layers[_layerIndex];

            if (_start == null)
            {
                // Startなし：即Loopへ（1フェーズ対応）
                IsBlocking = false;
                PlayLoop(my);
                return;
            }

            IsBlocking = _blockInStart;

            var state = AnimationUtils.PlayWithSineEase(layer, _start, _fadeStart);

            // Start終了で Loop へ
            _pendingSeq = my;
            _pendingKind = PendingKind.ToLoop;
            _pendingCallback = null;
            if (state.Events(this, out AnimancerEvent.Sequence events))
            {
                events.OnEnd = _sharedOnEnd;

            }
        }

        private void PlayLoop(int my)
        {
            if (my != _seq) return;
            if (_loop == null) { /* ワンショット終端 */ return; }

            var layer = _animancer.Layers[_layerIndex];
            var state = AnimationUtils.PlayWithSineEase(layer, _loop, _fadeLoop);
        }

        // === Stop: Stop再生→完了でコールバック。無ければ即コールバック ===
        public void Stop(Action onCompleted = null)
        {
            if (_animancer == null) { onCompleted?.Invoke(); return; }
            if (_layerIndex < 0 || _layerIndex >= _animancer.Layers.Count) { onCompleted?.Invoke(); return; }

            int my = ++_seq;

            if (_stop == null)
            {
                IsBlocking = false; // Stopなし：即完了
                onCompleted?.Invoke();
                return;
            }

            IsBlocking = _blockInStop;

            var layer = _animancer.Layers[_layerIndex];
            var state = AnimationUtils.PlayWithSineEase(layer, _stop, _fadeStop);

            _pendingSeq = my;
            _pendingKind = PendingKind.ToCallback;
            _pendingCallback = onCompleted;
            if (state.Events(this, out AnimancerEvent.Sequence events))
            {
                events.OnEnd = _sharedOnEnd;
            }
        }

        public void StopLayer(float? fadeOverride = null) {
            if (_animancer == null || _layerIndex <= 0) return;

            float fadeTime = fadeOverride ?? _fadeStop;

            var layer = _animancer.Layers[_layerIndex];
            AnimationUtils.StopLayer(layer, fadeTime);
        }

        // 共通OnEnd（クロージャなし・割当1回）
        private void OnEndShared()
        {
            if (_pendingSeq != _seq) return;

            switch (_pendingKind)
            {
                case PendingKind.ToLoop:
                    IsBlocking = false;
                    PlayLoop(_seq);
                    break;

                case PendingKind.ToCallback:
                    IsBlocking = false;
                    var cb = _pendingCallback; // 退避
                    _pendingCallback = null;
                    cb?.Invoke();
                    break;
            }

            _pendingKind = PendingKind.None;
        }

        public void InjectSpeed(float speed) {
            // LinearMixerの_loopがあれば速度を注入する。
            if (_loop != null && _loop is LinearMixerTransition mixer) {
                if (mixer.State == null) {
                    return;
                }
                mixer.State.Parameter = speed;
            }
        }
    }
}
  