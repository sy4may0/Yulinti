namespace Yulinti.ImperiumDelegatum.Exercitus {
    // Executorのライフサイクルと、各Carrusの適用順を制御する。
    // 各Carrusは Postulare* の受付と使用済みOrdinatioの回収(Colligere)のみを担当する。
    internal sealed class AurigaPuellae {
        private readonly ExecutorPuellaeAnimationis _exAnimationis;
        private readonly ExecutorPuellaeCrinis _exCrinis;
        private readonly ExecutorPuellaeFigurae _exFigurae;
        private readonly ExecutorPuellaeLoci _exLoci;
        private readonly ExecutorPuellaeVeletudinis _exVeletudinis;
        private readonly ExecutorPuellaePersonae _exPersonae;
        private readonly ExecutorPuellaeFormae _exFormae;

        private readonly CarrusPuellaeAnimationis _carrusAnimationis;
        private readonly CarrusPuellaeCrinis _carrusCrinis;
        private readonly CarrusPuellaeFigurae _carrusFigurae;
        private readonly CarrusPuellaeLoci _carrusLoci;
        private readonly CarrusPuellaeVeletudinis _carrusVeletudinis;
        private readonly CarrusPuellaePersonae _carrusPersonae;
        private readonly CarrusPuellaeFormae _carrusFormae;

        public AurigaPuellae(
            ExecutorPuellaeAnimationis exAnimationis,
            ExecutorPuellaeCrinis exCrinis,
            ExecutorPuellaeFigurae exFigurae,
            ExecutorPuellaeLoci exLoci,
            ExecutorPuellaeVeletudinis exVeletudinis,
            ExecutorPuellaePersonae exPersonae,
            ExecutorPuellaeFormae exFormae,
            CarrusPuellaeAnimationis carrusAnimationis,
            CarrusPuellaeCrinis carrusCrinis,
            CarrusPuellaeFigurae carrusFigurae,
            CarrusPuellaeLoci carrusLoci,
            CarrusPuellaeVeletudinis carrusVeletudinis,
            CarrusPuellaePersonae carrusPersonae,
            CarrusPuellaeFormae carrusFormae
        ) {
            _exAnimationis = exAnimationis;
            _exCrinis = exCrinis;
            _exFigurae = exFigurae;
            _exLoci = exLoci;
            _exVeletudinis = exVeletudinis;
            _exPersonae = exPersonae;
            _exFormae = exFormae;

            _carrusAnimationis = carrusAnimationis;
            _carrusCrinis = carrusCrinis;
            _carrusFigurae = carrusFigurae;
            _carrusLoci = carrusLoci;
            _carrusVeletudinis = carrusVeletudinis;
            _carrusPersonae = carrusPersonae;
            _carrusFormae = carrusFormae;
        }

        public void Primum() {
            _exAnimationis.Primum();
            _exCrinis.Primum();
            _exFigurae.Primum();
            _exLoci.Primum();
            _exVeletudinis.Primum();
            _exPersonae.Primum();
            _exFormae.Primum();
        }

        // Start()の一番最初に実行する。
        public void Initare() {
            _exAnimationis.Initare();
            _exCrinis.Initare();
            _exFigurae.Initare();
            _exLoci.Initare();
            _exVeletudinis.Initare();
            _exPersonae.Initare();
            _exFormae.Initare();
        }

        private void ConfirmareAnimationis() {
            _exAnimationis.Confirmare();
            _carrusAnimationis.Colligere();
        }
        private void ConfirmareCrinis() {
            _exCrinis.Confirmare();
            _carrusCrinis.Colligere();
        }
        private void ConfirmareFigurae() {
            _exFigurae.Confirmare();
            _carrusFigurae.Colligere();
        }
        private void ConfirmareLoci() {
            _exLoci.Confirmare();
            _carrusLoci.Colligere();
        }
        private void ConfirmareVeletudinis() {
            _exVeletudinis.Confirmare();
            _carrusVeletudinis.Colligere();
        }
        private void ConfirmarePersonae() {
            _exPersonae.Confirmare();
            _carrusPersonae.Colligere();
        }

        private void ConfirmareFormae() {
            _exFormae.Confirmare();
            _carrusFormae.Colligere();
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
            // Formaeを適用
            ConfirmareFormae();

            ColligereOmnia();
        }

        public void Purgare() {
            _exAnimationis.Purgare();
            _exCrinis.Purgare();
            _exFigurae.Purgare();
            _exLoci.Purgare();
            _exVeletudinis.Purgare();
            _exPersonae.Purgare();
            _exFormae.Purgare();
            ColligereOmnia();
        }

        private void ColligereOmnia() {
            _carrusAnimationis.Colligere();
            _carrusCrinis.Colligere();
            _carrusFigurae.Colligere();
            _carrusLoci.Colligere();
            _carrusVeletudinis.Colligere();
            _carrusPersonae.Colligere();
            _carrusFormae.Colligere();
        }
    }
}
