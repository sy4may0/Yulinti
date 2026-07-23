using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Instrumentarium;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class AbaciCivisStatus {
        private readonly int _longitudo;
        private readonly AbacusTemporis[] _abacusStudiumHabereSuspectae;
        private readonly AbacusTemporis[] _abacusStudiumAmittereSuspectae;
        private readonly AbacusTemporis[] _abacusStudiumHabereStudii;
        private readonly AbacusTemporis[] _abacusStudiumAmittereStudii;
        private readonly AbacusTemporis[] _abacusStudiumHabereIntentionis;
        private readonly AbacusTemporis[] _abacusStudiumAmittereIntentionis;

        private readonly Horologium[] _horologiumSuspectaeConservandi;
        private readonly Horologium[] _horologiumStudiiConservandi;
        private readonly Horologium[] _horologiumIntentionisConservandi;

        private readonly bool[] _estAugereSuspectae;
        private readonly bool[] _estAugereStudii;
        private readonly bool[] _estAugereIntentionis;


        public AbaciCivisStatus(
            IOstiumCivisLegibile civis,
            IConfiguratioCivisStatusCustodiaeCommunis configuratio
        ) {
            _longitudo = civis.Longitudo;
            _abacusStudiumHabereSuspectae = new AbacusTemporis[_longitudo];
            _abacusStudiumAmittereSuspectae = new AbacusTemporis[_longitudo];
            _abacusStudiumHabereStudii = new AbacusTemporis[_longitudo];
            _abacusStudiumAmittereStudii = new AbacusTemporis[_longitudo];
            _abacusStudiumHabereIntentionis = new AbacusTemporis[_longitudo];
            _abacusStudiumAmittereIntentionis = new AbacusTemporis[_longitudo];
            _horologiumSuspectaeConservandi = new Horologium[_longitudo];
            _horologiumStudiiConservandi = new Horologium[_longitudo];
            _horologiumIntentionisConservandi = new Horologium[_longitudo];
            _estAugereSuspectae = new bool[_longitudo];
            _estAugereStudii = new bool[_longitudo];
            _estAugereIntentionis = new bool[_longitudo];

            for (int i = 0; i < _longitudo; i++) {
                _abacusStudiumHabereSuspectae[i] = new AbacusTemporis(
                    configuratio.TempusSuspectaeStudiumHabereMaxima,
                    configuratio.TempusSuspectaeStudiumHabereMinima,
                    configuratio.TempusSuspectaeStudiumHabereMedia,
                    configuratio.PraeruptioSuspectaeTempusStudiumHabere
                );
                _abacusStudiumAmittereSuspectae[i] = new AbacusTemporis(
                    configuratio.TempusSuspectaeStudiumAmittereMaxima,
                    configuratio.TempusSuspectaeStudiumAmittereMinima,
                    configuratio.TempusSuspectaeStudiumAmittereMedia,
                    configuratio.PraeruptioSuspectaeTempusStudiumAmittere
                );
                _abacusStudiumHabereStudii[i] = new AbacusTemporis(
                    configuratio.TempusStudiiStudiumHabereMaxima,
                    configuratio.TempusStudiiStudiumHabereMinima,
                    configuratio.TempusStudiiStudiumHabereMedia,
                    configuratio.PraeruptioStudiiTempusStudiumHabere
                );
                _abacusStudiumAmittereStudii[i] = new AbacusTemporis(
                    configuratio.TempusStudiiStudiumAmittereMaxima,
                    configuratio.TempusStudiiStudiumAmittereMinima,
                    configuratio.TempusStudiiStudiumAmittereMedia,
                    configuratio.PraeruptioStudiiTempusStudiumAmittere
                );
                _abacusStudiumHabereIntentionis[i] = new AbacusTemporis(
                    configuratio.TempusIntentionisStudiumHabereMaxima,
                    configuratio.TempusIntentionisStudiumHabereMinima,
                    configuratio.TempusIntentionisStudiumHabereMedia,
                    configuratio.PraeruptioIntentionisTempusStudiumHabere
                );
                _abacusStudiumAmittereIntentionis[i] = new AbacusTemporis(
                    configuratio.TempusIntentionisStudiumAmittereMaxima,
                    configuratio.TempusIntentionisStudiumAmittereMinima,
                    configuratio.TempusIntentionisStudiumAmittereMedia,
                    configuratio.PraeruptioIntentionisTempusStudiumAmittere
                );
                _horologiumSuspectaeConservandi[i] = new Horologium(
                    configuratio.TempusSuspectaeConservandi
                );
                _horologiumStudiiConservandi[i] = new Horologium(
                    configuratio.TempusStudiiConservandi
                );
                _horologiumIntentionisConservandi[i] = new Horologium(
                    configuratio.TempusIntentionisConservandi
                );
                _estAugereSuspectae[i] = false;
                _estAugereStudii[i] = false;
                _estAugereIntentionis[i] = false;
            }
        }

        public AbacusTemporis StudiumHabereSuspectae(int idCivis) {
            return _abacusStudiumHabereSuspectae[idCivis];
        }

        public AbacusTemporis StudiumAmittereSuspectae(int idCivis) {
            return _abacusStudiumAmittereSuspectae[idCivis];
        }

        public AbacusTemporis StudiumHabereStudii(int idCivis) {
            return _abacusStudiumHabereStudii[idCivis];
        }

        public AbacusTemporis StudiumAmittereStudii(int idCivis) {
            return _abacusStudiumAmittereStudii[idCivis];
        }

        public AbacusTemporis StudiumHabereIntentionis(int idCivis) {
            return _abacusStudiumHabereIntentionis[idCivis];
        }

        public AbacusTemporis StudiumAmittereIntentionis(int idCivis) {
            return _abacusStudiumAmittereIntentionis[idCivis];
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

        public void ResolvereDirectionemSuspectae(int idCivis, bool estAugereCurrens, float intervallum) {
            ResolvereDirectionem(
                idCivis,
                _horologiumSuspectaeConservandi,
                _abacusStudiumAmittereSuspectae,
                _abacusStudiumHabereSuspectae,
                _estAugereSuspectae,
                estAugereCurrens,
                intervallum
            );
        }

        public void ResolvereDirectionemStudii(int idCivis, bool estAugereCurrens, float intervallum) {
            ResolvereDirectionem(
                idCivis,
                _horologiumStudiiConservandi,
                _abacusStudiumAmittereStudii,
                _abacusStudiumHabereStudii,
                _estAugereStudii,
                estAugereCurrens,
                intervallum
            );
        }

        public void ResolvereDirectionemIntentionis(int idCivis, bool estAugereCurrens, float intervallum) {
            ResolvereDirectionem(
                idCivis,
                _horologiumIntentionisConservandi,
                _abacusStudiumAmittereIntentionis,
                _abacusStudiumHabereIntentionis,
                _estAugereIntentionis,
                estAugereCurrens,
                intervallum
            );
        }

        public void Purgere(int idCivis) {
            PurgereSuspectae(idCivis);
            PurgereStudii(idCivis);
            PurgereIntentionis(idCivis);
        }

        public void PurgereSuspectae(int idCivis) {
            _abacusStudiumHabereSuspectae[idCivis].Purgere();
            _abacusStudiumAmittereSuspectae[idCivis].Purgere();
            _horologiumSuspectaeConservandi[idCivis].Deactivare();
            _horologiumSuspectaeConservandi[idCivis].Purgere();
            _estAugereSuspectae[idCivis] = false;
        }

        public void PurgereStudii(int idCivis) {
            _abacusStudiumHabereStudii[idCivis].Purgere();
            _abacusStudiumAmittereStudii[idCivis].Purgere();
            _horologiumStudiiConservandi[idCivis].Deactivare();
            _horologiumStudiiConservandi[idCivis].Purgere();
            _estAugereStudii[idCivis] = false;
        }

        public void PurgereIntentionis(int idCivis) {
            _abacusStudiumHabereIntentionis[idCivis].Purgere();
            _abacusStudiumAmittereIntentionis[idCivis].Purgere();
            _horologiumIntentionisConservandi[idCivis].Deactivare();
            _horologiumIntentionisConservandi[idCivis].Purgere();
            _estAugereIntentionis[idCivis] = false;
        }
    }
}
