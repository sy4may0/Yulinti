using UnityEngine;
using Animancer;
using Animancer.FSM;

namespace Yulinti.Animators.Generic
{
    /// <summary>
    /// Animancerのステートマシンを使用するMonoBehaviourの抽象基底クラス
    /// </summary>
    /// <typeparam name="TState">ステートの型</typeparam>
    [RequireComponent(typeof(AnimancerComponent))]
    public abstract class GenericStateMachineOwner<TState> : MonoBehaviour
        where TState : StateBehaviour
    {
        protected AnimancerComponent Animancer { get; private set; } = null!;
        protected readonly StateMachine<TState> FSM = new();

        public virtual void Awake()
        {
            if (!TryGetComponent(out Animancer))
            {
                Debug.LogError($"AnimancerComponent が見つかりません: {gameObject.name}");
                return;
            }

            // このOwner配下の StateBehaviour に Owner を注入（必要に応じて）
            var states = GetComponentsInChildren<TState>(true);
            foreach (var s in states)
            {
                if (s is GenericState<GenericStateMachineOwner<TState>, TState> gs)
                {
                    // 型が合わないのでキャストし直しが必要。継承チェーンに合わせて適宜変更。
                    // 実際は各派生Owner/Stateで Setup を呼ぶ方が安全です。
                }
                else if (s is GenericState<GenericStateMachineOwner<TState>, TState> _) { /* no-op */ }
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (Animancer == null) TryGetComponent(out Animancer);
        }
#endif

        // 便利ヘルパ：型安全に遷移要求
        protected bool Request<TTarget>() where TTarget : TState
            => FSM.TrySetState(GetComponentInChildren<TTarget>(true));
    }
}