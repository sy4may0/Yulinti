using VContainer;
using VContainer.Unity;
using UnityEngine;
using Yulinti.Unity.Anchora;
using Yulinti.Unity.Contractus;
using Yulinti.Unity.Ministeria;

namespace Yulinti.Rex {
    public sealed class RexIndexPrincipalis : LifetimeScope {
        [SerializeField] private AnchoraInput _anchora;

        protected override void Configure(IContainerBuilder builder) {
            builder.RegisterInstance<IAnchoraInput>(_anchora);

            FaberMinisteriaIndexPrincipalis.Initio(builder);

            builder.RegisterEntryPoint<PraefectusIndexPrincipalis>();
        }
    }
}