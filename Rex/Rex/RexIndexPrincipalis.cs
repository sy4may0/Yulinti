using VContainer;
using VContainer.Unity;
using UnityEngine;
using Yulinti.MinisteriaUnity.Anchora;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.MinisteriaUnity.MinisteriaRationis;

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