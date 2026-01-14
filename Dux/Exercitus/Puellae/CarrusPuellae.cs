namespace Yulinti.Dux.Exercitus {
    // Ordinatioを受け取り、Executorに渡す。
    internal sealed class CarrusPuellae {
        private readonly ExecutorPuellaeAnimationis _exAnimationis;
        private readonly ExecutorPuellaeCrinis _exCrinis;
        private readonly ExecutorPuellaeFigurae _exFigurae;
        private readonly ExecutorPuellaeLoci _exLoci;
        private readonly ExecutorPuellaeVeletudinis _exVeletudinis;

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
        }

        public void Primum() {
            _exAnimationis.Primum();
            _exCrinis.Primum();
            _exFigurae.Primum();
            _exLoci.Primum();
            _exVeletudinis.Primum();
        }

        public void Confirmare() {
            // ここは適用順を制御する所!!!
            // Lociから適用して速度回りを反映する。
            _exLoci.Confirmare();

            _exAnimationis.Confirmare();
            _exCrinis.Confirmare();
            _exFigurae.Confirmare();

            // Veletudinisは最後に適用する。
            _exVeletudinis.Confirmare();
        }

        public void Purgare() {
            _exAnimationis.Purgare();
            _exCrinis.Purgare();
            _exFigurae.Purgare();
            _exLoci.Purgare();
            _exVeletudinis.Purgare();
        }

        public void ExecutareAnimationis(
            IDPuellaeAnimationisContinuata idAnimationis,
            Action adInitium = null,
            Action adFinem = null,
            bool estCogere = false
        ){
            // [TODO] 実装
        }

        public void ExecutareCrinis(
            IDPuellaeCrinis idCrinis
        ){

            // [TODO] 実装
        }

        public void ExecutareFiguraeGenus(
            IDPuellaeFiguraeGenus idFiguraeGenus,
            LatusPuellaeGenus latus,
            float pondus
        ){

            // [TODO] 実装
        }

        public void ExecutareFiguraePelvis(
            IDPuellaeFiguraePelvis idFiguraePelvis,
            float pondus
        ){

            // [TODO] 実装
        }

        public void ExecutareMotus(
            float velocitasHorizontalis,
            float tempusLevigatumHorizontalis,
            float rotatioYDeg,
            float tempusLevigatumRotationisYDeg
        ){

            // [TODO] 実装
        }

        public void ExecutareNavmesh(
            Vector3 positio,
            float velocitasDesiderata,
            float accelerationem,
            int velocitasRotationis,
            float distantiaDeaccelerationis
        ){

            // [TODO] 実装
        }

        public void ExecutareVeletudinis(
            float dtVigoris,
            float dtPatientiae,
            float dtAetheris,
            float dtIntentio,
            float dtClaritas
        ){

            // [TODO] 実装
        }
    }
}