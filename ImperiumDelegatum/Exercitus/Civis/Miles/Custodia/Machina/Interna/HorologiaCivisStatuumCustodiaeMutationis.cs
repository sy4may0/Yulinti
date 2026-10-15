using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class HorologiaCivisStatuumCustodiaeMutationis {
        private readonly HorologiumTemere[] _horologiaTemereConservationisVigilantiae;
        private readonly HorologiumTemere[] _horologiaTemereConservationisSpectantisInVisus;
        private readonly HorologiumTemere[] _horologiaTemereConservationisSpectantisIntentionisZero;
        private readonly HorologiumTemere[] _horologiaTemereConservationisSequentisInVisus;
        private readonly HorologiumTemere[] _horologiaTemereConservationisSequentisIntentionisZero;
        private readonly HorologiumTemere[] _horologiaTemereConservationisQuaerentis;
        private readonly HorologiumTemere[] _horologiaTemereConservationisRefrigerationis;

        public HorologiaCivisStatuumCustodiaeMutationis(
            int longitudoCivis,
            IConfiguratioCivisCustodiaeStatuum configuratio,
            Random random
        ) {
            _horologiaTemereConservationisVigilantiae = new HorologiumTemere[longitudoCivis];
            _horologiaTemereConservationisSpectantisInVisus = new HorologiumTemere[longitudoCivis];
            _horologiaTemereConservationisSpectantisIntentionisZero = new HorologiumTemere[longitudoCivis];
            _horologiaTemereConservationisSequentisInVisus = new HorologiumTemere[longitudoCivis];
            _horologiaTemereConservationisSequentisIntentionisZero = new HorologiumTemere[longitudoCivis];
            _horologiaTemereConservationisQuaerentis = new HorologiumTemere[longitudoCivis];
            _horologiaTemereConservationisRefrigerationis = new HorologiumTemere[longitudoCivis];
            for (int i = 0; i < longitudoCivis; i++) {
                _horologiaTemereConservationisVigilantiae[i] = new HorologiumTemere(
                    configuratio.TempusConservationisVigilantiaeMinima,
                    configuratio.TempusConservationisVigilantiaeMaxima,
                    random
                );
                _horologiaTemereConservationisSpectantisInVisus[i] = new HorologiumTemere(
                    configuratio.TempusConservationisSpectansInVisusMinima,
                    configuratio.TempusConservationisSpectansInVisusMaxima,
                    random
                );
                _horologiaTemereConservationisSpectantisIntentionisZero[i] = new HorologiumTemere(
                    configuratio.TempusConservationisSpectansIntentioZeroMinima,
                    configuratio.TempusConservationisSpectansIntentioZeroMaxima,
                    random
                );
                _horologiaTemereConservationisSequentisInVisus[i] = new HorologiumTemere(
                    configuratio.TempusConservationisSequensInVisusMinima,
                    configuratio.TempusConservationisSequensInVisusMaxima,
                    random
                );
                _horologiaTemereConservationisSequentisIntentionisZero[i] = new HorologiumTemere(
                    configuratio.TempusConservationisSequensIntentioZeroMinima,
                    configuratio.TempusConservationisSequensIntentioZeroMaxima,
                    random
                );
                _horologiaTemereConservationisQuaerentis[i] = new HorologiumTemere(
                    configuratio.TempusConservationisQuaerensMinima,
                    configuratio.TempusConservationisQuaerensMaxima,
                    random
                );
                _horologiaTemereConservationisRefrigerationis[i] = new HorologiumTemere(
                    configuratio.TempusConservationisRefrigeratioMinima,
                    configuratio.TempusConservationisRefrigeratioMaxima,
                    random
                );
            }
        }

        // Vigilantia
        public bool EstActivumVigilantiae(int idCivis) {
            return _horologiaTemereConservationisVigilantiae[idCivis].EstActivum;
        }

        public void ActivareVigilantiam(int idCivis) {
            _horologiaTemereConservationisVigilantiae[idCivis].Activare();
        }

        public void DeactivareVigilantiam(int idCivis) {
            _horologiaTemereConservationisVigilantiae[idCivis].Deactivare();
        }

        public bool EstExhauritaVigilantiae(int idCivis, float intervallum) {
            return _horologiaTemereConservationisVigilantiae[idCivis].EstExhaurita(intervallum);
        }

        // Spectans InVisus
        public bool EstActivumSpectantisInVisus(int idCivis) {
            return _horologiaTemereConservationisSpectantisInVisus[idCivis].EstActivum;
        }

        public void ActivareSpectantemInVisus(int idCivis) {
            _horologiaTemereConservationisSpectantisInVisus[idCivis].Activare();
        }

        public void DeactivareSpectantemInVisus(int idCivis) {
            _horologiaTemereConservationisSpectantisInVisus[idCivis].Deactivare();
        }

        public bool EstExhauritaSpectantisInVisus(int idCivis, float intervallum) {
            return _horologiaTemereConservationisSpectantisInVisus[idCivis].EstExhaurita(intervallum);
        }

        // Spectans IntentioZero
        public bool EstActivumSpectantisIntentionisZero(int idCivis) {
            return _horologiaTemereConservationisSpectantisIntentionisZero[idCivis].EstActivum;
        }

        public void ActivareSpectantemIntentionisZero(int idCivis) {
            _horologiaTemereConservationisSpectantisIntentionisZero[idCivis].Activare();
        }

        public void DeactivareSpectantemIntentionisZero(int idCivis) {
            _horologiaTemereConservationisSpectantisIntentionisZero[idCivis].Deactivare();
        }

        public bool EstExhauritaSpectantisIntentionisZero(int idCivis, float intervallum) {
            return _horologiaTemereConservationisSpectantisIntentionisZero[idCivis].EstExhaurita(intervallum);
        }

        // Sequens InVisus
        public bool EstActivumSequentisInVisus(int idCivis) {
            return _horologiaTemereConservationisSequentisInVisus[idCivis].EstActivum;
        }

        public void ActivareSequentemInVisus(int idCivis) {
            _horologiaTemereConservationisSequentisInVisus[idCivis].Activare();
        }

        public void DeactivareSequentemInVisus(int idCivis) {
            _horologiaTemereConservationisSequentisInVisus[idCivis].Deactivare();
        }

        public bool EstExhauritaSequentisInVisus(int idCivis, float intervallum) {
            return _horologiaTemereConservationisSequentisInVisus[idCivis].EstExhaurita(intervallum);
        }

        // Sequens IntentioZero
        public bool EstActivumSequentisIntentionisZero(int idCivis) {
            return _horologiaTemereConservationisSequentisIntentionisZero[idCivis].EstActivum;
        }

        public void ActivareSequentemIntentionisZero(int idCivis) {
            _horologiaTemereConservationisSequentisIntentionisZero[idCivis].Activare();
        }

        public void DeactivareSequentemIntentionisZero(int idCivis) {
            _horologiaTemereConservationisSequentisIntentionisZero[idCivis].Deactivare();
        }

        public bool EstExhauritaSequentisIntentionisZero(int idCivis, float intervallum) {
            return _horologiaTemereConservationisSequentisIntentionisZero[idCivis].EstExhaurita(intervallum);
        }

        // Quaerens
        public bool EstActivumQuaerentis(int idCivis) {
            return _horologiaTemereConservationisQuaerentis[idCivis].EstActivum;
        }

        public void ActivareQuaerentem(int idCivis) {
            _horologiaTemereConservationisQuaerentis[idCivis].Activare();
        }

        public void DeactivareQuaerentem(int idCivis) {
            _horologiaTemereConservationisQuaerentis[idCivis].Deactivare();
        }

        public bool EstExhauritaQuaerentis(int idCivis, float intervallum) {
            return _horologiaTemereConservationisQuaerentis[idCivis].EstExhaurita(intervallum);
        }

        // Refrigeratio
        public bool EstActivumRefrigerationis(int idCivis) {
            return _horologiaTemereConservationisRefrigerationis[idCivis].EstActivum;
        }

        public void ActivareRefrigerationem(int idCivis) {
            _horologiaTemereConservationisRefrigerationis[idCivis].Activare();
        }

        public void DeactivareRefrigerationem(int idCivis) {
            _horologiaTemereConservationisRefrigerationis[idCivis].Deactivare();
        }

        public bool EstExhauritaRefrigerationis(int idCivis, float intervallum) {
            return _horologiaTemereConservationisRefrigerationis[idCivis].EstExhaurita(intervallum);
        }

        public void PurgereOmnia(int idCivis) {
            Purgere(_horologiaTemereConservationisVigilantiae[idCivis]);
            Purgere(_horologiaTemereConservationisSpectantisInVisus[idCivis]);
            Purgere(_horologiaTemereConservationisSpectantisIntentionisZero[idCivis]);
            Purgere(_horologiaTemereConservationisSequentisInVisus[idCivis]);
            Purgere(_horologiaTemereConservationisSequentisIntentionisZero[idCivis]);
            Purgere(_horologiaTemereConservationisQuaerentis[idCivis]);
            Purgere(_horologiaTemereConservationisRefrigerationis[idCivis]);
        }

        private static void Purgere(HorologiumTemere horologium) {
            horologium.Deactivare();
            horologium.Purgere();
        }
    }
}
