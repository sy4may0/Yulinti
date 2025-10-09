using Animancer;
using Animancer.FSM;
using UnityEngine;

namespace Yulinti.Animators.Generic
{
    /// <summary>
    /// Animancerステートの抽象基底クラス
    /// </summary>
    /// <typeparam name="TOwner">オーナーの型</typeparam>
    /// <typeparam name="TState">ステートの型</typeparam>
    public abstract class GenericState<TOwner, TState> : StateBehaviour
        where TOwner : GenericStateMachineOwner<TState>
        where TState : StateBehaviour
    {
        [Header("Base Animation")]
        [SerializeField] private ClipTransition Transition;
        [SerializeField] private bool _playOnEnter = true;
        [SerializeField] private bool _isLoop = true;

        protected AnimancerComponent? Animancer { get; private set; }
        protected TOwner? Owner { get; private set; }

        // 基底に Initialize(AnimancerComponent) がある前提で override
        public override void Initialize(AnimancerComponent animancer)
        {
            Animancer = animancer;
            // Owner は Owner 側から別途注入（SetupOwner）する
        }

        /// <summary>Owner 注入用のフック（Owner から呼ぶ）</summary>
        public virtual void SetupOwner(TOwner owner) => Owner = owner;

        public override void OnEnterState()
        {
            if (Animancer == null) { Debug.LogError("Animancer not set."); return; }
            if (!_playOnEnter) return;

            var t = Transition;
            if (t == null) return;

            // 同一トランジション再入時の無駄再生を抑止（必要なら）
            var current = Animancer.States.Current;
            if (current != null && current.Transition == t) return;

            Animancer.Play(t); // t 側の Fade 設定を尊重
        }
    }
}