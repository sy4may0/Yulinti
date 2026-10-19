using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // Ordinatioを受け取り、Executorに渡す。
    internal sealed class CarrusPuellaePersonae : IOstiumCarrusPuellaePersonae {
        private readonly ExecutorPuellaePersonae _exPersonae;

        private readonly LacusOrdinatioPuellaePersonae _lacusOrdinatio;

        public CarrusPuellaePersonae(
            ExecutorPuellaePersonae exPersonae
        ) {
            _exPersonae = exPersonae;
            _lacusOrdinatio = new LacusOrdinatioPuellaePersonae();
        }

        // AurigaがConfirmare後に実行する。使用済みOrdinatioをLacusへ回収する。
        public void Colligere() {
            _lacusOrdinatio.ColligereOmnia();
        }

        public void PostularePersonae(
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
            if(_lacusOrdinatio.EmittarePersonae(out var ordinatio)) {
                ordinatio.Pono(
                    dtAnimaeLuxuriosus,
                    dtAnimaeExhibitus,
                    dtAnimaePerversus,
                    dtAnimaeQuaeritDolore,
                    dtAnimaePapillae,
                    dtAnimaeLandicae,
                    dtAnimaeVaginae,
                    dtAnimaeAni,
                    dtAnimaeAusculum,
                    dtAnimaeCorporis
                );
                _exPersonae.Executare(ordinatio);
            }
        }
    }
}
