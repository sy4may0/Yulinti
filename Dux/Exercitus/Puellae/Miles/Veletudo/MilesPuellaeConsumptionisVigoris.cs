using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal struct NumerusCustodiae {
        public readonly int NumerusDetectio;
        public readonly int NumerusVigilantia;
        public readonly int NumerusSuspecta;

        public NumerusCustodiae(
            int numerusDetectio,
            int numerusVigilantia,
            int numerusSuspecta
        ) {
            NumerusDetectio = numerusDetectio;
            NumerusVigilantia = numerusVigilantia;
            NumerusSuspecta = numerusSuspecta;
        }
    }

    internal sealed class MilesPuellaeVigoris {
        private readonly ContextusPuellaeOstiorumLegibile _contextus;
        private readonly AbacusStudiumAmittere _abacusStudiumAmittere;

        public MilesPuellaeVigoris(
            ContextusPuellaeOstiorumLegibile contextus
        ) {
            _contextus = contextus;
            _abacusStudiumAmittere = new AbacusStudiumAmittere(
                _contextus.Configuratio.Veletudo.TempusRecuperationisVigorisSec,
                _contextus.Configuratio.Veletudo.TempusRecuperationisVigorisMaximaSec,
                _contextus.Configuratio.Veletudo.PraeruptioTempusRecuperationisVigoris
            );
        }

        private NumerusCustodiae ComputareCivisCustodiae() {
            int numerusDetectio = 0;
            int numerusVigilantia = 0;
            int numerusSuspecta = 0;

            for (int idCivis = 0; idCivis < _contextus.ResFCivis.Veletudinis.Longitudo; idCivis++) {
                if (_contextus.ResFCivis.Veletudinis.EstDetectio(idCivis)) {
                    numerusDetectio++;
                }
                if (_contextus.ResFCivis.Veletudinis.EstVigilantia(idCivis)) {
                    numerusVigilantia++;
                }
                if (_contextus.ResFCivis.Veletudinis.EstSuspecta(idCivis)) {
                    numerusSuspecta++;
                }
            }
            return new NumerusCustodiae(
                numerusDetectio,
                numerusVigilantia,
                numerusSuspecta
            );
        }

        private float RatioNumerusCustodiae(
            int numerusCustodiae
        ) {
            // y = max - ((max - 1) / x)
            float maxima = _contextus.Configuratio.Veletudo.RatioNumerusCustodiaeMaxima;
            return maxima - ((maxima - 1) / numerusCustodiae);
        }

        private float ComputareConsumptioVigoris(
            float ratioNumerusCustodiae,
            float dedecus,
            float consumptioVigorisMinima,
            float consumptioVigorisMaxima
        ) {
            float consumptio = DuxMath.NLerp(
                consumptioVigorisMinima,
                consumptioVigorisMaxima,
                dedecus
            );
            return consumptio * ratioNumerusCustodiae;
        }

        public void Initare() {
            // 初期Vigorを100%に設定
            _contextus.Carrus.PostulareVeletudinis(
                dtVigoris: 1f
            );
        }


        public void Ordinare(IResFluidaPuellaeLegibile resFluida) {
            NumerusCustodiae numerusCustodiae = ComputareCivisCustodiae();

            if (numerusCustodiae.NumerusDetectio > 0) {
                _abacusStudiumAmittere.Purgere();
                float r = RatioNumerusCustodiae(numerusCustodiae.NumerusDetectio);
                float c = ComputareConsumptioVigoris(
                    r,
                    resFluida.Veletudinis.Dedecus,
                    _contextus.Configuratio.Veletudo.ConsumptioVigorisMinimaDetectio,
                    _contextus.Configuratio.Veletudo.ConsumptioVigorisMaximaDetectio
                );
                // 低レベル時はDetectioで高速死亡する。
                if (resFluida.Persona.GradusExhibitus < _contextus.Configuratio.Veletudo.LimenRemissioExhibitus) {
                    c *= _contextus.Configuratio.Veletudo.RatioConsumptioVigorisDetectio;
                }
                _contextus.Carrus.PostulareVeletudinis(
                    dtVigoris: c * _contextus.Temporis.Intervallum
                );
                return;
            }

            if (numerusCustodiae.NumerusVigilantia > 0) {
                _abacusStudiumAmittere.Purgere();
                float r = RatioNumerusCustodiae(numerusCustodiae.NumerusVigilantia);
                float c = ComputareConsumptioVigoris(
                    r,
                    resFluida.Veletudinis.Dedecus,
                    _contextus.Configuratio.Veletudo.ConsumptioVigorisMinimaVigilantia,
                    _contextus.Configuratio.Veletudo.ConsumptioVigorisMaximaVigilantia
                );
                _contextus.Carrus.PostulareVeletudinis(
                    dtVigoris: c * _contextus.Temporis.Intervallum
                );
                return;
            }

            _abacusStudiumAmittere.Pulsus(_contextus.Temporis.Intervallum);
            float ratio = _abacusStudiumAmittere.ComputareRatio();
            float recuperatio = _contextus.Configuratio.Veletudo.RecuperatioVigorisSec * ratio;

            _contextus.Carrus.PostulareVeletudinis(
                dtVigoris: recuperatio * _contextus.Temporis.Intervallum
            );
        }
    }
}