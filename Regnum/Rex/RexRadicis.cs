// シーン管理等、全シーン管理を行うRoot LifetimeScope
// DontDestroyOnLoadを設定する。
using VContainer;
using VContainer.Unity;
using UnityEngine;
using Yulinti.Regnum.Anchora;
using Yulinti.Unity.Turris;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.Regnum.Rex {
    public sealed class RexRadicis: LifetimeScope {
        [SerializeField] private AnchoraInput _anchora;

        private readonly IInspector _inspector = new Inspector();

        protected override void Awake() {
            // ロガーを登録する。
            Notarius.Inscribere(_inspector);
            Carnifex.Inscribere(_inspector);

            base.Awake();
            DontDestroyOnLoad(gameObject);
        }

        protected override void Configure(IContainerBuilder builder) {
            builder.RegisterInstance<IAnchoraInput>(_anchora);

            FaberTurris.Initio(builder);
        }
    }
}