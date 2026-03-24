using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
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
        private readonly ITurrisSalsamentiLegibile _turrisSalsamenti;
        private readonly IConfiguratioPuellaeVeletudinis _configuratio;
        private readonly IOstiumCarrusPuellae _carrus;
        private readonly IOstiumTemporisLegibile _temporis;
        private readonly IResFluidaCivisLegibile _resFCivis;
        private readonly AbacusTemporis _abacusStudiumAmittere;

        public MilesPuellaeVigoris(
            ITurrisSalsamentiLegibile turrisSalsamenti,
            IConfiguratioPuellaeVeletudinis configuratio,
            IOstiumCarrusPuellae carrus,
            IOstiumTemporisLegibile temporis,
            IResFluidaCivisLegibile resFCivis
        ) {
            _turrisSalsamenti = turrisSalsamenti;
            _configuratio = configuratio;
            _carrus = carrus;
            _temporis = temporis;
            _resFCivis = resFCivis;

            _abacusStudiumAmittere = new AbacusTemporis(
                _configuratio.TempusRecuperationisVigorisMaximaSec,
                0f,
                _configuratio.TempusRecuperationisVigorisSec,
                _configuratio.PraeruptioTempusRecuperationisVigoris
            );
        }

        private NumerusCustodiae ComputareCivisCustodiae() {
            int numerusDetectio = 0;
            int numerusVigilantia = 0;
            int numerusSuspecta = 0;

            for (int idCivis = 0; idCivis < _resFCivis.Veletudinis.Longitudo; idCivis++) {
                if (_resFCivis.Veletudinis.EstDetectio(idCivis)) {
                    numerusDetectio++;
                }
                if (_resFCivis.Veletudinis.EstVigilantia(idCivis)) {
                    numerusVigilantia++;
                }
                if (_resFCivis.Veletudinis.EstSuspecta(idCivis)) {
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
            float maxima = _configuratio.RatioNumerusCustodiaeMaxima;
            return maxima - ((maxima - 1) / numerusCustodiae);
        }

        private float ComputareConsumptioVigoris(
            float ratioNumerusCustodiae,
            float dedecus,
            float consumptioVigorisMinima,
            float consumptioVigorisMaxima
        ) {
            float consumptio = Mathematica.Lerp01(
                consumptioVigorisMinima,
                consumptioVigorisMaxima,
                dedecus
            );
            return consumptio * ratioNumerusCustodiae;
        }

        public void Initare() {
            // 初期Vigorを100%に設定
            _carrus.PostulareVeletudinis(
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
                    _configuratio.ConsumptioVigorisMinimaDetectio,
                    _configuratio.ConsumptioVigorisMaximaDetectio
                );

                // 低レベル時はDetectioで高速死亡する。
                // セーブデータが無い場合(異常)もデフォルト高速死亡
                if (!_turrisSalsamenti.ConareActualis(out IOstiumSalsamenti actualis)) {
                    Carnifex.Error(LogTextus.MilesPuellaeVigoris_MILSEPUELLAEVIGORIS_SALSAMENTUM_ACTUALIS_NULL);
                    c *= _configuratio.RatioConsumptioVigorisDetectio;
                } else {
                    if (actualis.PuellaePersonae.GradusExhibitus < _configuratio.LimenRemissioExhibitus) {
                        c *= _configuratio.RatioConsumptioVigorisDetectio;
                    }
                }

                _carrus.PostulareVeletudinis(
                    dtVigoris: c * _temporis.Intervallum
                );
                return;
            }

            if (numerusCustodiae.NumerusVigilantia > 0) {
                _abacusStudiumAmittere.Purgere();
                float r = RatioNumerusCustodiae(numerusCustodiae.NumerusVigilantia);
                float c = ComputareConsumptioVigoris(
                    r,
                    resFluida.Veletudinis.Dedecus,
                    _configuratio.ConsumptioVigorisMinimaVigilantia,
                    _configuratio.ConsumptioVigorisMaximaVigilantia
                );
                _carrus.PostulareVeletudinis(
                    dtVigoris: c * _temporis.Intervallum
                );
                return;
            }

            _abacusStudiumAmittere.Pulsus(_temporis.Intervallum);
            float ratio = _abacusStudiumAmittere.ComputareRatio();
            float recuperatio = _configuratio.RecuperatioVigorisSec * ratio;

            _carrus.PostulareVeletudinis(
                dtVigoris: recuperatio * _temporis.Intervallum
            );
        }
    }
}