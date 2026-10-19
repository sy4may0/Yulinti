namespace Yulinti.ImperiumDelegatum.Exercitus {
    // Executorのライフサイクルと、各Carrusの適用順を制御する。
    // 各Carrusは Postulare* の受付と使用済みOrdinatioの回収(Colligere)のみを担当する。
    internal sealed class AurigaCivis {
        private readonly ExecutorCivisAnimationis _exAnimationis;
        private readonly ExecutorCivisLoci _exLoci;
        private readonly ExecutorCivisVeletudinis _exVeletudinis;
        private readonly ExecutorCivisMortis _exMortis;
        private readonly ExecutorCivisCustodiae _exCustodiae;
        private readonly ExecutorCivisSpectandi _exSpectandi;

        private readonly CarrusCivisAnimationis _carrusAnimationis;
        private readonly CarrusCivisLoci _carrusLoci;
        private readonly CarrusCivisVeletudinis _carrusVeletudinis;
        private readonly CarrusCivisMortis _carrusMortis;
        private readonly CarrusCivisCustodiae _carrusCustodiae;
        private readonly CarrusCivisSpectandi _carrusSpectandi;

        public AurigaCivis(
            ExecutorCivisAnimationis exAnimationis,
            ExecutorCivisLoci exLoci,
            ExecutorCivisVeletudinis exVeletudinis,
            ExecutorCivisMortis exMortis,
            ExecutorCivisCustodiae exCustodiae,
            ExecutorCivisSpectandi exSpectandi,
            CarrusCivisAnimationis carrusAnimationis,
            CarrusCivisLoci carrusLoci,
            CarrusCivisVeletudinis carrusVeletudinis,
            CarrusCivisMortis carrusMortis,
            CarrusCivisCustodiae carrusCustodiae,
            CarrusCivisSpectandi carrusSpectandi
        ) {
            _exAnimationis = exAnimationis;
            _exLoci = exLoci;
            _exVeletudinis = exVeletudinis;
            _exMortis = exMortis;
            _exCustodiae = exCustodiae;
            _exSpectandi = exSpectandi;

            _carrusAnimationis = carrusAnimationis;
            _carrusLoci = carrusLoci;
            _carrusVeletudinis = carrusVeletudinis;
            _carrusMortis = carrusMortis;
            _carrusCustodiae = carrusCustodiae;
            _carrusSpectandi = carrusSpectandi;
        }

        public void Primum(int idCivis) {
            _exAnimationis.Primum(idCivis);
            _exLoci.Primum(idCivis);
            _exVeletudinis.Primum(idCivis);
            _exMortis.Primum(idCivis);
            _exCustodiae.Primum(idCivis);
            _exSpectandi.Primum(idCivis);
        }

        public void Initare(int idCivis) {
            _exAnimationis.Initare(idCivis);
            _exLoci.Initare(idCivis);
            _exVeletudinis.Initare(idCivis);
            _exMortis.Initare(idCivis);
            _exCustodiae.Initare(idCivis);
            _exSpectandi.Initare(idCivis);
       }

        public void Activare(int idCivis) {
            _exLoci.Activare(idCivis);
            _exVeletudinis.Activare(idCivis);
            _exCustodiae.Activare(idCivis);
        }
        
        public void Deactivare(int idCivis) {
            _exLoci.Deactivare(idCivis);
            _exVeletudinis.Deactivare(idCivis);
            _exCustodiae.Deactivare(idCivis);
        }

        private void ConfirmareAnimationis(int idCivis) {
            _exAnimationis.Confirmare(idCivis);
            _carrusAnimationis.Colligere(idCivis);
        }

        private void ConfirmareLoci(int idCivis) {
            _exLoci.Confirmare(idCivis);
            _carrusLoci.Colligere(idCivis);
        }

        private void ConfirmareVeletudinisValoris(int idCivis) {
            _exVeletudinis.Confirmare(idCivis);
            _carrusVeletudinis.Colligere(idCivis);
        }

        private void ConfirmareVeletudinisMortis(int idCivis) {
            _exMortis.Confirmare(idCivis);
            _carrusMortis.Colligere(idCivis);
        }

        private void ConfirmareCustodiae(int idCivis) {
            _exCustodiae.Confirmare(idCivis);
            _carrusCustodiae.Colligere(idCivis);
        }

        private void ConfirmareSpectandi(int idCivis) {
            _exSpectandi.Confirmare(idCivis);
            _carrusSpectandi.Colligere(idCivis);
        }

        // Incipereの最後に実行 Civis生成時で適用が必要なケースはここでやる。
        public void ConfirmareIncipabilis(int idCivis) {
            ConfirmareLoci(idCivis);
            ConfirmareAnimationis(idCivis);
            // Personae.Initareの加算VitaeをResFluidaへ確定する。
            // 次フレームPrimumがFluidusをResFluidaから再初期化するため、ここで書かないと初期値が消える。
            ConfirmareVeletudinisValoris(idCivis);
        }

        // Pulsusの最後に実行
        public void Confirmare(int idCivis) {
            // Lociから適用して速度回りを反映する。
            ConfirmareLoci(idCivis);
            // Animationisを適用
            ConfirmareAnimationis(idCivis);
            // Spectandiを適用
            ConfirmareSpectandi(idCivis);
        }

        // PulsusTardusの最後に実行
        public void ConfirmareTardus(int idCivis) {
            // Veletudinisを適用
            ConfirmareVeletudinisValoris(idCivis);
            // Custodiaを適用
            ConfirmareCustodiae(idCivis);

            ColligereOmnia(idCivis);
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
            _exSpectandi.Purgare(idCivis);
            ColligereOmnia(idCivis);
        }

        private void ColligereOmnia(int idCivis) {
            _carrusAnimationis.Colligere(idCivis);
            _carrusLoci.Colligere(idCivis);
            _carrusVeletudinis.Colligere(idCivis);
            _carrusMortis.Colligere(idCivis);
            _carrusCustodiae.Colligere(idCivis);
            _carrusSpectandi.Colligere(idCivis);
        }
    }
}
