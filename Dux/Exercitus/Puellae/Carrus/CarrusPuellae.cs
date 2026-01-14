using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;
using System.Numerics;

namespace Yulinti.Dux.Exercitus {
    // Ordinatioを受け取り、Executorに渡す。
    internal sealed class CarrusPuellae : IOstiumCarrusPuellae {
        private readonly ExecutorPuellaeAnimationis _exAnimationis;
        private readonly ExecutorPuellaeCrinis _exCrinis;
        private readonly ExecutorPuellaeFigurae _exFigurae;
        private readonly ExecutorPuellaeLoci _exLoci;
        private readonly ExecutorPuellaeVeletudinis _exVeletudinis;
        
        private readonly LacusOrdinatioPuellae _lacusOrdinatioPuellae;

        public CarrusPuellae(
            ExecutorPuellaeAnimationis exAnimationis,
            ExecutorPuellaeCrinis exCrinis,
            ExecutorPuellaeFigurae exFigurae,
            ExecutorPuellaeLoci exLoci,
            ExecutorPuellaeVeletudinis exVeletudinis
        ) {
            _exAnimationis = exAnimationis;
            _exCrinis = exCrinis;
            _exFigurae = exFigurae;
            _exLoci = exLoci;
            _exVeletudinis = exVeletudinis;
            _lacusOrdinatioPuellae = new LacusOrdinatioPuellae();
        }

        public void Primum() {
            _exAnimationis.Primum();
            _exCrinis.Primum();
            _exFigurae.Primum();
            _exLoci.Primum();
            _exVeletudinis.Primum();
        }

        // Incipereの最後に実行 Start()で適用が必要なケースはここでやる。
        public void ConfirmareIncipabilis() {
            _exAnimationis.Confirmare();
            _lacusOrdinatioPuellae.ColligereAnimationis();
            _exCrinis.Confirmare();
            _lacusOrdinatioPuellae.ColligereCrinis();
        }

        // Pulsusの最後に実行
        public void Confirmare() {
            // Lociから適用して速度回りを反映する。
            _exLoci.Confirmare();
            _lacusOrdinatioPuellae.ColligereMotus();
            _lacusOrdinatioPuellae.ColligereNavmesh();

            // Animationisを適用
            _exAnimationis.Confirmare();
            _lacusOrdinatioPuellae.ColligereAnimationis();
        }

        // PulsusTardusの最後に実行
        public void ConfirmareTardus() {
            // Crinisを適用
            _exCrinis.Confirmare();
            _lacusOrdinatioPuellae.ColligereCrinis();
            // Figuraeを適用
            _exFigurae.Confirmare();
            _lacusOrdinatioPuellae.ColligereFiguraeGenus();
            _lacusOrdinatioPuellae.ColligereFiguraePelvis();

            // Veletudinisを適用
            _exVeletudinis.Confirmare();
            _lacusOrdinatioPuellae.ColligereVeletudinis();

            _lacusOrdinatioPuellae.ColligereOmnia();
        }

        public void Purgare() {
            _exAnimationis.Purgare();
            _exCrinis.Purgare();
            _exFigurae.Purgare();
            _exLoci.Purgare();
            _exVeletudinis.Purgare();
            _lacusOrdinatioPuellae.ColligereOmnia();
        }

        public void ExecutareAnimationis(
            IDPuellaeAnimationisContinuata idAnimationis,
            Action adInitium = null,
            Action adFinem = null,
            bool estCogere = false
        ){
            if(_lacusOrdinatioPuellae.EmittareAnimationis(out var ordinatio)) {
                ordinatio.Pono(idAnimationis, adInitium, adFinem, estCogere);
                _exAnimationis.Executare(ordinatio);
            }
        }

        public void ExecutareCrinis(
            IDPuellaeCrinis idCrinis
        ){
            if(_lacusOrdinatioPuellae.EmittareCrinis(out var ordinatio)) {
                ordinatio.Pono(idCrinis);
                _exCrinis.Executare(ordinatio);
            }
        }

        public void ExecutareFiguraeGenus(
            IDPuellaeFiguraeGenus idFiguraeGenus,
            LatusPuellaeGenus latus,
            float pondus
        ){
            if(_lacusOrdinatioPuellae.EmittareFiguraeGenus(out var ordinatio)) {
                ordinatio.Pono(idFiguraeGenus, latus, pondus);
                _exFigurae.Executare(ordinatio);
            }
        }

        public void ExecutareFiguraePelvis(
            IDPuellaeFiguraePelvis idFiguraePelvis,
            float pondus
        ){
            if(_lacusOrdinatioPuellae.EmittareFiguraePelvis(out var ordinatio)) {
                ordinatio.Pono(idFiguraePelvis, pondus);
                _exFigurae.Executare(ordinatio);
            }
        }

        public void ExecutareMotus(
            float velocitasHorizontalis,
            float tempusLevigatumHorizontalis,
            float rotatioYDeg,
            float tempusLevigatumRotationisYDeg
        ){
            if(_lacusOrdinatioPuellae.EmittareMotus(out var ordinatio)) {
                ordinatio.Pono(velocitasHorizontalis, tempusLevigatumHorizontalis, rotatioYDeg, tempusLevigatumRotationisYDeg);
                _exLoci.Executare(ordinatio);
            }
        }

        public void ExecutareNavmesh(
            Vector3 positio,
            float velocitasDesiderata,
            float accelerationem,
            int velocitasRotationis,
            float distantiaDeaccelerationis
        ){
            if(_lacusOrdinatioPuellae.EmittareNavmesh(out var ordinatio)) {
                ordinatio.Pono(positio, velocitasDesiderata, accelerationem, velocitasRotationis, distantiaDeaccelerationis);
                _exLoci.Executare(ordinatio);
            }
        }

        public void ExecutareVeletudinis(
            float dtVigoris,
            float dtPatientiae,
            float dtAetheris,
            float dtIntentio,
            float dtClaritas
        ){
            if(_lacusOrdinatioPuellae.EmittareVeletudinis(out var ordinatio)) {
                ordinatio.Pono(dtVigoris, dtPatientiae, dtAetheris, dtIntentio, dtClaritas);
                _exVeletudinis.Executare(ordinatio);
            }
        }
    }
}