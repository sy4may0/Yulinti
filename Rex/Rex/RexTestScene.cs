using UnityEngine;
using VContainer;
using VContainer.Unity;
using Yulinti.MinisteriaUnity.Anchora;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Dux.Exercitus;
using Yulinti.Velum.Indicium;

namespace Yulinti.Rex {
    public sealed class RexTestScene : LifetimeScope {
        [SerializeField] private AnchoraTestScene _anchora;
        [SerializeField] private Configuratio _configuratio;

        protected override void Configure(IContainerBuilder builder) {
            Debug.Log("RexTestScene Configure");
            builder.RegisterInstance<IAnchoraCamera>(_anchora.AnchoraCamera);
            builder.RegisterInstance<IAnchoraInput>(_anchora.AnchoraInput);
            builder.RegisterInstance<IAnchoraPuellae>(_anchora.AnchoraPuellae);
            builder.RegisterInstance<IAnchoraPuellaeCrinis[]>(_anchora.AnchoraPuellaeCrinis);
            builder.RegisterInstance<IAnchoraPunctumViae[]>(_anchora.AnchoraPunctumViae);
            builder.RegisterInstance<IAnchoraCivis[]>(_anchora.AnchoraCivis);

            builder.RegisterInstance<IConfiguratioPuellaeFiguraeGenusDexter>(_configuratio.Puellae.Figura.GenusDex);
            builder.RegisterInstance<IConfiguratioPuellaeFiguraeGenusSinister>(_configuratio.Puellae.Figura.GenusSin);
            builder.RegisterInstance<IConfiguratioPuellaeFiguraePelvis>(_configuratio.Puellae.Figura.Pelvis);
            builder.RegisterInstance<IConfiguratioPuellaeRelationisTerrae>(_configuratio.Puellae.Relatio.Terrae);
            builder.RegisterInstance<IConfiguratioPuellaeAnimationis>(_configuratio.Puellae.Animatio);
            builder.RegisterInstance<IConfiguratioPuellaeLoci>(_configuratio.Puellae.Loci);
            builder.RegisterInstance<IConfiguratioCivis>(_configuratio.Civis);
            builder.RegisterInstance<IConfiguratioCivisLoci>(_configuratio.Civis.Loci);
            builder.RegisterInstance<IConfiguratioCivisAnimationis>(_configuratio.Civis.Animatio);
            builder.RegisterInstance<IConfiguratioCivisGenerator>(_configuratio.Civis.Generator);
            builder.RegisterInstance<IConfiguratioCivisVisae>(_configuratio.Civis.Visa);
            builder.RegisterInstance<IConfiguratioPunctumViae>(_configuratio.PunctumViae);

            builder.RegisterInstance<IConfiguratioExercitusPuellae>(_configuratio.ExercitusPuellae);
            builder.RegisterInstance<IConfiguratioExercitusCivis>(_configuratio.ExercitusCivis);

            FaberMinisteriaTestScene.Initio(builder);
            FaberDucisTestScene.Initio(builder);
            FaberTestScene.Initio(builder);

            builder.RegisterComponentInHierarchy<VelumTestScene>();

            builder.RegisterEntryPoint<PraefectusTestScene>();
        }

        private void Start() {
            _anchora.Resolvo();
            _anchora.Validare();
        }
    }
}