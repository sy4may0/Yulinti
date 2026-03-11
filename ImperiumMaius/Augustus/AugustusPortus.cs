using UnityEngine;
using VContainer;
using VContainer.Unity;
using Yulinti.ImperiumMaius.Anchora;
using Yulinti.ImperiumMaius.Configuratio;
using Yulinti.ImperiumDelegatum.Exercitus;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;
using Yulinti.Officia.Ministeria;
using Yulinti.Officia.Velum;
using Yulinti.Auctoritas.Senatus;
using Yulinti.ImperiumMaius.Praefectus;

namespace Yulinti.ImperiumMaius.Augustus {
    public sealed class AugustusPortus : LifetimeScope {
        [SerializeField] private AnchoraPortus _anchora;
        [SerializeField] private AnchoraVelumPortus _anchoraVelumPortus;
        [SerializeField] private ConfiguratioImperium _configuratio;

        protected override void Configure(IContainerBuilder builder) {
            Debug.Log("RexPortus Configure");
            builder.RegisterInstance<IAnchoraCamera>(_anchora.AnchoraCamera);
            builder.RegisterInstance<IAnchoraPuellae>(_anchora.AnchoraPuellae);
            builder.RegisterInstance<IAnchoraPuellaeCrinis[]>(_anchora.AnchoraPuellaeCrinis);
            builder.RegisterInstance<IAnchoraVelumPortus>(_anchoraVelumPortus);

            builder.RegisterInstance<IConfiguratioPuellaeFiguraeGenusDexter>(_configuratio.Ministeria.Puellae.Figura.GenusDex);
            builder.RegisterInstance<IConfiguratioPuellaeFiguraeGenusSinister>(_configuratio.Ministeria.Puellae.Figura.GenusSin);
            builder.RegisterInstance<IConfiguratioPuellaeFiguraePelvis>(_configuratio.Ministeria.Puellae.Figura.Pelvis);
            builder.RegisterInstance<IConfiguratioPuellaeRelationisTerrae>(_configuratio.Ministeria.Puellae.Relatio.Terrae);
            builder.RegisterInstance<IConfiguratioPuellaeAnimationum>(_configuratio.Ministeria.Puellae.Animatio);
            builder.RegisterInstance<IConfiguratioPuellaeLoci>(_configuratio.Ministeria.Puellae.Loci);

            builder.RegisterInstance<IConfiguratioExercitusPuellae>(_configuratio.Exercitus.ExercitusPuellae);

            FaberVelumPortus.Initio(builder);
            FaberSenatusPortus.Initio(builder);
            FaberMinisteriaPortus.Initio(builder);
            FaberDucisPortus.Initio(builder);

            // [TODO] PraefectusTestSceneは共通。Testを外してBasisにしていい。
            builder.RegisterEntryPoint<PraefectusPraetorio>();
        }

        protected override void OnDestroy() {
            Debug.Log("RexPortus OnDestroy");
            base.OnDestroy();
        }
    }
}