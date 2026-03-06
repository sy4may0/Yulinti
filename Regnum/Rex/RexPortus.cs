using UnityEngine;
using VContainer;
using VContainer.Unity;
using Yulinti.Regnum.Anchora;
using Yulinti.Regnum.Configuratio;
using Yulinti.Unity.Contractus;
using Yulinti.Exercitus.Dux;
using Yulinti.Unity.Ministeria;
using Yulinti.Exercitus.Contractus;
using Yulinti.Regnum.Praefectus;
using Yulinti.Unity.Velum;

namespace Yulinti.Regnum.Rex {
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
            builder.RegisterInstance<IConfiguratioPuellaeAnimationis>(_configuratio.Puellae.Animatio);
            builder.RegisterInstance<IConfiguratioPuellaeLoci>(_configuratio.Puellae.Loci);

            builder.RegisterInstance<IConfiguratioExercitusPuellae>(_configuratio.ExercitusPuellae);

            FaberMinisteriaPortus.Initio(builder);
            FaberDucisPortus.Initio(builder);
            FaberVelumPortus.Initio(builder);


            // [TODO] PraefectusTestSceneは共通。Testを外してBasisにしていい。
            builder.RegisterEntryPoint<PraefectusPortus>();

        }
    }
}