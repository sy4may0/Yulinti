using Yulinti.Dux.ContractusDucis;
using System;
using System.Numerics;

namespace Yulinti.Dux.Exercitus {
    // Ordinatioを受け取り、Executorに渡す。
    // 適用順の制御はここでやる。
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

        // Start()の一番最初に実行する。
        public void Initare() {
            _exAnimationis.Initare();
            _exCrinis.Initare();
            _exFigurae.Initare();
            _exLoci.Initare();
            _exVeletudinis.Initare();
        }

        private void ConfirmareAnimationis() {
            _exAnimationis.Confirmare();
            _lacusOrdinatioPuellae.ColligereAnimationis();
        }
        private void ConfirmareCrinis() {
            _exCrinis.Confirmare();
            _lacusOrdinatioPuellae.ColligereCrinis();
        }
        private void ConfirmareFigurae() {
            _exFigurae.Confirmare();
            _lacusOrdinatioPuellae.ColligereFiguraeGenus();
            _lacusOrdinatioPuellae.ColligereFiguraePelvis();
        }
        private void ConfirmareLoci() {
            _exLoci.Confirmare();
            _lacusOrdinatioPuellae.ColligereMotus();
            _lacusOrdinatioPuellae.ColligereNavmesh();
        }
        private void ConfirmareVeletudinis() {
            _exVeletudinis.Confirmare();
            _lacusOrdinatioPuellae.ColligereVeletudinis();
            _lacusOrdinatioPuellae.ColligereVeletudinisNudi();
        }

        // Incipereの最後に実行 Start()で適用が必要なケースはここでやる。
        public void ConfirmareIncipabilis() {
            ConfirmareAnimationis();
            ConfirmareCrinis();
            ConfirmareVeletudinis();
        }

        // Pulsusの最後に実行
        public void Confirmare() {
            // Lociから適用して速度回りを反映する。
            ConfirmareLoci();
            // Animationisを適用
            ConfirmareAnimationis();
        }

        // PulsusTardusの最後に実行
        public void ConfirmareTardus() {
            // Crinisを適用
            ConfirmareCrinis();
            // Figuraeを適用
            ConfirmareFigurae();
            // Veletudinisを適用
            ConfirmareVeletudinis();

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

        public void PostulareAnimationis(
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

        public void PostulareCrinis(
            IDPuellaeCrinis idCrinis
        ){
            if(_lacusOrdinatioPuellae.EmittareCrinis(out var ordinatio)) {
                ordinatio.Pono(idCrinis);
                _exCrinis.Executare(ordinatio);
            }
        }

        public void PostulareFiguraeGenus(
            IDPuellaeFiguraeGenus idFiguraeGenus,
            LatusPuellaeGenus latus,
            float pondus
        ){
            if(_lacusOrdinatioPuellae.EmittareFiguraeGenus(out var ordinatio)) {
                ordinatio.Pono(idFiguraeGenus, latus, pondus);
                _exFigurae.Executare(ordinatio);
            }
        }

        public void PostulareFiguraePelvis(
            IDPuellaeFiguraePelvis idFiguraePelvis,
            float pondus
        ){
            if(_lacusOrdinatioPuellae.EmittareFiguraePelvis(out var ordinatio)) {
                ordinatio.Pono(idFiguraePelvis, pondus);
                _exFigurae.Executare(ordinatio);
            }
        }

        public void PostulareMotus(
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

        public void PostulareNavmesh(
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

        public void PostulareVeletudinis(
            float dtVigoris = 0f,
            float dtPatientiae = 0f,
            float dtAetheris = 0f,
            float dtIntentio = 0f,
            float dtClaritas = 0f
        ){
            if(_lacusOrdinatioPuellae.EmittareVeletudinis(out var ordinatio)) {
                ordinatio.Pono(dtVigoris, dtPatientiae, dtAetheris, dtIntentio, dtClaritas);
                _exVeletudinis.Executare(ordinatio);
            }
        }

        public void PostulareVeletudinisNudi(
            bool estNudusAnterior,
            bool estNudusPosterior
        ){
            if(_lacusOrdinatioPuellae.EmittareVeletudinisNudi(out var ordinatio)) {
                ordinatio.Pono(estNudusAnterior, estNudusPosterior);
                _exVeletudinis.Executare(ordinatio);
            }
        }
    }
}