using VContainer;
using VContainer.Unity;
using UnityEngine;
using Yulinti.Regnum.Anchora;
using Yulinti.Unity.Contractus;
using Yulinti.Unity.Ministeria;
using Yulinti.Unity.Velum;
using Yulinti.Regnum.Praefectus;
using Yulinti.Exercitus.Dux;

namespace Yulinti.Regnum.Rex {
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