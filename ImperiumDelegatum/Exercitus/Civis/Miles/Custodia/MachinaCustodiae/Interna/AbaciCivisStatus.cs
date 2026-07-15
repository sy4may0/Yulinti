using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class AbaciCivisStatus {
        private readonly int _longitudo;
        private readonly AbacusTemporis[] _abacusStudiumHabereAuditae;
        private readonly AbacusTemporis[] _abacusStudiumAmittereAuditae;
        private readonly AbacusTemporis[] _abacusStudiumHabereVisae;
        private readonly AbacusTemporis[] _abacusStudiumAmittereVisae;

        private readonly Horologium[] _horologiumAuditaeConservandi;
        private readonly Horologium[] _horologiumVisaeConservandi;

        // 後で設定に移行する。
        private readonly float _tempusAuditaeStudiumHabereMaxima = 2f;
        private readonly float _tempusAuditaeStudiumHabereMedia = 0.5f;
        private readonly float _tempusAuditaeStudiumHabereMinima = 0f;
        private readonly float _praeruptioAuditaeTempusStudiumHabere = 16f;
        private readonly float _tempusAuditaeStudiumAmittereMaxima = 10f;
        private readonly float _tempusAuditaeStudiumAmittereMedia = 5f;
        private readonly float _tempusAuditaeStudiumAmittereMinima = 0f;
        private readonly float _praeruptioAuditaeTempusStudiumAmittere = 12f;
        private readonly float _tempusVisaeStudiumHabereMaxima = 1f;
        private readonly float _tempusVisaeStudiumHabereMedia = 0.5f;
        private readonly float _tempusVisaeStudiumHabereMinima = 0f;
        private readonly float _praeruptioVisaeTempusStudiumHabere = 16f;
        private readonly float _tempusVisaeStudiumAmittereMaxima = 10f;
        private readonly float _tempusVisaeStudiumAmittereMedia = 5f;
        private readonly float _tempusVisaeStudiumAmittereMinima = 0f;
        private readonly float _praeruptioVisaeTempusStudiumAmittere = 12f;
        private readonly float _tempusAuditaeConservandi = 1f;
        private readonly float _tempusVisaeConservandi = 1f;

        private readonly bool[] _estAugereAuditae;
        private readonly bool[] _estAugereVisae;


        public AbaciCivisStatus(
            IOstiumCivisLegibile civis
        ) {
            _longitudo = civis.Longitudo;
            _abacusStudiumHabereAuditae = new AbacusTemporis[_longitudo];
            _abacusStudiumAmittereAuditae = new AbacusTemporis[_longitudo];
            _abacusStudiumHabereVisae = new AbacusTemporis[_longitudo];
            _abacusStudiumAmittereVisae = new AbacusTemporis[_longitudo];
            _horologiumAuditaeConservandi = new Horologium[_longitudo];
            _horologiumVisaeConservandi = new Horologium[_longitudo];
            _estAugereAuditae = new bool[_longitudo];
            _estAugereVisae = new bool[_longitudo];

            for (int i = 0; i < _longitudo; i++) {
                _abacusStudiumHabereAuditae[i] = new AbacusTemporis(
                    _tempusAuditaeStudiumHabereMaxima,
                    _tempusAuditaeStudiumHabereMinima,
                    _tempusAuditaeStudiumHabereMedia,
                    _praeruptioAuditaeTempusStudiumHabere
                );
                _abacusStudiumAmittereAuditae[i] = new AbacusTemporis(
                    _tempusAuditaeStudiumAmittereMaxima,
                    _tempusAuditaeStudiumAmittereMinima,
                    _tempusAuditaeStudiumAmittereMedia,
                    _praeruptioAuditaeTempusStudiumAmittere
                );
                _abacusStudiumHabereVisae[i] = new AbacusTemporis(
                    _tempusVisaeStudiumHabereMaxima,
                    _tempusVisaeStudiumHabereMinima,
                    _tempusVisaeStudiumHabereMedia,
                    _praeruptioVisaeTempusStudiumHabere
                );
                _abacusStudiumAmittereVisae[i] = new AbacusTemporis(
                    _tempusVisaeStudiumAmittereMaxima,
                    _tempusVisaeStudiumAmittereMinima,
                    _tempusVisaeStudiumAmittereMedia,
                    _praeruptioVisaeTempusStudiumAmittere
                );
                _horologiumAuditaeConservandi[i] = new Horologium(
                    _tempusAuditaeConservandi
                );
                _horologiumVisaeConservandi[i] = new Horologium(
                    _tempusVisaeConservandi
                );
                _estAugereAuditae[i] = false;
                _estAugereVisae[i] = false;
            }
        }

        public AbacusTemporis StudiumHabereAuditae(int idCivis) {
            return _abacusStudiumHabereAuditae[idCivis];
        }

        public AbacusTemporis StudiumAmittereAuditae(int idCivis) {
            return _abacusStudiumAmittereAuditae[idCivis];
        }

        public AbacusTemporis StudiumHabereVisae(int idCivis) {
            return _abacusStudiumHabereVisae[idCivis];
        }

        public AbacusTemporis StudiumAmittereVisae(int idCivis) {
            return _abacusStudiumAmittereVisae[idCivis];
        }

        private void ResolvereDirectionem(
            int idCivis,
            Horologium[] horo,
            AbacusTemporis[] abacusAmittere,
            AbacusTemporis[] abacusHabere,
            bool[] estAugerePrioris,
            bool estAugereCurrens,
            float intervallum
        ) {
            Horologium h = horo[idCivis];
            bool estAugere = estAugerePrioris[idCivis];

            if (estAugereCurrens == estAugere) {
                // 方向維持: 減少への切り替え猶予をキャンセルし、
                // 猶予中に進んだAmittereを捨てる（短い途切れ後の復帰で減少ランプを残さない）。
                if (h.EstActivum) {
                    h.Deactivare();
                    abacusAmittere[idCivis].Purgere();
                }
            } else if (estAugereCurrens) {
                // 減少 -> 増加: Amittereをリセット
                if (h.EstActivum) h.Deactivare();
                abacusAmittere[idCivis].Purgere();
                estAugerePrioris[idCivis] = true;
            } else {
                // 増加 -> 減少: 一定時間減少を待ってHabereをリセット
                if (!h.EstActivum) h.Activare();
                if (h.EstExhaurita(intervallum)) {
                    abacusHabere[idCivis].Purgere();
                    estAugerePrioris[idCivis] = false;
                    h.Deactivare();
                }
            }

            //Abacusを進める
            if (estAugereCurrens) {
                abacusHabere[idCivis].Pulsus(intervallum);
            } else {
                abacusAmittere[idCivis].Pulsus(intervallum);
            }
        }

        public void ResolvereDirectionemAuditae(int idCivis, bool estAugereCurrens, float intervallum) {
            ResolvereDirectionem(
                idCivis,
                _horologiumAuditaeConservandi,
                _abacusStudiumAmittereAuditae,
                _abacusStudiumHabereAuditae,
                _estAugereAuditae,
                estAugereCurrens,
                intervallum
            );
        }

        public void ResolvereDirectionemVisae(int idCivis, bool estAugereCurrens, float intervallum) {
            ResolvereDirectionem(
                idCivis,
                _horologiumVisaeConservandi,
                _abacusStudiumAmittereVisae,
                _abacusStudiumHabereVisae,
                _estAugereVisae,
                estAugereCurrens,
                intervallum
            );
        }

        public void Purgere(int idCivis) {
            _abacusStudiumHabereAuditae[idCivis].Purgere();
            _abacusStudiumAmittereAuditae[idCivis].Purgere();
            _abacusStudiumHabereVisae[idCivis].Purgere();
            _abacusStudiumAmittereVisae[idCivis].Purgere();

            _horologiumAuditaeConservandi[idCivis].Deactivare();
            _horologiumAuditaeConservandi[idCivis].Purgere();
            _horologiumVisaeConservandi[idCivis].Deactivare();
            _horologiumVisaeConservandi[idCivis].Purgere();

            _estAugereAuditae[idCivis] = false;
            _estAugereVisae[idCivis] = false;
        }

    }
}