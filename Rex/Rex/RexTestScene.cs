using UnityEngine;
using VContainer;
using VContainer.Unity;
using Yulinti.MinisteriaUnity.Anchora;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Dux.Exercitus;

namespace Yulinti.Rex {
    public sealed class RexTestScene : LifetimeScope {
        [SerializeField] private AnchoraTestScene _anchora;
        [SerializeField] private Configuratio _configuratio;
        [SerializeField] private ConfiguratioExercitusPuellae _configuratioExercitusPuellae;

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

            builder.RegisterInstance<IConfiguratioPuellaeStatuum>(_configuratioExercitusPuellae.Statuum);
            builder.RegisterInstance<IConfiguratioPuellaeActionisSecundarius>(_configuratioExercitusPuellae.ActionisSecundarius);

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