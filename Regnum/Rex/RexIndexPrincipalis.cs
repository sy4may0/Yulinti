using VContainer;
using VContainer.Unity;
using UnityEngine;
using Yulinti.Regnum.Anchora;
using Yulinti.Unity.Contractus;
using Yulinti.Unity.Ministeria;
using Yulinti.Regnum.Praefectus;

namespace Yulinti.Regnum.Rex {
    public sealed class RexIndexPrincipalis : LifetimeScope {
        protected override void Configure(IContainerBuilder builder) {
            FaberMinisteriaIndexPrincipalis.Initio(builder);

            builder.RegisterEntryPoint<PraefectusIndexPrincipalis>();
        }
    }
}