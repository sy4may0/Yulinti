using UnityEngine;
using VContainer;
using VContainer.Unity;
using Yulinti.Imperium.Anchora;
using Yulinti.Imperium.Configuratio;
using Yulinti.ImperiumDelegatum.Exercitus;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;
using Yulinti.Officia.Ministeria;
using Yulinti.Officia.Velum;
using Yulinti.Auctoritas.Senatus;
using Yulinti.Imperium.Praefectus;

namespace Yulinti.Imperium.Augustus {
    public sealed class RexPortus : LifetimeScope {
        [SerializeField] private AnchoraPortus _anchora;
        [SerializeField] private AnchoraVelumPortus _anchoraVelumPortus;
        [SerializeField] private ConfiguratioRadicis _configuratio;

        protected override void Configure(IContainerBuilder builder) {
            Debug.Log("RexPortus Configure");
            builder.RegisterInstance<IAnchoraCamera>(_anchora.AnchoraCamera);
            builder.RegisterInstance<IAnchoraPuellae>(_anchora.AnchoraPuellae);
            builder.RegisterInstance<IAnchoraPuellaeCrinis[]>(_anchora.AnchoraPuellaeCrinis);
            builder.RegisterInstance<IAnchoraVelumPortus>(_anchoraVelumPortus);

            builder.RegisterInstance<IConfiguratioPuellaeFiguraeGenusDexter>(_configuratio.Puellae.Figura.GenusDex);
            builder.RegisterInstance<IConfiguratioPuellaeFiguraeGenusSinister>(_configuratio.Puellae.Figura.GenusSin);
            builder.RegisterInstance<IConfiguratioPuellaeFiguraePelvis>(_configuratio.Puellae.Figura.Pelvis);
            builder.RegisterInstance<IConfiguratioPuellaeRelationisTerrae>(_configuratio.Puellae.Relatio.Terrae);
            builder.RegisterInstance<IConfiguratioPuellaeAnimationum>(_configuratio.Puellae.Animatio);
            builder.RegisterInstance<IConfiguratioPuellaeLoci>(_configuratio.Puellae.Loci);

            builder.RegisterInstance<IConfiguratioExercitusPuellae>(_configuratio.ExercitusPuellae);

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