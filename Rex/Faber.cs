using VContainer;
using VContainer.Unity;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.Anchora;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Rex {
    internal sealed class Faber : LifetimeScope {
        private readonly Configuratio _configuratio;
        private readonly ResolvorAnchorae _resolvorAnchorae;

        public Faber(Configuratio configuratio, ResolvorAnchorae resolvorAnchorae) {
            _configuratio = configuratio;
            _resolvorAnchorae = resolvorAnchorae;

            _resolvorAnchorae.Resolvo();
            _resolvorAnchorae.Validare();
        }

        protected override void Configure(IContainerBuilder builder) {
            builder.RegisterInstance<IAnchoraCamera>(_resolvorAnchorae.AnchoraCamera);
            builder.RegisterInstance<IAnchoraInput>(_resolvorAnchorae.AnchoraInput);
            builder.RegisterInstance<IAnchoraPuellae>(_resolvorAnchorae.AnchoraPuellae);
            foreach (var anchoraPuellaeCrinis in _resolvorAnchorae.AnchoraPuellaeCrinis) {
                builder.RegisterInstance<IAnchoraPuellaeCrinis>(anchoraPuellaeCrinis);
            }
            foreach (var anchoraPunctumViae in _resolvorAnchorae.AnchoraPunctumViae) {
                builder.RegisterInstance<IAnchoraPunctumViae>(anchoraPunctumViae);
            }
            foreach (var anchoraCivis in _resolvorAnchorae.AnchoraCivis) {
                builder.RegisterInstance<IAnchoraCivis>(anchoraCivis);
            }
            foreach (var animation in _configuratio.Puellae.Animatio.Animationes) {
                builder.RegisterInstance<IConfiguratioPuellaeAnimationisContinuata>(animation);
            }
            builder.RegisterInstance<IConfiguratioPuellaeFiguraeGenusDexter>(_configuratio.Puellae.Figura.GenusDex);
            builder.RegisterInstance<IConfiguratioPuellaeFiguraeGenusSinister>(_configuratio.Puellae.Figura.GenusSin);
            builder.RegisterInstance<IConfiguratioPuellaeFiguraePelvis>(_configuratio.Puellae.Figura.Pelvis);
            builder.RegisterInstance<IConfiguratioPuellaeRelationisTerrae>(_configuratio.Puellae.Relatio.Terrae);
        }
    }
}