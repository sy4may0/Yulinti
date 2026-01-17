using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System;
using System.Numerics;

namespace Yulinti.Dux.Exercitus {
    // Ordinatioを受け取り、Executorに渡す。
    // 適用順の制御はここでやる。
    internal sealed class CarrusCivis : IOstiumCarrusCivis {
        private readonly ExecutorCivisAnimationis _exAnimationis;
        private readonly ExecutorCivisLoci _exLoci;
        private readonly ExecutorCivisVeletudinisValoris _exVeletudinisValoris;
        private readonly ExecutorCivisMortis _exMortis;

        private readonly LacusOrdinatioCivis _lacusOrdinatioCivis;

        public CarrusCivis(
            IOstiumCivisLegibile ostiumCivisLegibile,
            ExecutorCivisAnimationis exAnimationis,
            ExecutorCivisLoci exLoci,
            ExecutorCivisVeletudinisValoris exVeletudinisValoris,
            ExecutorCivisMortis exMortis
        ) {
            _exAnimationis = exAnimationis;
            _exLoci = exLoci;
            _exVeletudinisValoris = exVeletudinisValoris;
            _exMortis = exMortis;
            _lacusOrdinatioCivis = new LacusOrdinatioCivis(ostiumCivisLegibile.Longitudo);
        }

        public void Primum(int idCivis) {
            _exAnimationis.Primum(idCivis);
            _exLoci.Primum(idCivis);
            _exVeletudinisValoris.Primum(idCivis);
            _exMortis.Primum(idCivis);
        }

        public void PonoAd(Action<int> adIncarnare, Action<int> adSpirituare) {
            _exMortis.PonoAdIncarnare(adIncarnare);
            _exMortis.PonoAdSpirituare(adSpirituare);
        }

        public void Initare(int idCivis) {
            _exAnimationis.Initare(idCivis);
            _exLoci.Initare(idCivis);
            _exVeletudinisValoris.Initare(idCivis);
            _exMortis.Initare(idCivis);
       }

        private void ConfirmareAnimationis(int idCivis) {
            _exAnimationis.Confirmare(idCivis);
            _lacusOrdinatioCivis.ColligereAnimationis(idCivis);
        }

        private void ConfirmareLoci(int idCivis) {
            _exLoci.Confirmare(idCivis);
            _lacusOrdinatioCivis.ColligereMotus(idCivis);
            _lacusOrdinatioCivis.ColligereNavmesh(idCivis);
        }

        private void ConfirmareVeletudinisValoris(int idCivis) {
            _exVeletudinisValoris.Confirmare(idCivis);
            _lacusOrdinatioCivis.ColligereVeletudinisValoris(idCivis);
        }

        private void ConfirmareVeletudinisMortis(int idCivis) {
            _exMortis.Confirmare(idCivis);
            _lacusOrdinatioCivis.ColligereMortis(idCivis);
        }

        // Incipereの最後に実行 Civis生成時で適用が必要なケースはここでやる。
        public void ConfirmareIncipabilis(int idCivis) {
            ConfirmareLoci(idCivis);
            ConfirmareAnimationis(idCivis);
        }

        // Pulsusの最後に実行
        public void Confirmare(int idCivis) {
            // Lociから適用して速度回りを反映する。
            ConfirmareLoci(idCivis);
            // Animationisを適用
            ConfirmareAnimationis(idCivis);
        }

        // PulsusTardusの最後に実行
        public void ConfirmareTardus(int idCivis) {
            // Veletudinisを適用
            ConfirmareVeletudinisValoris(idCivis);
            ConfirmareVeletudinisMortis(idCivis);

            _lacusOrdinatioCivis.ColligereOmnia(idCivis);
        }

        public void Purgare(int idCivis) {
            _exAnimationis.Purgare(idCivis);
            _exLoci.Purgare(idCivis);
            _exVeletudinisValoris.Purgare(idCivis);
            _exMortis.Purgare(idCivis);
            _lacusOrdinatioCivis.ColligereOmnia(idCivis);
        }

        public void PostulareAnimationis(
            int idCivis,
            IDCivisAnimationisContinuata idAnimationis,
            Action adInitium = null,
            Action adFinem = null,
            bool estCogere = false
        ) {
            if (_lacusOrdinatioCivis.EmittareAnimationis(idCivis, out var ordinatio)) {
                ordinatio.Pono(idAnimationis, adInitium, adFinem, estCogere);
                _exAnimationis.Executare(idCivis, ordinatio);
            }
        }

        public void PostulareMotus(
            int idCivis,
            float velocitasHorizontalis,
            float tempusLevigatumHorizontalis,
            float rotatioYDeg,
            float tempusLevigatumRotationisYDeg
        ) {
            if (_lacusOrdinatioCivis.EmittareMotus(idCivis, out var ordinatio)) {
                ordinatio.Pono(velocitasHorizontalis, tempusLevigatumHorizontalis, rotatioYDeg, tempusLevigatumRotationisYDeg);
                _exLoci.Executare(idCivis, ordinatio);
            }
        }

        public void PostulareNavmesh(
            int idCivis,
            Vector3 positio,
            bool estTransporto,
            float velocitasDesiderata,
            float accelerationem,
            int velocitasRotationis,
            float distantiaDeaccelerationis
        ) {
            if (_lacusOrdinatioCivis.EmittareNavmesh(idCivis, out var ordinatio)) {
                ordinatio.Pono(positio, estTransporto, velocitasDesiderata, accelerationem, velocitasRotationis, distantiaDeaccelerationis);
                _exLoci.Executare(idCivis, ordinatio);
            }
        }

        public void PostulareVeletudinisValoris(
            int idCivis,
            float dtVitae = 0f,
            float dtVisus = 0f,
            float dtVisa = 0f,
            float dtAudita = 0f,
            float dtSuspecta = 0f
        ) {
            if (_lacusOrdinatioCivis.EmittareVeletudinisValoris(idCivis, out var ordinatio)) {
                ordinatio.Pono(dtVitae, dtVisus, dtVisa, dtAudita, dtSuspecta);
                _exVeletudinisValoris.Executare(idCivis, ordinatio);
            }
        }

        public void PostulareMortis(
            int idCivis,
            SpeciesOrdinationisCivisMortis speciesMortis
        ) {
            if (_lacusOrdinatioCivis.EmittareMortis(idCivis, out var ordinatio)) {
                ordinatio.Pono(speciesMortis);
                _exMortis.Executare(idCivis, ordinatio);
            }
        }
    }
}
