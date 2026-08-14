using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class OrdinatioCivisManifestationis : IOrdinatioCivisManifestationis {
        private IDCivisPersonae _idCivisPersonae;
        private bool _estApplicandum;

        public OrdinatioCivisManifestationis() {
            _idCivisPersonae = IDCivisPersonae.Nihil;
            _estApplicandum = true;
        }

        public IDCivisPersonae IdCivisPersonae => _idCivisPersonae;
        public bool EstApplicandum => _estApplicandum;

        public void Initare() {
            _estApplicandum = true;
        }

        public void Liberare() {
            _estApplicandum = false;
        }

        public void Purgere() {
            _estApplicandum = false;
            _idCivisPersonae = IDCivisPersonae.Nihil;
        }

        public void Pono(IDCivisPersonae idCivisPersonae) {
            _estApplicandum = true;
            _idCivisPersonae = idCivisPersonae;
        }
    }
}
