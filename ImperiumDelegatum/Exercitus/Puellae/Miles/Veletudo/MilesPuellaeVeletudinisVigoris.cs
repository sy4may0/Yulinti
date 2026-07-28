using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class MilesPuellaeVeletudinisVigoris {
        private readonly IConfiguratioPuellaeVeletudinis _configuratio;
        private readonly IResFluidaPuellaeVeletudinisLegibile _resFluidaPuellaeVeletudinis;
        private readonly IOstiumCarrusPuellae _carrus;
        private readonly IOstiumTemporisLegibile _temporis;

        private readonly AbacusTemporis _abacusTemporisRepletioVigoris;

        public MilesPuellaeVeletudinisVigoris(
            IConfiguratioPuellaeVeletudinis configuratio,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            IOstiumCarrusPuellae carrus,
            IOstiumTemporisLegibile temporis
        ) {
            _configuratio = configuratio;
            _resFluidaPuellaeVeletudinis = resFluidaPuellaeVeletudinis;
            _carrus = carrus;
            _temporis = temporis;

            _abacusTemporisRepletioVigoris = new AbacusTemporis(
                tempusStudiumAmittereMaxima: _configuratio.TempusRepletioVigorisMaximaSec,
                tempusStudiumAmittereMinima: _configuratio.TempusRepletioVigorisMinimaSec,
                tempusStudiumAmittereMedia: _configuratio.TempusRepletioVigorisMediaSec,
                praeruptioTempusAmittere: _configuratio.PraeruptioRepletioVigoris
            );
        }

        public void Initare() {
        }

        private float ComputareConsumptioVigoris(float dedecus) {
            float ratioDedecus = dedecus / _configuratio.DedecusMaximaConsumptioVigoris;
            return Mathematica.Lerp01(
                _configuratio.ConsumptioVigorisMinimaSec,
                _configuratio.ConsumptioVigorisMaximaSec,
                ratioDedecus
            );
        }

        public void Ordinare() {
            float dedecus = _resFluidaPuellaeVeletudinis.Dedecus;
            bool estConsumptio = false;
            if (dedecus <= Numerus.Epsilon) {
                estConsumptio = true;
            }

            if (estConsumptio) {
                float ratio = _abacusTemporisRepletioVigoris.ComputareRatio();
                float dtVigoris = ratio * _configuratio.RatioRepletioVigoris * _resFluidaPuellaeVeletudinis.VigorMaxima;
                _carrus.PostulareVeletudinis(
                    dtVigoris: dtVigoris * _temporis.Intervallum
                );
                _abacusTemporisRepletioVigoris.Pulsus(
                    _temporis.Intervallum
                );
                return;
            }

            _abacusTemporisRepletioVigoris.Purgere();
            float consumptioVigoris = ComputareConsumptioVigoris(dedecus);
            _carrus.PostulareVeletudinis(
                dtVigoris: -consumptioVigoris * _temporis.Intervallum
            );
        }
    }
}