using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Officia.Turris {
    internal sealed class TurrisPhantasmaPuellaePersonae : ITurrisPhantasmaPuellaePersonae {
        private readonly PhantasmaPuellaePersonae _phantasmaPuellaePersonae;

        public TurrisPhantasmaPuellaePersonae(
            PhantasmaPuellaePersonae phantasmaPuellaePersonae
        ) {
            _phantasmaPuellaePersonae = phantasmaPuellaePersonae;
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
            _phantasmaPuellaePersonae.Normare();
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
            _phantasmaPuellaePersonae.Normare();
        }
    }
}
