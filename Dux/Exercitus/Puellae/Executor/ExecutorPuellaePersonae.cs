using Yulinti.Dux.ContractusDucis;
namespace Yulinti.Dux.Exercitus {
    internal sealed class ResolutorPuellaeAnimae : IResolutorPuellaeAnimae {
        // 各Gradusに対応する必要経験値のテーブル
        private readonly int[] _tabulaGradusAnimae;

        public ResolutorPuellaeAnimae(IConfiguratioPuellaePersonae config) {
            _tabulaGradusAnimae = new int[config.GradusMaximus + 1];
            for (int i = 0; i <= config.GradusMaximus; i++) {
                _tabulaGradusAnimae[i] = 
                    ConstansPuellae.FunctioAnimae(i, config.OffsetAnimae)
                    * config.CofficiensAnimae;
            }
        }

        // animaからGradusを解決する
        // tabula[i] <= anima < tabula[i+1]
        private int ResolvereGradus(int anima) {
            for (int i = _tabulaGradusAnimae.Length - 1; i >= 0; i--) {
                if (anima >= _tabulaGradusAnimae[i]) {
                    return i;
                }
            }
            return 0;
        }

        public int ResolvereGradusLuxuriosus(int animaLuxuriosus) {
            return ResolvereGradus(animaLuxuriosus);
        }
        public int ResolvereGradusExhibitus(int animaExhibitus) {
            return ResolvereGradus(animaExhibitus);
        }
        public int ResolvereGradusPerversus(int animaPerversus) {
            return ResolvereGradus(animaPerversus);
        }
        public int ResolvereGradusQuaeritDolore(int animaQuaeritDolore) {
            return ResolvereGradus(animaQuaeritDolore);
        }
        public int ResolvereSensusPapillae(int animaPapillae) {
            return ResolvereGradus(animaPapillae);
        }
        public int ResolvereSensusLandicae(int animaLandicae) {
            return ResolvereGradus(animaLandicae);
        }
        public int ResolvereSensusVaginae(int animaVaginae) {
            return ResolvereGradus(animaVaginae);
        }
        public int ResolvereSensusAni(int animaAni) {
            return ResolvereGradus(animaAni);
        }
        public int ResolvereSensusAusculum(int animaAusculum) {
            return ResolvereGradus(animaAusculum);
        }
        public int ResolvereSensusCorporis(int animaCorporis) {
            return ResolvereGradus(animaCorporis);
        }
    }

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

        public void Pono(
            int dtAnimaeLuxuriosus,
            int dtAnimaeExhibitus,
            int dtAnimaePerversus,
            int dtAnimaeQuaeritDolore,
            int dtAnimaePapillae,
            int dtAnimaeLandicae,
            int dtAnimaeVaginae,
            int dtAnimaeAni,
            int dtAnimaeAusculum,
            int dtAnimaeCorporis
        ) {
            _phantasmaDtAnimaeLuxuriosus = dtAnimaeLuxuriosus;
            _phantasmaDtAnimaeExhibitus = dtAnimaeExhibitus;
            _phantasmaDtAnimaePerversus = dtAnimaePerversus;
            _phantasmaDtAnimaeQuaeritDolore = dtAnimaeQuaeritDolore;
            _phantasmaDtAnimaePapillae = dtAnimaePapillae;
            _phantasmaDtAnimaeLandicae = dtAnimaeLandicae;
            _phantasmaDtAnimaeVaginae = dtAnimaeVaginae;
            _phantasmaDtAnimaeAni = dtAnimaeAni;
            _phantasmaDtAnimaeAusculum = dtAnimaeAusculum;
            _phantasmaDtAnimaeCorporis = dtAnimaeCorporis;
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
        private readonly ResFluidaPuellaePersonae _resFluidaPuellaePersonae;
        private readonly IResolutorPuellaeAnimae _resolutorPuellaeAnimae;
        private readonly PhantasmaDtAnimae _phantasmaDtAnimae;

        private bool _estConfirmare;

        public ExecutorPuellaePersonae(
            IConfiguratioExercitusPuellae configuratioExercitusPuellae,
            ResFluidaPuellaePersonae resFluidaPuellaePersonae
        ) {
            _resFluidaPuellaePersonae = resFluidaPuellaePersonae;
            _resolutorPuellaeAnimae = new ResolutorPuellaeAnimae(configuratioExercitusPuellae.Personae);
            _phantasmaDtAnimae = new PhantasmaDtAnimae();
        }

        public void Initare() {
            _resFluidaPuellaePersonae.Purgare();
            //[TODO] セーブデータからresFluidaをロードする。
            _phantasmaDtAnimae.Pono(
                dtAnimaeLuxuriosus: _resFluidaPuellaePersonae.AnimaLuxuriosus,
                dtAnimaeExhibitus: _resFluidaPuellaePersonae.AnimaExhibitus,
                dtAnimaePerversus: _resFluidaPuellaePersonae.AnimaPerversus,
                dtAnimaeQuaeritDolore: _resFluidaPuellaePersonae.AnimaQuaeritDolore,
                dtAnimaePapillae: _resFluidaPuellaePersonae.AnimaPapillae,
                dtAnimaeLandicae: _resFluidaPuellaePersonae.AnimaLandicae,
                dtAnimaeVaginae: _resFluidaPuellaePersonae.AnimaVaginae,
                dtAnimaeAni: _resFluidaPuellaePersonae.AnimaAni,
                dtAnimaeAusculum: _resFluidaPuellaePersonae.AnimaAusculum,
                dtAnimaeCorporis: _resFluidaPuellaePersonae.AnimaCorporis
            );
            _estConfirmare = false;
        }

        public void Primum() {
            _phantasmaDtAnimae.Pono(
                dtAnimaeLuxuriosus: _resFluidaPuellaePersonae.AnimaLuxuriosus,
                dtAnimaeExhibitus: _resFluidaPuellaePersonae.AnimaExhibitus,
                dtAnimaePerversus: _resFluidaPuellaePersonae.AnimaPerversus,
                dtAnimaeQuaeritDolore: _resFluidaPuellaePersonae.AnimaQuaeritDolore,
                dtAnimaePapillae: _resFluidaPuellaePersonae.AnimaPapillae,
                dtAnimaeLandicae: _resFluidaPuellaePersonae.AnimaLandicae,
                dtAnimaeVaginae: _resFluidaPuellaePersonae.AnimaVaginae,
                dtAnimaeAni: _resFluidaPuellaePersonae.AnimaAni,
                dtAnimaeAusculum: _resFluidaPuellaePersonae.AnimaAusculum,
                dtAnimaeCorporis: _resFluidaPuellaePersonae.AnimaCorporis
            );
            _estConfirmare = false;
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
            _resFluidaPuellaePersonae.RenovareAnimaGradus(
                animaLuxuriosus: _phantasmaDtAnimae.PhantasmaDtAnimaeLuxuriosus,
                animaExhibitus: _phantasmaDtAnimae.PhantasmaDtAnimaeExhibitus,
                animaPerversus: _phantasmaDtAnimae.PhantasmaDtAnimaePerversus,
                animaQuaeritDolore: _phantasmaDtAnimae.PhantasmaDtAnimaeQuaeritDolore
            );
            _resFluidaPuellaePersonae.RenovareAnimaSensus(
                animaPapillae: _phantasmaDtAnimae.PhantasmaDtAnimaePapillae,
                animaLandicae: _phantasmaDtAnimae.PhantasmaDtAnimaeLandicae,
                animaVaginae: _phantasmaDtAnimae.PhantasmaDtAnimaeVaginae,
                animaAni: _phantasmaDtAnimae.PhantasmaDtAnimaeAni,
                animaAusculum: _phantasmaDtAnimae.PhantasmaDtAnimaeAusculum,
                animaCorporis: _phantasmaDtAnimae.PhantasmaDtAnimaeCorporis
            );
            // セーブデータに保存する。
        }

        public void Purgare() {
            _estConfirmare = false;
            _phantasmaDtAnimae.Purgere();
        }
    }
}