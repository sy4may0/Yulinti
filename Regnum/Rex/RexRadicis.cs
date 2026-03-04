// シーン管理等、全シーン管理を行うRoot LifetimeScope
// DontDestroyOnLoadを設定する。
using VContainer;
using VContainer.Unity;
using UnityEngine;
using Yulinti.Regnum.Anchora;
using Yulinti.Unity.Turris;
using Yulinti.Unity.Contractus;
using Yulinti.Unity.Velum;
using Yulinti.Exercitus.Dux;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Regnum.Praefectus;
using Yulinti.Regnum.Configuratio;

namespace Yulinti.Regnum.Rex {
    public sealed class RexRadicis: LifetimeScope {
        [SerializeField] private ConfiguratioTurris _configuratioTurris;
        [SerializeField] private AnchoraInput _anchora;
        [SerializeField] private AnchoraVelumRadicis _anchoraVelumRadicis;

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
            builder.RegisterInstance<IAnchoraVelumRadicis>(_anchoraVelumRadicis);

            builder.RegisterInstance<IConfiguratioTurris>(_configuratioTurris);
            builder.RegisterInstance<IConfiguratioTurrisPhantasma>(_configuratioTurris.Phantasma);

            FaberTurris.Initio(builder);
            FaberDucisRadicis.Initio(builder);
            FaberVelumRadicis.Initio(builder);

            builder.RegisterEntryPoint<PraefectusRadicis>();
        }
    }
}