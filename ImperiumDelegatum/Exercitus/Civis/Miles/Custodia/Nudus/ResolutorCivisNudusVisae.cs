using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using System.Numerics;
using System;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class ResolutorCivisNudusVisae {
        private readonly IOstiumCarrusCivis _carrus;
        private readonly IOstiumCivisVisaeLegibile _visa;
        private readonly IOstiumPuellaeResVisaeLegibile _puellaeResVisae;
        private readonly IResFluidaCivisCustodiaeLegibile _resFCustodiae;

        private readonly IDPuellaeResNudusAnterior[] _cIDPuellaeResNudusAnterior;
        private readonly IDPuellaeResNudusPosterior[] _cIDPuellaeResNudusPosterior;

        private const float cos100 = -0.173648178f;

        public ResolutorCivisNudusVisae(
            IOstiumCarrusCivis carrus,
            IOstiumCivisVisaeLegibile visa,
            IOstiumPuellaeResVisaeLegibile puellaeResVisae,
            IResFluidaCivisCustodiaeLegibile resFCustodiae
        ) {
            _carrus = carrus;
            _visa = visa;
            _puellaeResVisae = puellaeResVisae;
            _resFCustodiae = resFCustodiae;

            _cIDPuellaeResNudusAnterior = (IDPuellaeResNudusAnterior[])Enum.GetValues(typeof(IDPuellaeResNudusAnterior));
            _cIDPuellaeResNudusPosterior = (IDPuellaeResNudusPosterior[])Enum.GetValues(typeof(IDPuellaeResNudusPosterior));
        }

        public void Initare(int idCivis) {
            // 何もしない。
        }

        public void Ordinare(
            int idCivis
        ) {
            // 視認範囲外の場合はSpectareNudusをfalseとする。
            if (!_resFCustodiae.EstCustodiaeVisae(idCivis)) {
                _carrus.PostulareVeletudinisCondicionis(
                    idCivis,
                    estSpectareNudusAnterior: false,
                    estSpectareNudusPosterior: false
                );
                return;
            }

            bool estSpectareNudusAnterior = false;
            bool estSpectareNudusPosterior = false;

            Vector3 positioCivisCapitis = default;
            if (!_visa.ConareLegoPositioCapitis(idCivis, out positioCivisCapitis)) {
                Notarius.Memorare(LogTextus.ResolutorCivisNudusVisae_RESOLUTORCIVISNUDUSVISAE_CONARELEGO_FAILED);
                return;
            } 

            foreach (IDPuellaeResNudusAnterior idNudusAnterior in _cIDPuellaeResNudusAnterior) {
                Vector3 directioResNudusAnterior = default;
                Vector3 positioResNudus = default;

                if (!_puellaeResVisae.ConareLegoNudusAnterior(idNudusAnterior, out positioResNudus)) continue;
                if (!_puellaeResVisae.ConareLegoNudusAnteriorDirectio(idNudusAnterior, out directioResNudusAnterior)) continue;

                Vector3 directio = positioCivisCapitis - positioResNudus;
                float angle = Vector3.Dot(Vector3.Normalize(directioResNudusAnterior), Vector3.Normalize(directio));
                if (angle > cos100) {
                    estSpectareNudusAnterior = true;
                }
            }

            foreach (IDPuellaeResNudusPosterior idNudusPosterior in _cIDPuellaeResNudusPosterior) {
                Vector3 directioResNudusPosterior = default;
                Vector3 positioResNudus = default;

                if (!_puellaeResVisae.ConareLegoNudusPosterior(idNudusPosterior, out positioResNudus)) continue;
                if (!_puellaeResVisae.ConareLegoNudusPosteriorDirectio(idNudusPosterior, out directioResNudusPosterior)) continue;

                Vector3 directio = positioCivisCapitis - positioResNudus;
                float angle = Vector3.Dot(Vector3.Normalize(directioResNudusPosterior), Vector3.Normalize(directio));
                if (angle > cos100) {
                    estSpectareNudusPosterior = true;
                }
            }

            _carrus.PostulareVeletudinisCondicionis(
                idCivis,
                estSpectareNudusAnterior: estSpectareNudusAnterior,
                estSpectareNudusPosterior: estSpectareNudusPosterior
            );
        }
    }
}
