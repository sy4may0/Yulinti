using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Unity.Turris {
    public sealed class TurrisPhantasmaPuellaePersonae : ITurrisPhantasmaPuellaePersonae {
        private readonly PhantasmaPuellaePersonae _phantasmaPuellaePersonae;

        public TurrisPhantasmaPuellaePersonae(IConfiguratioTurrisPhantasma configuratioTurrisPhantasma) {
            ResolutorPuellaePersonae resolutorPuellaePersonae = new ResolutorPuellaePersonae(configuratioTurrisPhantasma);
            _phantasmaPuellaePersonae = new PhantasmaPuellaePersonae(resolutorPuellaePersonae);
        }

        public void Initare(IOstiumSalsamentiPuellaePersonae ostiumSalsamentiPuellae) {
            _phantasmaPuellaePersonae.Initare(ostiumSalsamentiPuellae);
        }

        public void AddeAnimamGradus(IDGradusPuellaePersonae idGradusPuellaePersonae, int anima) {
            switch (idGradusPuellaePersonae) {
                case IDGradusPuellaePersonae.Luxuriosus:
                    _phantasmaPuellaePersonae.RenovareAnimumGradusLuxuriosus(
                        _phantasmaPuellaePersonae.AnimaLuxuriosus + anima
                    );
                    break;
                case IDGradusPuellaePersonae.Exhibitus:
                    _phantasmaPuellaePersonae.RenovareAnimumGradusExhibitus(
                        _phantasmaPuellaePersonae.AnimaExhibitus + anima
                    );
                    break;
                case IDGradusPuellaePersonae.Perversus:
                    _phantasmaPuellaePersonae.RenovareAnimumGradusPerversus(
                        _phantasmaPuellaePersonae.AnimaPerversus + anima
                    );
                    break;
                case IDGradusPuellaePersonae.QuaeritDolore:
                    _phantasmaPuellaePersonae.RenovareAnimumGradusQuaeritDolore(
                        _phantasmaPuellaePersonae.AnimaQuaeritDolore + anima
                    );
                    break;
                default:
                    break;
            }
        }

        public void AddeAnimamSensus(IDSensusPuellaePersonae idSensusPuellaePersonae, int anima) {
            switch (idSensusPuellaePersonae) {
                case IDSensusPuellaePersonae.Papillae:
                    _phantasmaPuellaePersonae.RenovareAnimumSensusPapillae(
                        _phantasmaPuellaePersonae.AnimaPapillae + anima
                    );
                    break;
                case IDSensusPuellaePersonae.Landicae:
                    _phantasmaPuellaePersonae.RenovareAnimumSensusLandicae(
                        _phantasmaPuellaePersonae.AnimaLandicae + anima
                    );
                    break;
                case IDSensusPuellaePersonae.Vaginae:
                    _phantasmaPuellaePersonae.RenovareAnimumSensusVaginae(
                        _phantasmaPuellaePersonae.AnimaVaginae + anima
                    );
                    break;
                case IDSensusPuellaePersonae.Ani:
                    _phantasmaPuellaePersonae.RenovareAnimumSensusAni(
                        _phantasmaPuellaePersonae.AnimaAni + anima
                    );
                    break;
                case IDSensusPuellaePersonae.Ausculum:
                    _phantasmaPuellaePersonae.RenovareAnimumSensusAusculum(
                        _phantasmaPuellaePersonae.AnimaAusculum + anima
                    );
                    break;
                case IDSensusPuellaePersonae.Corporis:
                    _phantasmaPuellaePersonae.RenovareAnimumSensusCorporis(
                        _phantasmaPuellaePersonae.AnimaCorporis + anima
                    );
                    break;
                default:
                    break;
            }
        }

        public IPhantasmaPuellaePersonae Legere() {
            return _phantasmaPuellaePersonae;
        }
    }
}
