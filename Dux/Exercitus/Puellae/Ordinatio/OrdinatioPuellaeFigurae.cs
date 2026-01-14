using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Exercitus {
    internal readonly class OrdinatioPuellaeFiguraeGenus : IOrdinatioPuellaeFiguraeGenus {
        private readonly SpeciesOrdinatioPuellae _species = SpeciesOrdinatioPuellae.Figura;
        private bool _estApplicandum;

        private IDPuellaeFiguraeGenus _idFiguraeGenus;
        private LatusPuellaeGenus _latus;
        private float _pondus;

        public OrdinatioPuellaeFiguraeGenus(
            LatusPuellaeGenus latus = LatusPuellaeGenus.Sinistra
        ) {
            _estApplicandum = true;
            _idFiguraeGenus = default;
            _latus = latus;
            _pondus = 0f;
        }

        public bool EstApplicandum => _estApplicandum;
        public SpeciesOrdinatioPuellae Species => _species;
        public IDPuellaeFiguraeGenus IdFiguraeGenus => _idFiguraeGenus;
        public LatusPuellaeGenus Latus => _latus;
        public float Pondus => _pondus;

        public void Purgere() {
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

    internal readonly class OrdinatioPuellaeFiguraePelvis : IOrdinatioPuellaeFiguraePelvis {
        private readonly SpeciesOrdinatioPuellae _species = SpeciesOrdinatioPuellae.Figura;
        private bool _estApplicandum;

        private IDPuellaeFiguraePelvis _idFiguraePelvis;
        private float _pondus;

        public OrdinatioPuellaeFiguraePelvis() {
            _estApplicandum = true;
            _idFiguraePelvis = default;
            _pondus = 0f;
        }

        public bool EstApplicandum => _estApplicandum;
        public SpeciesOrdinatioPuellae Species => _species;
        public IDPuellaeFiguraePelvis IdFiguraePelvis => _idFiguraePelvis;
        public float Pondus => _pondus;

        public void Purgere() {
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
