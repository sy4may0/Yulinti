using Animancer;
using UnityEngine;
using System;
using Yulinti.CharacterControllSuite;

// TIPS
// _start, _loop, _stopの中身はPlay()再生されるまでnull。気をつけろ。
namespace Yulinti.CharacterControllSuite
{
    public class ThreePhaseAnimationPlan : IAnimationPlan
    {
        private readonly IAnimationFacade _start, _loop, _stop;
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
            IAnimationFacade start,
            IAnimationFacade loop,
            IAnimationFacade stop,
            int layerIndex
        ){
            _start = start;
            _loop = loop;
            _stop = stop;
            _layerIndex = layerIndex;

            _blockInStart = false;
            _blockInStop = false;
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

            _start.Play(_layerIndex);

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
            if (_layerIndex < 0 _layerIndex >= _animancer.Layers.Count) { onCompleted?.Invoke(); return; }
            int my = ++_seq;
            if (_stop == null)
            {
                IsBlocking = false; // Stopなし：即完了
                onCompleted?.Invoke();
                return;
            }

            IsBlocking = _blockInStop;
            
            _stop.Play(_layerIndex);

            _pendingSeq = my;
            _pendingKind = PendingKind.ToCallback;
            _pendingCallback = onCompleted;
            _stop.SetOnEndCallback(_layerIndex, _sharedOnEnd);
        }

        public void StopLayer() {
            if (_layerIndex <= 0) return;
            // ここわかりずらいから注釈
            // IAnimancerFacadeが持つAnimancerComponentは、すべて同じインスタンスを期待する。
            // そのため、_stop/_start/_loopどれでStopLayer()しても
            _stop.StopLayer(_layerIndex);
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
    }
}
  