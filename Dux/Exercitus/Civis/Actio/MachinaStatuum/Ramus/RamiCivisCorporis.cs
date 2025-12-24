using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class RamiCivisCorporis {
        private readonly IOstiumCivisLociNavmeshLegibile _osLociNavmeshLegibile;
        private readonly TabulaCivisVitae _tabulaVitae;

        public RamiCivisCorporis(
            IOstiumCivisLociNavmeshLegibile osLociNavmeshLegibile,
            TabulaCivisVitae tabulaVitae
        ) {
            _osLociNavmeshLegibile = osLociNavmeshLegibile;
            _tabulaVitae = tabulaVitae;
        }

        public bool EstExhauritaVitae(int idCivis, IResFluidaCivisMotusLegibile resFuluidaMotus) {
            return _tabulaVitae.EstExhaurita(idCivis);
        }

        public bool EstAdPerveni(int idCivis, IResFluidaCivisMotusLegibile resFuluidaMotus) {
            return _osLociNavmeshLegibile.EstAdPerveni(idCivis);
        }
    }
}