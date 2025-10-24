using Animancer;
using UnityEngine;
using System;
using Yulinti.CharacterControllSuite;

// TIPS
namespace Yulinti.CharacterControllSuite
{
    public class ThreePhaseAnimationPlan : IAnimationPlan
    {
        private readonly ThreePhaseAnimationPlayer _animationPlayer;
        private readonly int _layerIndex;

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
            ThreePhaseAnimationPlayer animationPlayer
            bool blockInStart,
            bool blockInStop
        ){
            _animationPlayer = animationPlayer;
            _blockInStart = blockInStart;
            _blockInStop = blockInStop;
            IsBlocking = false;

            _sharedOnEnd = OnEndShared; // ここで1回だけ作る
        }

        // === Play: Start→(OnEnd)→Loop ===
        public void Play()
        {
            if (_layerIndex < 0) return;
            int my = ++_seq;
            if (_start == null)
            {
                // Startなし：即Loopへ（1フェーズ対応）
                IsBlocking = false;
                PlayLoop(my);
                return;
            }

            IsBlocking = _blockInStart;

            _start.PlayStart();

            // Start終了で Loop へ
            _pendingSeq = my;
            _pendingKind = PendingKind.ToLoop;
            _pendingCallback = null;
            _start.SetOnEndCallback(_layerIndex, _sharedOnEnd);
        }

        private void PlayLoop(int my)
        {
            if (my != _seq) return;
            if (_loop == null) { /* ワンショット終端 */ return; }

            _loop.Play(_layerIndex);
        }

        // === Stop: Stop再生→完了でコールバック。無ければ即コールバック ===
        public void Stop(Action onCompleted = null)
        {
            int layerIndex = _animationPlayer.GetLayerIndex();
            if (layerIndex < 0) { onCompleted?.Invoke(); return; }
            int my = ++_seq;
            if (_animationPlayer == null)
            {
                IsBlocking = false; // Stopなし：即完了
                onCompleted?.Invoke();
                return;
            }

            IsBlocking = _blockInStop;
            
            _animationPlayer.PlayEnd();


            _pendingSeq = my;
            _pendingKind = PendingKind.ToCallback;
            _pendingCallback = onCompleted;
            _animationPlayer.SetOnEndCallback(_sharedOnEnd);
        }

        public void StopLayer() {
            _animationPlayer.StopLayer();
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
            // _animationPlayerがIAnimancerFacadeSpeedInjectableを実装している場合は、speedを注入する。
            if (_animationPlayer is IAnimancerFacadeSpeedInjectable speedInjectable) {
                speedInjectable.InjectSpeed(speed);
            }
        }
    }
}
  