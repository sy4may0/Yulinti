using Yulinti.ImperiumDelegatum.Contractus;
using System;
using System.Numerics;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    // Ordinatioを受け取り、Executorに渡す。
    // 適用順の制御はここでやる。
    internal sealed class CarrusCivis : IOstiumCarrusCivis {
        private readonly ExecutorCivisAnimationis _exAnimationis;
        private readonly ExecutorCivisLoci _exLoci;
        private readonly ExecutorCivisVeletudinis _exVeletudinis;
        private readonly ExecutorCivisMortis _exMortis;
        private readonly ExecutorCivisCustodiae _exCustodiae;

        private readonly LacusOrdinatioCivis _lacusOrdinatioCivis;

        public CarrusCivis(
            IOstiumCivisLegibile ostiumCivisLegibile,
            ExecutorCivisAnimationis exAnimationis,
            ExecutorCivisLoci exLoci,
            ExecutorCivisVeletudinis exVeletudinis,
            ExecutorCivisMortis exMortis,
            ExecutorCivisCustodiae exCustodiae
        ) {
            _exAnimationis = exAnimationis;
            _exLoci = exLoci;
            _exVeletudinis = exVeletudinis;
            _exMortis = exMortis;
            _exCustodiae = exCustodiae;
            _lacusOrdinatioCivis = new LacusOrdinatioCivis(ostiumCivisLegibile.Longitudo);
        }

        public void Primum(int idCivis) {
            _exAnimationis.Primum(idCivis);
            _exLoci.Primum(idCivis);
            _exVeletudinis.Primum(idCivis);
            _exMortis.Primum(idCivis);
            _exCustodiae.Primum(idCivis);
        }

        public void Initare(int idCivis) {
            _exAnimationis.Initare(idCivis);
            _exLoci.Initare(idCivis);
            _exVeletudinis.Initare(idCivis);
            _exMortis.Initare(idCivis);
            _exCustodiae.Initare(idCivis);
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
            _exVeletudinis.Confirmare(idCivis);
            _lacusOrdinatioCivis.ColligereVeletudinisValoris(idCivis);
            _lacusOrdinatioCivis.ColligereVeletudinisMaxima(idCivis);
            _lacusOrdinatioCivis.ColligereVeletudinisCondicionis(idCivis);
        }

        private void ConfirmareVeletudinisMortis(int idCivis) {
            _exMortis.Confirmare(idCivis);
            _lacusOrdinatioCivis.ColligereMortis(idCivis);
        }

        private void ConfirmareCustodiae(int idCivis) {
            _exCustodiae.Confirmare(idCivis);
            _lacusOrdinatioCivis.ColligereCustodiae(idCivis);
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
            // Custodiaを適用
            ConfirmareCustodiae(idCivis);

            _lacusOrdinatioCivis.ColligereOmnia(idCivis);
        }

        // PulsusTardusで全IDに対して実行する。
        public void ConfirmareMortis(int idCivis) {
            ConfirmareVeletudinisMortis(idCivis);
        }

        public void Purgare(int idCivis) {
            _exAnimationis.Purgare(idCivis);
            _exLoci.Purgare(idCivis);
            _exVeletudinis.Purgare(idCivis);
            _exMortis.Purgare(idCivis);
            _exCustodiae.Purgare(idCivis);
            _lacusOrdinatioCivis.ColligereOmnia(idCivis);
        }

        public void PostulareAnimationis(int idCivis, IDCivisAnimationisStratum stratum, IDCivisAnimationis idAnimationis) {
            if (_lacusOrdinatioCivis.EmittareAnimationis(idCivis, out var ordinatio)) {
                ordinatio.Pono(stratum, idAnimationis);
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
            float dtAuditus = 0f,
            float dtSuspecta = 0f,
            float dtStudium = 0f,
            float dtIntentio = 0f,
            float dtTorelantiaAnomaliaeMaxima = 0f,
            float dtTorelantiaAnomaliaeMinima = 0f
        ) {
            if (_lacusOrdinatioCivis.EmittareVeletudinisValoris(idCivis, out var ordinatio)) {
                ordinatio.Pono(
                    dtVitae, dtVisus, dtAuditus, dtSuspecta, dtStudium,
                    dtIntentio, dtTorelantiaAnomaliaeMaxima, dtTorelantiaAnomaliaeMinima
                );
                _exVeletudinis.Executare(idCivis, ordinatio);
            }
        }

        public void PostulareVeletudinisMaxima(
            int idCivis,
            float dtVitaeMaxima = 0f,
            float dtVisusMaxima = 0f,
            float dtAuditusMaxima = 0f,
            float dtSuspectaMaxima = 0f,
            float dtStudiumMaxima = 0f,
            float dtIntentioMaxima = 0f,
            float dtTorelantiaAnomaliaeMaximaMaxima = 0f,
            float dtTorelantiaAnomaliaeMinimaMaxima = 0f
        ) {
            if (_lacusOrdinatioCivis.EmittareVeletudinisMaxima(idCivis, out var ordinatio)) {
                ordinatio.Pono(
                    dtVitaeMaxima, dtVisusMaxima, dtAuditusMaxima,
                    dtSuspectaMaxima, dtStudiumMaxima, dtIntentioMaxima,
                    dtTorelantiaAnomaliaeMaximaMaxima, dtTorelantiaAnomaliaeMinimaMaxima
                );
                _exVeletudinis.Executare(idCivis, ordinatio);
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

        public void PostulareVeletudinisCondicionis(
            int idCivis,
            bool? estSpectareNudusAnterior = null,
            bool? estSpectareNudusPosterior = null,
            IDCivisStatusCustodiae? statusCustodiaeCurrens = IDCivisStatusCustodiae.Nihil
        ) {
            if (_lacusOrdinatioCivis.EmittareVeletudinisCondicionis(idCivis, out var ordinatio)) {
                ordinatio.Pono(
                    estSpectareNudusAnterior, estSpectareNudusPosterior, statusCustodiaeCurrens
                );
                _exVeletudinis.Executare(idCivis, ordinatio);
            }
        }

        public void PostulareCustodiaeDistantia(
            int idCivis,
            float distantiaPuellae,
            bool estCustodiaeVisae,
            bool estCustodiaeAuditae
        ) {
            if (_lacusOrdinatioCivis.EmittareCustodiae(idCivis, out var ordinatio)) {
                ordinatio.Pono(
                    distantiaPuellae: distantiaPuellae,
                    estCustodiaeVisae: estCustodiaeVisae,
                    estCustodiaeAuditae: estCustodiaeAuditae
                );
                _exCustodiae.Executare(idCivis, ordinatio);
            }
        }

        public void PostulareCustodiaeIctuumVisae(
            int idCivis,
            float visaCapitis,
            float visaCorporis
        ) {
            if (_lacusOrdinatioCivis.EmittareCustodiae(idCivis, out var ordinatio)) {
                ordinatio.Pono(
                    visaCapitis: visaCapitis,
                    visaCorporis: visaCorporis
                );
                _exCustodiae.Executare(idCivis, ordinatio);
            }
        }

        public void PostulareCustodiaeIctuumAuditae(
            int idCivis,
            float audita
        ) {
            if (_lacusOrdinatioCivis.EmittareCustodiae(idCivis, out var ordinatio)) {
                ordinatio.Pono(
                    audita: audita
                );
                _exCustodiae.Executare(idCivis, ordinatio);
            }
        }
    }
}
