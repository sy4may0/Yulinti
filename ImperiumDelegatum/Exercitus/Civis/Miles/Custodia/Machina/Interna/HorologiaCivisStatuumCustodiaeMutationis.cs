using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class HorologiaCivisStatuumCustodiaeMutationis {
        private readonly HorologiumTemere[] _horologiaTemereVigilantiae;
        private readonly HorologiumTemere[] _horologiaTemereConservationisSpectansInVisus;
        private readonly HorologiumTemere[] _horologiaTemereConservationisSpectansIntentioZero;
        private readonly HorologiumTemere[] _horologiaTemereConservationisSequensInVisus;
        private readonly HorologiumTemere[] _horologiaTemereConservationisSequensIntentioZero;

        public HorologiaCivisStatuumCustodiaeMutationis(
            int longitudoCivis,
            IConfiguratioCivisCustodiaeStatuum configuratio,
            Random random
        ) {
            _horologiaTemereVigilantiae = new HorologiumTemere[longitudoCivis];
            _horologiaTemereConservationisSpectansInVisus = new HorologiumTemere[longitudoCivis];
            _horologiaTemereConservationisSpectansIntentioZero = new HorologiumTemere[longitudoCivis];
            _horologiaTemereConservationisSequensInVisus = new HorologiumTemere[longitudoCivis];
            _horologiaTemereConservationisSequensIntentioZero = new HorologiumTemere[longitudoCivis];
            for (int i = 0; i < longitudoCivis; i++) {
                _horologiaTemereVigilantiae[i] = new HorologiumTemere(
                    configuratio.TempusConservationisVigilantiaeMinima,
                    configuratio.TempusConservationisVigilantiaeMaxima,
                    random
                );
                _horologiaTemereConservationisSpectansInVisus[i] = new HorologiumTemere(
                    configuratio.TempusConservationisSpectansInVisusMinima,
                    configuratio.TempusConservationisSpectansInVisusMaxima,
                    random
                );
                _horologiaTemereConservationisSpectansIntentioZero[i] = new HorologiumTemere(
                    configuratio.TempusConservationisSpectansIntentioZeroMinima,
                    configuratio.TempusConservationisSpectansIntentioZeroMaxima,
                    random
                );
                _horologiaTemereConservationisSequensInVisus[i] = new HorologiumTemere(
                    configuratio.TempusConservationisSequensInVisusMinima,
                    configuratio.TempusConservationisSequensInVisusMaxima,
                    random
                );
                _horologiaTemereConservationisSequensIntentioZero[i] = new HorologiumTemere(
                    configuratio.TempusConservationisSequensIntentioZeroMinima,
                    configuratio.TempusConservationisSequensIntentioZeroMaxima,
                    random
                );
            }
        }

        public bool EstActivumVigilantiam(int idCivis) {
            return _horologiaTemereVigilantiae[idCivis].EstActivum;
        }

        public bool EstActivumSpectansIntentioZero(int idCivis) {
            return _horologiaTemereConservationisSpectansIntentioZero[idCivis].EstActivum;
        }

        public bool EstActivumSpectansInVisus(int idCivis) {
            return _horologiaTemereConservationisSpectansInVisus[idCivis].EstActivum;
        }

        public void ActivareVigilantiam(int idCivis) {
            _horologiaTemereVigilantiae[idCivis].Activare();
        }

        public void DeactivareVigilantiam(int idCivis) {
            _horologiaTemereVigilantiae[idCivis].Deactivare();
        }

        public bool EstExhauritaVigilantiam(int idCivis, float intervallum) {
            return _horologiaTemereVigilantiae[idCivis].EstExhaurita(intervallum);
        }

        public void ActivareSpectansInVisus(int idCivis) {
            _horologiaTemereConservationisSpectansInVisus[idCivis].Activare();
        }

        public void DeactivateSpectansInVisus(int idCivis) {
            _horologiaTemereConservationisSpectansInVisus[idCivis].Deactivare();
        }

        public bool EstExhauritaSpectansInVisus(int idCivis, float intervallum) {
            return _horologiaTemereConservationisSpectansInVisus[idCivis].EstExhaurita(intervallum);
        }

        public void ActivareSpectansIntentioZero(int idCivis) {
            _horologiaTemereConservationisSpectansIntentioZero[idCivis].Activare();
        }

        public void DeactivateSpectansIntentioZero(int idCivis) {
            _horologiaTemereConservationisSpectansIntentioZero[idCivis].Deactivare();
        }

        public bool EstExhauritaSpectansIntentioZero(int idCivis, float intervallum) {
            return _horologiaTemereConservationisSpectansIntentioZero[idCivis].EstExhaurita(intervallum);
        }

        public bool EstActivumSequensInVisus(int idCivis) {
            return _horologiaTemereConservationisSequensInVisus[idCivis].EstActivum;
        }

        public void ActivareSequensInVisus(int idCivis) {
            _horologiaTemereConservationisSequensInVisus[idCivis].Activare();
        }

        public void DeactivateSequensInVisus(int idCivis) {
            _horologiaTemereConservationisSequensInVisus[idCivis].Deactivare();
        }

        public bool EstExhauritaSequensInVisus(int idCivis, float intervallum) {
            return _horologiaTemereConservationisSequensInVisus[idCivis].EstExhaurita(intervallum);
        }

        public bool EstActivumSequensIntentioZero(int idCivis) {
            return _horologiaTemereConservationisSequensIntentioZero[idCivis].EstActivum;
        }

        public void ActivareSequensIntentioZero(int idCivis) {
            _horologiaTemereConservationisSequensIntentioZero[idCivis].Activare();
        }

        public void DeactivateSequensIntentioZero(int idCivis) {
            _horologiaTemereConservationisSequensIntentioZero[idCivis].Deactivare();
        }

        public bool EstExhauritaSequensIntentioZero(int idCivis, float intervallum) {
            return _horologiaTemereConservationisSequensIntentioZero[idCivis].EstExhaurita(intervallum);
        }
    }
}