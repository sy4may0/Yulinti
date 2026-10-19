using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // Ordinatioを受け取り、Executorに渡す。
    internal sealed class CarrusPuellaeVeletudinis : IOstiumCarrusPuellaeVeletudinis {
        private readonly ExecutorPuellaeVeletudinis _exVeletudinis;

        private readonly LacusOrdinatioPuellaeVeletudinis _lacusOrdinatio;

        public CarrusPuellaeVeletudinis(
            ExecutorPuellaeVeletudinis exVeletudinis
        ) {
            _exVeletudinis = exVeletudinis;
            _lacusOrdinatio = new LacusOrdinatioPuellaeVeletudinis();
        }

        // AurigaがConfirmare後に実行する。使用済みOrdinatioをLacusへ回収する。
        public void Colligere() {
            _lacusOrdinatio.ColligereOmnia();
        }

        public void PostulareVeletudinis(
            float dtVigoris = 0f,
            float dtPatientiae = 0f,
            float dtAetheris = 0f,
            float dtIntentio = 0f,
            float dtDedecus = 0f,
            float dtClaritas = 0f,
            float dtAnomalia = 0f,
            float dtAnomaliaNudus = 0f,
            float dtSonusQuietes = 0f,
            float dtSonusMotus = 0f
        ){
            if(_lacusOrdinatio.EmittareVeletudinis(out var ordinatio)) {
                ordinatio.Pono(
                    dtVigoris, dtPatientiae, dtAetheris,
                    dtIntentio, dtDedecus, dtClaritas, dtAnomalia, dtAnomaliaNudus,
                    dtSonusQuietes, dtSonusMotus
                );
                _exVeletudinis.Executare(ordinatio);
            }
        }

        public void PostulareVeletudinisMaxima(
            float dtVigorMaxima = 0f,
            float dtPatientiaeMaxima = 0f,
            float dtAetherMaxima = 0f,
            float dtClaritasMaxima = 0f,
            float dtAnomaliaMaxima = 0f,
            float dtIntentioMaxima = 0f,
            float dtDedecusMaxima = 0f,
            float dtSonusQuietesMaxima = 0f,
            float dtSonusMotusMaxima = 0f
        ){
            if(_lacusOrdinatio.EmittareVeletudinisMaxima(out var ordinatio)) {
                ordinatio.Pono(
                    dtVigorMaxima, dtPatientiaeMaxima, dtAetherMaxima,
                    dtClaritasMaxima, dtAnomaliaMaxima, dtIntentioMaxima, dtDedecusMaxima,
                    dtSonusQuietesMaxima, dtSonusMotusMaxima
                );
                _exVeletudinis.Executare(ordinatio);
            }
        }

        public void PostulareVeletudinisNudi(
            bool estNudusAnterior,
            bool estNudusPosterior
        ){
            if(_lacusOrdinatio.EmittareVeletudinisNudi(out var ordinatio)) {
                ordinatio.Pono(estNudusAnterior, estNudusPosterior);
                _exVeletudinis.Executare(ordinatio);
            }
        }
    }
}
