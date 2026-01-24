using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
using System.Numerics;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ResolutorCivisNudusVisae {
        private readonly ContextusCivisOstiorumLegibile _contextus;
        private readonly IResolutorCivisDistantia _resolutorCivisDistantia;

        private readonly IDPuellaeResNudusAnterior[] _cIDPuellaeResNudusAnterior;
        private readonly IDPuellaeResNudusPosterior[] _cIDPuellaeResNudusPosterior;

        private const float cos100 = -0.173648178f;

        public ResolutorCivisNudusVisae(
            ContextusCivisOstiorumLegibile contextus,
            IResolutorCivisDistantia resolutorCivisDistantia
        ) {
            _contextus = contextus;
            _resolutorCivisDistantia = resolutorCivisDistantia;

            _cIDPuellaeResNudusAnterior = new IDPuellaeResNudusAnterior[Enum.GetValues(typeof(IDPuellaeResNudusAnterior)).Length];
            _cIDPuellaeResNudusPosterior = new IDPuellaeResNudusPosterior[Enum.GetValues(typeof(IDPuellaeResNudusPosterior)).Length];
        }

        public void Initare(int idCivis) {
            // 何もしない。
        }

        public void Ordinare(
            int idCivis
        ) {
            // 視認範囲外の場合はSpectareNudusをfalseとする。
            if (!_resolutorCivisDistantia.EstCustodiaeVisae(idCivis)) {
                _contextus.Carrus.PostulareVeletudinisCondicionis(
                    idCivis,
                    estSpectareNudusAnterior: false,
                    estSpectareNudusPosterior: false
                );
                return;
            }

            bool estSpectareNudusAnterior = false;
            bool estSpectareNudusPosterior = false;

            Vector3 positioCivisCapitis = default;
            if (!_contextus.Visa.ConareLegoPositioCapitis(idCivis, out positioCivisCapitis)) {
                Memorator.MemorareErrorum(IDErrorum.RESOLUTORCIVISNUDUSVISAE_CONARELEGO_FAILED);
                return;
            } 

            foreach (IDPuellaeResNudusAnterior idNudusAnterior in _cIDPuellaeResNudusAnterior) {
                Vector3 directioResNudusAnterior = default;
                Vector3 positioResNudus = default;

                if (!_contextus.PuellaeResVisae.ConareLegoNudusAnterior(idNudusAnterior, out positioResNudus)) continue;
                if (!_contextus.PuellaeResVisae.ConareLegoNudusAnteriorDirectio(idNudusAnterior, out directioResNudusAnterior)) continue;

                Vector3 directio = positioCivisCapitis - positioResNudus;
                float angle = Vector3.Dot(Vector3.Normalize(directioResNudusAnterior), Vector3.Normalize(directio));
                if (angle > cos100) {
                    estSpectareNudusAnterior = true;
                }
            }

            foreach (IDPuellaeResNudusPosterior idNudusPosterior in _cIDPuellaeResNudusPosterior) {
                Vector3 directioResNudusPosterior = default;
                Vector3 positioResNudus = default;

                if (!_contextus.PuellaeResVisae.ConareLegoNudusPosterior(idNudusPosterior, out positioResNudus)) continue;
                if (!_contextus.PuellaeResVisae.ConareLegoNudusPosteriorDirectio(idNudusPosterior, out directioResNudusPosterior)) continue;

                Vector3 directio = positioCivisCapitis - positioResNudus;
                float angle = Vector3.Dot(Vector3.Normalize(directioResNudusPosterior), Vector3.Normalize(directio));
                if (angle > cos100) {
                    estSpectareNudusPosterior = true;
                }
            }

            _contextus.Carrus.PostulareVeletudinisCondicionis(
                idCivis,
                estSpectareNudusAnterior: estSpectareNudusAnterior,
                estSpectareNudusPosterior: estSpectareNudusPosterior
            );
        }
    }
}
