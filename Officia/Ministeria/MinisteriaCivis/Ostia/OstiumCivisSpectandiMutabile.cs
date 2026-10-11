using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class OstiumCivisSpectandiMutabile : IOstiumCivisSpectandiMutabile {
        private readonly MinisteriumCivisSpectandi _miCivisSpectandi;

        public OstiumCivisSpectandiMutabile(MinisteriumCivisSpectandi miCivisSpectandi) {
            _miCivisSpectandi = miCivisSpectandi;
        }

        private bool VerificareID(int id) {
            if (id < 0 || id >= _miCivisSpectandi.Longitudo) return false;
            return true;
        }

        public void Activare(int id) {
            if (!VerificareID(id)) return;
            _miCivisSpectandi.Activare(id);
        }

        public void Deactivare(int id) {
            if (!VerificareID(id)) return;
            _miCivisSpectandi.Deactivare(id);
        }
    }
}
