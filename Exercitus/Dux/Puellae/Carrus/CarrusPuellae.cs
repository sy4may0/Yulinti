using Yulinti.Exercitus.Contractus;
using System;
using System.Numerics;

namespace Yulinti.Exercitus.Dux {
    // Ordinatioを受け取り、Executorに渡す。
    // 適用順の制御はここでやる。
    internal sealed class CarrusPuellae : IOstiumCarrusPuellae {
        private readonly ExecutorPuellaeAnimationis _exAnimationis;
        private readonly ExecutorPuellaeCrinis _exCrinis;
        private readonly ExecutorPuellaeFigurae _exFigurae;
        private readonly ExecutorPuellaeLoci _exLoci;
        private readonly ExecutorPuellaeVeletudinis _exVeletudinis;
        private readonly ExecutorPuellaePersonae _exPersonae;
        
        private readonly LacusOrdinatioPuellae _lacusOrdinatioPuellae;

        public CarrusPuellae(
            ExecutorPuellaeAnimationis exAnimationis,
            ExecutorPuellaeCrinis exCrinis,
            ExecutorPuellaeFigurae exFigurae,
            ExecutorPuellaeLoci exLoci,
            ExecutorPuellaeVeletudinis exVeletudinis,
            ExecutorPuellaePersonae exPersonae
        ) {
            _exAnimationis = exAnimationis;
            _exCrinis = exCrinis;
            _exFigurae = exFigurae;
            _exLoci = exLoci;
            _exVeletudinis = exVeletudinis;
            _exPersonae = exPersonae;
            _lacusOrdinatioPuellae = new LacusOrdinatioPuellae();
        }

        public void Primum() {
            _exAnimationis.Primum();
            _exCrinis.Primum();
            _exFigurae.Primum();
            _exLoci.Primum();
            _exVeletudinis.Primum();
            _exPersonae.Primum();
        }

        // Start()の一番最初に実行する。
        public void Initare() {
            _exAnimationis.Initare();
            _exCrinis.Initare();
            _exFigurae.Initare();
            _exLoci.Initare();
            _exVeletudinis.Initare();
            _exPersonae.Initare();
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
            _lacusOrdinatioPuellae.ColligereNavmeshInitii();
        }
        private void ConfirmareVeletudinis() {
            _exVeletudinis.Confirmare();
            _lacusOrdinatioPuellae.ColligereVeletudinis();
            _lacusOrdinatioPuellae.ColligereVeletudinisNudi();
        }
        private void ConfirmarePersonae() {
            _exPersonae.Confirmare();
            _lacusOrdinatioPuellae.ColligerePersonae();
        }

        // Incipereの最後に実行 Start()で適用が必要なケースはここでやる。
        public void ConfirmareIncipabilis() {
            ConfirmareAnimationis();
            ConfirmareCrinis();
            ConfirmareVeletudinis();
            // 最後にLoci適用(初期ポイントに移動する。)
            ConfirmareLoci();
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
            // Personaeを適用
            ConfirmarePersonae();

            _lacusOrdinatioPuellae.ColligereOmnia();
        }

        public void Purgare() {
            _exAnimationis.Purgare();
            _exCrinis.Purgare();
            _exFigurae.Purgare();
            _exLoci.Purgare();
            _exVeletudinis.Purgare();
            _exPersonae.Purgare();
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

        public void PostulareNavmeshInitii(
            Vector3 positio,
            Quaternion rotatio
        ){
            if(_lacusOrdinatioPuellae.EmittareNavmeshInitii(out var ordinatio)) {
                ordinatio.Pono(positio, rotatio);
                _exLoci.Executare(ordinatio);
            }
        }

        public void PostulareVeletudinis(
            float dtVigoris = 0f,
            float dtPatientiae = 0f,
            float dtAetheris = 0f,
            float dtIntentio = 0f,
            float dtDedecus = 0f,
            float dtClaritas = 0f,
            float dtSonusQuietes = 0f,
            float dtSonusMotus = 0f
        ){
            if(_lacusOrdinatioPuellae.EmittareVeletudinis(out var ordinatio)) {
                ordinatio.Pono(
                    dtVigoris, dtPatientiae, dtAetheris,
                    dtIntentio, dtDedecus, dtClaritas,
                    dtSonusQuietes, dtSonusMotus
                );
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

        public void PostularePersonae(
            int dtAnimaeLuxuriosus = 0,
            int dtAnimaeExhibitus = 0,
            int dtAnimaePerversus = 0,
            int dtAnimaeQuaeritDolore = 0,
            int dtAnimaePapillae = 0,
            int dtAnimaeLandicae = 0,
            int dtAnimaeVaginae = 0,
            int dtAnimaeAni = 0,
            int dtAnimaeAusculum = 0,
            int dtAnimaeCorporis = 0
        ) {
            if(_lacusOrdinatioPuellae.EmittarePersonae(out var ordinatio)) {
                ordinatio.Pono(
                    dtAnimaeLuxuriosus,
                    dtAnimaeExhibitus,
                    dtAnimaePerversus,
                    dtAnimaeQuaeritDolore,
                    dtAnimaePapillae,
                    dtAnimaeLandicae,
                    dtAnimaeVaginae,
                    dtAnimaeAni,
                    dtAnimaeAusculum,
                    dtAnimaeCorporis
                );
                _exPersonae.Executare(ordinatio);
            }
        }
    }
}
