using UnityEngine;
using VContainer;
using VContainer.Unity;
using Yulinti.Imperium.Anchora;
using Yulinti.Imperium.Praefectus;
using Yulinti.Imperium.Configuratio;
using Yulinti.Officia.Contractus;
using Yulinti.Officia.Ministeria;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.ImperiumDelegatum.Exercitus;

namespace Yulinti.Imperium.Augustus {
    public sealed class RexTestScene : LifetimeScope {
        [SerializeField] private AnchoraTestScene _anchora;
        [SerializeField] private ConfiguratioRadicis _configuratio;

        protected override void Configure(IContainerBuilder builder) {
            Debug.Log("RexTestScene Configure");
            builder.RegisterInstance<IAnchoraCamera>(_anchora.AnchoraCamera);
            builder.RegisterInstance<IAnchoraPuellae>(_anchora.AnchoraPuellae);
            builder.RegisterInstance<IAnchoraPuellaeCrinis[]>(_anchora.AnchoraPuellaeCrinis);
            builder.RegisterInstance<IAnchoraPunctumViae[]>(_anchora.AnchoraPunctumViae);
            builder.RegisterInstance<IAnchoraCivis[]>(_anchora.AnchoraCivis);

            builder.RegisterInstance<IConfiguratioPuellaeFiguraeGenusDexter>(_configuratio.Puellae.Figura.GenusDex);
            builder.RegisterInstance<IConfiguratioPuellaeFiguraeGenusSinister>(_configuratio.Puellae.Figura.GenusSin);
            builder.RegisterInstance<IConfiguratioPuellaeFiguraePelvis>(_configuratio.Puellae.Figura.Pelvis);
            builder.RegisterInstance<IConfiguratioPuellaeRelationisTerrae>(_configuratio.Puellae.Relatio.Terrae);
            builder.RegisterInstance<IConfiguratioPuellaeAnimationum>(_configuratio.Puellae.Animatio);
            builder.RegisterInstance<IConfiguratioPuellaeLoci>(_configuratio.Puellae.Loci);
            builder.RegisterInstance<IConfiguratioCivis>(_configuratio.Civis);
            builder.RegisterInstance<IConfiguratioCivisLoci>(_configuratio.Civis.Loci);
            builder.RegisterInstance<IConfiguratioCivisAnimationum>(_configuratio.Civis.Animatio);
            builder.RegisterInstance<IConfiguratioCivisGenerator>(_configuratio.Civis.Generator);
            builder.RegisterInstance<IConfiguratioCivisVisae>(_configuratio.Civis.Visa);
            builder.RegisterInstance<IConfiguratioPunctumViae>(_configuratio.PunctumViae);

            builder.RegisterInstance<IConfiguratioExercitusPuellae>(_configuratio.ExercitusPuellae);
            builder.RegisterInstance<IConfiguratioExercitusCivis>(_configuratio.ExercitusCivis);

            FaberMinisteriaTestScene.Initio(builder);
            FaberDucisTestScene.Initio(builder);

            builder.RegisterEntryPoint<PraefectusTestScene>();
        }

        private void Start() {
            _anchora.Resolvo();
            _anchora.Validare();
        }
    }
}
