// シーン管理等、全シーン管理を行うRoot LifetimeScope
// DontDestroyOnLoadを設定する。
using VContainer;
using VContainer.Unity;
using UnityEngine;
using Yulinti.Imperium.Anchora;
using Yulinti.Officia.Turris;
using Yulinti.Officia.Contractus;
using Yulinti.Officia.Velum;
using Yulinti.ImperiumDelegatum.Exercitus;
using Yulinti.Auctoritas.Senatus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Imperium.Praefectus;
using Yulinti.Imperium.Configuratio;

namespace Yulinti.Imperium.Augustus {
    public sealed class RexRadicis: LifetimeScope {
        [SerializeField] private ConfiguratioTurris _configuratioTurris;
        [SerializeField] private AnchoraInput _anchora;
        [SerializeField] private AnchoraVelumRadicis _anchoraVelumRadicis;
        [SerializeField] private AnchoraSoniVeli _anchoraSoniVeli;

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
            builder.RegisterInstance<IAnchoraSoniVeli>(_anchoraSoniVeli);

            builder.RegisterInstance<IConfiguratioTurris>(_configuratioTurris);
            builder.RegisterInstance<IConfiguratioTurrisPhantasma>(_configuratioTurris.Phantasma);
            builder.RegisterInstance<IConfiguratioSonorumVeli>(_configuratioTurris.SonorumVeli);

            // Faber
            FaberVelumRadicis.Initio(builder);
            FaberSenatusRadicis.Initio(builder);
            FaberTurris.Initio(builder);

            builder.RegisterEntryPoint<PraefectusPraetorioRadicis>();
        }
    }
}