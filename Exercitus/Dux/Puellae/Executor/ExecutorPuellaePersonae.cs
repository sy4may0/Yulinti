using Yulinti.Exercitus.Contractus;
namespace Yulinti.Exercitus.Dux {
    internal sealed class PhantasmaDtAnimae {
        private int _phantasmaDtAnimaeLuxuriosus;
        private int _phantasmaDtAnimaeExhibitus;
        private int _phantasmaDtAnimaePerversus;
        private int _phantasmaDtAnimaeQuaeritDolore;
        private int _phantasmaDtAnimaePapillae;
        private int _phantasmaDtAnimaeLandicae;
        private int _phantasmaDtAnimaeVaginae;
        private int _phantasmaDtAnimaeAni;
        private int _phantasmaDtAnimaeAusculum;
        private int _phantasmaDtAnimaeCorporis;

        public PhantasmaDtAnimae() {
            _phantasmaDtAnimaeLuxuriosus = 0;
            _phantasmaDtAnimaeExhibitus = 0;
            _phantasmaDtAnimaePerversus = 0;
            _phantasmaDtAnimaeQuaeritDolore = 0;
            _phantasmaDtAnimaePapillae = 0;
            _phantasmaDtAnimaeLandicae = 0;
            _phantasmaDtAnimaeVaginae = 0;
            _phantasmaDtAnimaeAni = 0;
            _phantasmaDtAnimaeAusculum = 0;
            _phantasmaDtAnimaeCorporis = 0;
        }

        public int PhantasmaDtAnimaeLuxuriosus => _phantasmaDtAnimaeLuxuriosus;
        public int PhantasmaDtAnimaeExhibitus => _phantasmaDtAnimaeExhibitus;
        public int PhantasmaDtAnimaePerversus => _phantasmaDtAnimaePerversus;
        public int PhantasmaDtAnimaeQuaeritDolore => _phantasmaDtAnimaeQuaeritDolore;
        public int PhantasmaDtAnimaePapillae => _phantasmaDtAnimaePapillae;
        public int PhantasmaDtAnimaeLandicae => _phantasmaDtAnimaeLandicae;
        public int PhantasmaDtAnimaeVaginae => _phantasmaDtAnimaeVaginae;
        public int PhantasmaDtAnimaeAni => _phantasmaDtAnimaeAni;
        public int PhantasmaDtAnimaeAusculum => _phantasmaDtAnimaeAusculum;
        public int PhantasmaDtAnimaeCorporis => _phantasmaDtAnimaeCorporis;

        public void Addo(
            int dtAnimaeLuxuriosus = 0,
            int dtAnimaeExhibitus = 0,
            int dtAnimaePerversus = 0,
            int dtAnimaeQuaeritDolore = 0,
            int dtAnimaePapillae = 0,
            int dtAnimaeLandicae = 0,
            int dtAnimaeVaginae = 0,
            int dtAnimaeAni = 0,
            int dtAnimaeAusculum = 0,
            int dtAnimaeCorporis = 0
        ) {
            _phantasmaDtAnimaeLuxuriosus = _phantasmaDtAnimaeLuxuriosus + dtAnimaeLuxuriosus;
            _phantasmaDtAnimaeExhibitus = _phantasmaDtAnimaeExhibitus + dtAnimaeExhibitus;
            _phantasmaDtAnimaePerversus = _phantasmaDtAnimaePerversus + dtAnimaePerversus;
            _phantasmaDtAnimaeQuaeritDolore = _phantasmaDtAnimaeQuaeritDolore + dtAnimaeQuaeritDolore;
            _phantasmaDtAnimaePapillae = _phantasmaDtAnimaePapillae + dtAnimaePapillae;
            _phantasmaDtAnimaeLandicae = _phantasmaDtAnimaeLandicae + dtAnimaeLandicae;
            _phantasmaDtAnimaeVaginae = _phantasmaDtAnimaeVaginae + dtAnimaeVaginae;
            _phantasmaDtAnimaeAni = _phantasmaDtAnimaeAni + dtAnimaeAni;
            _phantasmaDtAnimaeAusculum = _phantasmaDtAnimaeAusculum + dtAnimaeAusculum;
            _phantasmaDtAnimaeCorporis = _phantasmaDtAnimaeCorporis + dtAnimaeCorporis;
        }

        public void Purgere() {
            _phantasmaDtAnimaeLuxuriosus = 0;
            _phantasmaDtAnimaeExhibitus = 0;
            _phantasmaDtAnimaePerversus = 0;
            _phantasmaDtAnimaeQuaeritDolore = 0;
            _phantasmaDtAnimaePapillae = 0;
            _phantasmaDtAnimaeLandicae = 0;
            _phantasmaDtAnimaeVaginae = 0;
            _phantasmaDtAnimaeAni = 0;
            _phantasmaDtAnimaeAusculum = 0;
            _phantasmaDtAnimaeCorporis = 0;
        }
    }

    // このExecutorはシーン開始時に初期化、シーン完了時のリザルト処理でConfirmareを実行する。
    internal sealed class ExecutorPuellaePersonae : IExecutorPuellae {
        private readonly ITurrisPhantasmaPuellaePersonae _turrisPhantasmaPuellaePersonae;
        private readonly PhantasmaDtAnimae _phantasmaDtAnimae;

        private bool _estConfirmare;

        public ExecutorPuellaePersonae(ITurrisPhantasmaPuellaePersonae turrisPhantasmaPuellaePersonae) {
            _turrisPhantasmaPuellaePersonae = turrisPhantasmaPuellaePersonae;
            _phantasmaDtAnimae = new PhantasmaDtAnimae();
            _estConfirmare = false;
        }

        public void Initare() {
            Purgare();
        }

        public void Primum() {
            Purgare();
        }

        public void Executare(
            IOrdinatioPuellaePersonae personae
        ) {
            _phantasmaDtAnimae.Addo(
                dtAnimaeLuxuriosus: personae.DtAnimaeLuxuriosus,
                dtAnimaeExhibitus: personae.DtAnimaeExhibitus,
                dtAnimaePerversus: personae.DtAnimaePerversus,
                dtAnimaeQuaeritDolore: personae.DtAnimaeQuaeritDolore,
                dtAnimaePapillae: personae.DtAnimaePapillae,
                dtAnimaeLandicae: personae.DtAnimaeLandicae,
                dtAnimaeVaginae: personae.DtAnimaeVaginae,
                dtAnimaeAni: personae.DtAnimaeAni,
                dtAnimaeAusculum: personae.DtAnimaeAusculum,
                dtAnimaeCorporis: personae.DtAnimaeCorporis
            );
            _estConfirmare = true;
        }

        public void Confirmare() {
            // Executareが一度も実行されていない場合、Confirmareを実行しない。
            if (!_estConfirmare) {
                return;
            }
            _turrisPhantasmaPuellaePersonae.AddeAnimamGradus(
                IDGradusPuellaePersonae.Luxuriosus,
                _phantasmaDtAnimae.PhantasmaDtAnimaeLuxuriosus
            );
            _turrisPhantasmaPuellaePersonae.AddeAnimamGradus(
                IDGradusPuellaePersonae.Exhibitus,
                _phantasmaDtAnimae.PhantasmaDtAnimaeExhibitus
            );
            _turrisPhantasmaPuellaePersonae.AddeAnimamGradus(
                IDGradusPuellaePersonae.Perversus,
                _phantasmaDtAnimae.PhantasmaDtAnimaePerversus
            );
            _turrisPhantasmaPuellaePersonae.AddeAnimamGradus(
                IDGradusPuellaePersonae.QuaeritDolore,
                _phantasmaDtAnimae.PhantasmaDtAnimaeQuaeritDolore
            );
            _turrisPhantasmaPuellaePersonae.AddeAnimamSensus(
                IDSensusPuellaePersonae.Papillae,
                _phantasmaDtAnimae.PhantasmaDtAnimaePapillae
            );
            _turrisPhantasmaPuellaePersonae.AddeAnimamSensus(
                IDSensusPuellaePersonae.Landicae,
                _phantasmaDtAnimae.PhantasmaDtAnimaeLandicae
            );
            _turrisPhantasmaPuellaePersonae.AddeAnimamSensus(
                IDSensusPuellaePersonae.Vaginae,
                _phantasmaDtAnimae.PhantasmaDtAnimaeVaginae
            );
            _turrisPhantasmaPuellaePersonae.AddeAnimamSensus(
                IDSensusPuellaePersonae.Ani,
                _phantasmaDtAnimae.PhantasmaDtAnimaeAni
            );
            _turrisPhantasmaPuellaePersonae.AddeAnimamSensus(
                IDSensusPuellaePersonae.Ausculum,
                _phantasmaDtAnimae.PhantasmaDtAnimaeAusculum
            );
            _turrisPhantasmaPuellaePersonae.AddeAnimamSensus(
                IDSensusPuellaePersonae.Corporis,
                _phantasmaDtAnimae.PhantasmaDtAnimaeCorporis
            );
            Purgare();
        }

        public void Purgare() {
            _estConfirmare = false;
            _phantasmaDtAnimae.Purgere();
        }
    }
}
