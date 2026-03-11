using VContainer;
using VContainer.Unity;
using UnityEngine;
using Yulinti.Imperium.Anchora;
using Yulinti.Officia.Contractus;
using Yulinti.Officia.Ministeria;
using Yulinti.Officia.Velum;
using Yulinti.Imperium.Praefectus;
using Yulinti.ImperiumDelegatum.Exercitus;

namespace Yulinti.Imperium.Augustus {
    public sealed class RexIndexPrincipalis : LifetimeScope {
        [SerializeField] private AnchoraVelumIndexusPrincipalis _anchora;
        [SerializeField] private AnchoraVelumSalsamenti _anchoraSalsamenti;

        protected override void Configure(IContainerBuilder builder) {
            UnityEngine.Debug.Log("RexIndexPrincipalis Configure");
            builder.RegisterInstance<IAnchoraVelumIndexusPrincipalis>(_anchora);
            builder.RegisterInstance<IAnchoraVelumSalsamenti>(_anchoraSalsamenti);

            FaberMinisteriaIndexPrincipalis.Initio(builder);
            FaberDucisIndexusPrincipalis.Initio(builder);
            FaberVelumIndexusPrincipalis.Initio(builder);

            builder.RegisterEntryPoint<PraefectusIndexPrincipalis>();
        }
    }
}