using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Exercitus {
    internal sealed class OrdinatioPuellaeFiguraeGenus : OrdinatioPuellae, IOrdinatioPuellaeFiguraeGenus {
        private IDPuellaeFiguraeGenus _idFiguraeGenus;
        private LatusPuellaeGenus _latus;
        private float _pondus;

        public OrdinatioPuellaeFiguraeGenus(
        ) : base(true, SpeciesOrdinatioPuellae.FiguraGenus) {
            _idFiguraeGenus = default;
            _latus = default;
            _pondus = 0f;
        }

        public IDPuellaeFiguraeGenus IdFiguraeGenus => _idFiguraeGenus;
        public LatusPuellaeGenus Latus => _latus;
        public float Pondus => _pondus;

        public override void Purgere() {
            _estApplicandum = false;
            _idFiguraeGenus = default;
            _latus = default;
            _pondus = 0f;
        }

        public void Pono(
            IDPuellaeFiguraeGenus idFiguraeGenus,
            LatusPuellaeGenus latus,
            float pondus
        ) {
            _idFiguraeGenus = idFiguraeGenus;
            _latus = latus;
            _pondus = pondus;

            _estApplicandum = true;
        }
    }

    internal sealed class OrdinatioPuellaeFiguraePelvis : OrdinatioPuellae, IOrdinatioPuellaeFiguraePelvis {
        private IDPuellaeFiguraePelvis _idFiguraePelvis;
        private float _pondus;

        public OrdinatioPuellaeFiguraePelvis()
            : base(true, SpeciesOrdinatioPuellae.FiguraPelvis) {
            _idFiguraePelvis = default;
            _pondus = 0f;
        }

        public IDPuellaeFiguraePelvis IdFiguraePelvis => _idFiguraePelvis;
        public float Pondus => _pondus;

        public override void Purgere() {
            _estApplicandum = false;
            _idFiguraePelvis = default;
            _pondus = 0f;
        }

        public void Pono(
            IDPuellaeFiguraePelvis idFiguraePelvis,
            float pondus
        ) {
            _idFiguraePelvis = idFiguraePelvis;
            _pondus = pondus;

            _estApplicandum = true;
        }
    }
}
