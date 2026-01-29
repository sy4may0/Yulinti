// シーン管理等、全シーン管理を行うRoot LifetimeScope
// DontDestroyOnLoadを設定する。
using VContainer;
using VContainer.Unity;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Deus {
    public sealed class Deus: LifetimeScope {
        protected override void Awake() {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }

        protected override void Configure(IContainerBuilder builder) {
            // 全シーン共通のサービスを起動する
            builder.RegisterInstance<ITurrisMundus>(new TurrisMundus());
        }
    }
}