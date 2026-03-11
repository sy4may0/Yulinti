using UnityEngine;
using VContainer;
using VContainer.Unity;
using Yulinti.ImperiumMaius.Anchora;
using Yulinti.ImperiumMaius.Praefectus;
using Yulinti.ImperiumMaius.Configuratio;
using Yulinti.Officia.Contractus;
using Yulinti.Officia.Ministeria;
using Yulinti.Officia.Velum;
using Yulinti.Auctoritas.Senatus;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.ImperiumDelegatum.Exercitus;

namespace Yulinti.ImperiumMaius.Augustus {
    public sealed class AugustusTestScene : LifetimeScope {
        [SerializeField] private AnchoraTestScene _anchora;
        [SerializeField] private ConfiguratioImperium _configuratio;

        protected override void Configure(IContainerBuilder builder) {
            Debug.Log("RexTestScene Configure");
            builder.RegisterInstance<IAnchoraCamera>(_anchora.AnchoraCamera);
            builder.RegisterInstance<IAnchoraPuellae>(_anchora.AnchoraPuellae);
            builder.RegisterInstance<IAnchoraPuellaeCrinis[]>(_anchora.AnchoraPuellaeCrinis);
            builder.RegisterInstance<IAnchoraPunctumViae[]>(_anchora.AnchoraPunctumViae);
            builder.RegisterInstance<IAnchoraCivis[]>(_anchora.AnchoraCivis);

            builder.RegisterInstance<IConfiguratioPuellaeFiguraeGenusDexter>(_configuratio.Ministeria.Puellae.Figura.GenusDex);
            builder.RegisterInstance<IConfiguratioPuellaeFiguraeGenusSinister>(_configuratio.Ministeria.Puellae.Figura.GenusSin);
            builder.RegisterInstance<IConfiguratioPuellaeFiguraePelvis>(_configuratio.Ministeria.Puellae.Figura.Pelvis);
            builder.RegisterInstance<IConfiguratioPuellaeRelationisTerrae>(_configuratio.Ministeria.Puellae.Relatio.Terrae);
            builder.RegisterInstance<IConfiguratioPuellaeAnimationum>(_configuratio.Ministeria.Puellae.Animatio);
            builder.RegisterInstance<IConfiguratioPuellaeLoci>(_configuratio.Ministeria.Puellae.Loci);
            builder.RegisterInstance<IConfiguratioCivis>(_configuratio.Ministeria.Civis);
            builder.RegisterInstance<IConfiguratioCivisLoci>(_configuratio.Ministeria.Civis.Loci);
            builder.RegisterInstance<IConfiguratioCivisAnimationum>(_configuratio.Ministeria.Civis.Animatio);
            builder.RegisterInstance<IConfiguratioCivisGenerator>(_configuratio.Ministeria.Civis.Generator);
            builder.RegisterInstance<IConfiguratioCivisVisae>(_configuratio.Ministeria.Civis.Visa);
            builder.RegisterInstance<IConfiguratioPunctumViae>(_configuratio.Ministeria.PunctumViae);

            builder.RegisterInstance<IConfiguratioExercitusPuellae>(_configuratio.Exercitus.ExercitusPuellae);
            builder.RegisterInstance<IConfiguratioExercitusCivis>(_configuratio.Exercitus.ExercitusCivis);

            FaberVelumTestScene.Initio(builder);
            FaberSenatusTestScene.Initio(builder);
            FaberMinisteriaTestScene.Initio(builder);
            FaberDucisTestScene.Initio(builder);

            builder.RegisterEntryPoint<PraefectusPraetorio>();
        }

        private void Start() {
            _anchora.Resolvo();
            _anchora.Validare();
        }
    }
}
