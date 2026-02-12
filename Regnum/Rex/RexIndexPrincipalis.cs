using VContainer;
using VContainer.Unity;
using UnityEngine;
using Yulinti.Regnum.Anchora;
using Yulinti.Unity.Contractus;
using Yulinti.Unity.Ministeria;
using Yulinti.Unity.Velum;
using Yulinti.Regnum.Praefectus;

namespace Yulinti.Regnum.Rex {
    public sealed class RexIndexPrincipalis : LifetimeScope {
        [SerializeField] private AnchoraVelumIndexusPrincipalis _anchora;

        protected override void Configure(IContainerBuilder builder) {
            builder.RegisterInstance<IAnchoraVelumIndexusPrincipalis>(_anchora);

            FaberMinisteriaIndexPrincipalis.Initio(builder);
            FarberVelumIndexusPrincipalis.Initio(builder);

            builder.RegisterEntryPoint<PraefectusIndexPrincipalis>();
        }
    }
}