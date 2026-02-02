using Yulinti.Dux.ContractusDucis;
using System.Threading;
using System.Threading.Tasks;

namespace Yulinti.Deus {
    internal sealed class TurrisSalsamenti : ITurrisSalsamenti {
        private readonly ThesaurusSalsamenti _thesaurusSalsamenti;
        private readonly Arcessitor _arcessitor;

        private IOstiumSalsamenti _salsamentumActualis;

        // Dirtyフラグ。
        private bool _estApplicandum;

        public TurrisSalsamenti() {
            _thesaurusSalsamenti = new ThesaurusSalsamenti();
            IScriba scriba = new ScribaOrdinarius();
            _arcessitor = new Arcessitor(scriba, _thesaurusSalsamenti);
            _estApplicandum = false;
        }

        public int Longitudo => _thesaurusSalsamenti.Longitudo;
        public long Revisio => _thesaurusSalsamenti.Revisio;

        public int IDSalsamentumActualis => _salsamentumActualis.IdDatumServatum;
        public IOstiumSalsamenti SalsamentumActualis => _salsamentumActualis;

        public bool Creare() {
            int idSalsamentum = _thesaurusSalsamenti.Creare();
            if (idSalsamentum == -1) return false;
            _salsamentumActualis = _thesaurusSalsamenti.Lego(idSalsamentum);
            _estApplicandum = true;
            return true;
        }

        public bool Seligere(int idSalsamentum) {
            _salsamentumActualis = _thesaurusSalsamenti.Lego(idSalsamentum);
            return true;
        }

        public bool SeligereNovissimum() {
            long revisio = 0;
            for(int i = 0; i < Longitudo; i++) {
                var d = _thesaurusSalsamenti.Lego(i);
                if (d == null) continue;
                if (d.Revisio > revisio) {
                    revisio = d.Revisio;
                    _salsamentumActualis = d;
                }
            }
            return true;
        }

        public IOstiumSalsamenti Lego(int idSalsamentum) {
            return _thesaurusSalsamenti.Lego(idSalsamentum);
        }

        public void Liberare(int idSalsamentum) {
            _thesaurusSalsamenti.Liberare(idSalsamentum);
            _estApplicandum = true;
        }

        public void Renovere(int idSalsamentum) {
            _thesaurusSalsamenti.Renovere(idSalsamentum);
            _estApplicandum = true;
        }

        public void Renovere(IResFluidaPuellaePersonaeLegibile resFluida) {
            int idSalsamentum = _salsamentumActualis.IdDatumServatum;
            _thesaurusSalsamenti.RenoverePuellaePersonae(idSalsamentum, resFluida);
            _estApplicandum = true;
        }

        public async Task ServareAsync(CancellationToken ct) {
            if (!_estApplicandum) return;
            await _arcessitor.ServareAsync(ct);
            _estApplicandum = false;
        }
    }
}