using VContainer;
using VContainer.Unity;
using UnityEngine;
using Yulinti.ImperiumMaius.Anchora;
using Yulinti.Officia.Contractus;
using Yulinti.Officia.Ministeria;
using Yulinti.Officia.Velum;
using Yulinti.Auctoritas.Senatus;
using Yulinti.ImperiumMaius.Praefectus;
using Yulinti.ImperiumDelegatum.Exercitus;

namespace Yulinti.ImperiumMaius.Augustus {
    public sealed class AugustusIndexPrincipalis : LifetimeScope {
        [SerializeField] private AnchoraVelumIndexusPrincipalis _anchora;
        [SerializeField] private AnchoraVelumSalsamenti _anchoraSalsamenti;

        protected override void Configure(IContainerBuilder builder) {
            UnityEngine.Debug.Log("RexIndexPrincipalis Configure");
            builder.RegisterInstance<IAnchoraVelumIndexusPrincipalis>(_anchora);
            builder.RegisterInstance<IAnchoraVelumSalsamenti>(_anchoraSalsamenti);

            FaberVelumIndexusPrincipalis.Initio(builder);
            FaberSenatusIndexusPrincipalis.Initio(builder);
            FaberMinisteriaIndexPrincipalis.Initio(builder);
            FaberDucisIndexusPrincipalis.Initio(builder);

            builder.RegisterEntryPoint<PraefectusPraetorio>();
        }
    }
}