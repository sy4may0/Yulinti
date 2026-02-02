using Yulinti.Dux.ContractusDucis;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Yulinti.Deus {
    internal sealed class TurrisSalsamenti : ITurrisSalsamenti {
        private readonly ThesaurusSalsamenti _thesaurusSalsamenti;
        private readonly Arcessitor _arcessitor;

        private IOstiumSalsamenti _salsamentumActualis;

        // Dirtyフラグ。
        private bool _estApplicandum;
        // 保存中フラグ
        private bool _estServando;

        // catch必要だけどコンストラクタだから落としていい。
        public TurrisSalsamenti() {
            _thesaurusSalsamenti = new ThesaurusSalsamenti();
            IScriba scriba = new ScribaOrdinarius();
            _arcessitor = new Arcessitor(scriba, _thesaurusSalsamenti);
            _estApplicandum = false;
            _estServando = false;
        }

        // catch不要
        public int Longitudo => _thesaurusSalsamenti.Longitudo;
        // catch不要
        public long Revisio => _thesaurusSalsamenti.Revisio;

        // catch不要
        public int IDSalsamentumActualis => EstSeligere() ? _salsamentumActualis.IdDatumServatum : -1;
        // catch不要
        public IOstiumSalsamenti SalsamentumActualis => EstSeligere() ? _salsamentumActualis : null;

        // catch不要
        public bool Creare() {
            int idSalsamentum = _thesaurusSalsamenti.Creare();
            if (idSalsamentum == -1) return false;
            _salsamentumActualis = _thesaurusSalsamenti.Lego(idSalsamentum);
            _estApplicandum = true;
            return true;
        }

        // catch不要
        private bool EstSeligere() {
            if (_salsamentumActualis == null) return false;
            return true;
        }

        // catch不要
        public bool Seligere(int idSalsamentum) {
            _salsamentumActualis = _thesaurusSalsamenti.Lego(idSalsamentum);
            return true;
        }

        // catch不要
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

        // catch不要
        public IOstiumSalsamenti Lego(int idSalsamentum) {
            return _thesaurusSalsamenti.Lego(idSalsamentum);
        }

        // catch不要
        public void Liberare(int idSalsamentum) {
            _thesaurusSalsamenti.Liberare(idSalsamentum);
            _estApplicandum = true;
        }

        // catch不要
        public void Renovere(int idSalsamentum) {
            _thesaurusSalsamenti.Renovere(idSalsamentum);
            _estApplicandum = true;
        }

        // catch不要
        public void Renovere(IResFluidaPuellaePersonaeLegibile resFluida) {
            if (!EstSeligere()) return;
            int idSalsamentum = _salsamentumActualis.IdDatumServatum;
            _thesaurusSalsamenti.RenoverePuellaePersonae(idSalsamentum, resFluida);
            _estApplicandum = true;
        }

        // catch必要
        public async Task ServareAsync(CancellationToken ct) {
            if (!_estApplicandum) return;

            if (_estServando) throw new InvalidOperationException("セーブデータの保存中です。");

            _estApplicandum = false;
            _estServando = true;
            try {
            // 実行前にフラグを落とす。失敗時はリカバリしない。
                await _arcessitor.ServareAsync(ct);
            } catch {
                throw;
            } finally {
                _estServando = false;
            }
        }
    }
}