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
using Yulinti.Regnum.Praefectus;

namespace Yulinti.Regnum.Rex {
    public sealed class RexRadicis: LifetimeScope {
        [SerializeField] private AnchoraInput _anchora;

        private readonly IInspector _inspector = new Inspector();
        private readonly ICarnifex _carnifex = new CarnifexBasis();

        protected override void Awake() {
            // ロガーを登録する。
            Notarius.Inscribere(_inspector);
            Carnifex.Inscribere(_carnifex);

            base.Awake();
            DontDestroyOnLoad(gameObject);
        }

        protected override void Configure(IContainerBuilder builder) {
            builder.RegisterInstance<IAnchoraInput>(_anchora);

            FaberTurris.Initio(builder);

            builder.RegisterEntryPoint<PraefectusRadicis>();
        }
    }
}