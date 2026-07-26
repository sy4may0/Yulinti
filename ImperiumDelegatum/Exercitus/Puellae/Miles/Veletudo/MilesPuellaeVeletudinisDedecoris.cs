using System;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class MilesPuellaeVeletudinisDedecoris {
        private readonly IConfiguratioPuellaeVeletudinis _configuratio;
        private readonly IResFluidaPuellaeVeletudinisLegibile _resFluidaPuellaeVeletudinis;
        private readonly IResFluidaCivisVeletudinisLegibile _resFluidaCivisVeletudinis;
        private readonly IResFluidaCivisCustodiaeLegibile _resFluidaCivisCustodiae;
        private readonly IOstiumCarrusPuellae _carrus;

        private readonly AbacusDistantiae _abacusDistantiaeDedecoris;


        public MilesPuellaeVeletudinisDedecoris(
            IConfiguratioPuellaeVeletudinis configuratio,
            IResFluidaPuellaeVeletudinisLegibile resFluidaPuellaeVeletudinis,
            IResFluidaCivisVeletudinisLegibile resFluidaCivisVeletudinis,
            IResFluidaCivisCustodiaeLegibile resFluidaCivisCustodiae,
            IOstiumCarrusPuellae carrus
        ) {
            _configuratio = configuratio;
            _resFluidaPuellaeVeletudinis = resFluidaPuellaeVeletudinis;
            _resFluidaCivisVeletudinis = resFluidaCivisVeletudinis;
            _resFluidaCivisCustodiae = resFluidaCivisCustodiae;
            _carrus = carrus;

            _abacusDistantiaeDedecoris = new AbacusDistantiae(
                distantiaMaxima: _configuratio.DistantiaDedecorisMaxima,
                distantiaMinima: _configuratio.DistantiaDedecorisMinima,
                distantiaMedia: _configuratio.DistantiaDedecorisMedia,
                praeruptioDistantiae: _configuratio.PraeruptioDistantiaDedecoris
            );
        }

        public void Initare() {
        }

        private float ComputareRatioDistantiae(int idCivis) {
            float distantia = _resFluidaCivisCustodiae.DistantiaPuellae(idCivis);
            return _abacusDistantiaeDedecoris.ComputareRatioInversus(distantia);
        }

        private float ComputareAnomalia(int idCivis) {
            float anomalia = 0f;
            if (_resFluidaCivisVeletudinis.EstSpectareNudus(idCivis)) {
                anomalia = _resFluidaPuellaeVeletudinis.AnomaliaNudus;
            } else {
                anomalia = _resFluidaPuellaeVeletudinis.Anomalia;
            }

            return anomalia;
        }

        private float ComputareRatioAnomaliae(int idCivis, float anomalia) {
            float div = anomalia - _resFluidaCivisVeletudinis.TorelantiaAnomaliaeMaxima(idCivis);

            float ratioDiv = div / _configuratio.LimenAnomaliaeExcessusMaxima;
            return Mathematica.Lerp01(
                _configuratio.RatioDedecorisAnomaliaeExcessusMinima,
                _configuratio.RatioDedecorisAnomaliaeExcessusMaxima,
                ratioDiv
            );
        }

        private float ComputareRatioAttendens(int idCivis) {
            if (_resFluidaCivisVeletudinis.EstVigilantia(idCivis)) {
                return _configuratio.RatioDedecorisVigilantia;
            }

            if (_resFluidaCivisVeletudinis.StatusCustodiaeCurrens(idCivis) == IDCivisStatusCustodiae.Discedens) {
                return _configuratio.RatioDedecorisDiscedens;
            }

            return _configuratio.RatioDedecorisAttendens;
        }

        private float ComputareLimes(float dedecus) {
            float anomalia = 0f;
            if (_resFluidaPuellaeVeletudinis.EstNudusAnterior || _resFluidaPuellaeVeletudinis.EstNudusPosterior) {
                anomalia = _resFluidaPuellaeVeletudinis.AnomaliaNudus;
            } else {
                anomalia = _resFluidaPuellaeVeletudinis.Anomalia;
            }

            if (anomalia <= Numerus.Epsilon) anomalia = Numerus.Epsilon;

            // y = n√xで、xがanomaliaの時、y=anomaliaとなるnを求める
            float n = MathF.Sqrt(anomalia);

            return n * MathF.Sqrt(dedecus);
        }

        public void Ordinare() {
            float dedecus = 0f;

            for(int idCivis = 0; idCivis < _resFluidaCivisVeletudinis.Longitudo; idCivis++) {
                float anomalia = ComputareAnomalia(idCivis);
                float ratioDistantiae = ComputareRatioDistantiae(idCivis);
                float ratioAnomaliae = ComputareRatioAnomaliae(idCivis, anomalia);
                float ratioAttendens = ComputareRatioAttendens(idCivis);

                dedecus += anomalia * ratioDistantiae * ratioAnomaliae * ratioAttendens;
            }

            dedecus = ComputareLimes(dedecus);

            _carrus.PostulareVeletudinis(
                dtDedecus: dedecus
            );
        }
    }
}