using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class MinisteriumCivisAnimationes : IMinisteriumPulsabilis {
        private readonly TabulaCivis _tabulaCivis;
        private readonly TabulaCivisAnimationum _tabulaAnimationum;
        private readonly LusorAnimationis[,] _lusoris;
        private readonly bool[] _estActivum;
        private readonly int _longitudoStratum;

        public MinisteriumCivisAnimationes(TabulaCivis tabulaCivis, IConfiguratioCivisAnimationum config) {
            _tabulaCivis = tabulaCivis;
            int longitudo = _tabulaCivis.Longitudo;
            _longitudoStratum = System.Enum.GetValues(typeof(IDCivisAnimationisStratum)).Length;
            _lusoris = new LusorAnimationis[longitudo, _longitudoStratum];
            _estActivum = new bool[longitudo];
            _tabulaAnimationum = new TabulaCivisAnimationum(config.Animationes);

            for (int id = 0; id < longitudo; id++) {
                _tabulaCivis.PonoAdInitium(id, (id) => Initio(id));
            }
        }

        private void Initio(int id) {
            IAnchoraCivis anchora;
            if (!_tabulaCivis.ConareLego(id, out anchora)) {
                Carnifex.Intermissio(LogTextus.MinisteriumCivisAnimationes_MINISTERIUICIVISANIMATIONES_ANCHORA_NULL);
                return;
            }
            for (int i = 0; i < _longitudoStratum; i++) {
                if (i == (int)IDCivisAnimationisStratum.Fundamentum) {
                    // Fundamentum層は永続化する。
                    _lusoris[id, i] = new LusorAnimationis(anchora.Animancer, i, true);
                } else {
                    _lusoris[id, i] = new LusorAnimationis(anchora.Animancer, i);
                }
            }
            _estActivum[id] = true;
        }

        public int[] IDs => _tabulaCivis.IDs;
        public int Longitudo => _tabulaCivis.Longitudo;

        public bool EstActivum(int id) {
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return false;
            if (!anchora.EstActivum) return false;
            return _estActivum[id];
        }

        public bool EstExhibens(int id, IDCivisAnimationisStratum stratum) {
            if (!ConareLegoLusor(id, stratum, out LusorAnimationis lusor)) return false;
            return lusor.StatusLusoris != IDStatusLusoris.Nihil;
        }

        public bool EstDesinens(int id, IDCivisAnimationisStratum stratum) {
            if (!ConareLegoLusor(id, stratum, out LusorAnimationis lusor)) return false;
            return lusor.StatusLusoris == IDStatusLusoris.Nihil;
        }

        public bool EstExhibensIterans(int id, IDCivisAnimationisStratum stratum) {
            if (!ConareLegoLusor(id, stratum, out LusorAnimationis lusor)) return false;
            return lusor.StatusLusoris == IDStatusLusoris.Iterans;
        }

        public void Exhibere(int id, IDCivisAnimationisStratum stratum, IDCivisAnimationis idAnimationis) {
            if (!ConareLegoLusor(id, stratum, out LusorAnimationis lusor)) return;
            // Nihil はアニメーション操作を行わない。
            if (idAnimationis == IDCivisAnimationis.Nihil) return;
            // Desinere はアニメーション終了を指定。
            if (idAnimationis == IDCivisAnimationis.Desinere) {
                Desinere(id, stratum);
                return;
            }

            OnusAnimationis onusAnimationis = _tabulaAnimationum.Legere(idAnimationis);
            if (onusAnimationis == null) {
                Notarius.Memorare(LogTextus.TabulaCivisAnimationumContinuata_TABULACIVISANIMATIONUMCONTINUATA_CONFIG_NOT_FOUND);
                return;
            }
            lusor.Exhibere(onusAnimationis);
        }

        public void Desinere(int id, IDCivisAnimationisStratum stratum) {
            if (!ConareLegoLusor(id, stratum, out LusorAnimationis lusor)) return;
            lusor.Desinere();
        }

        public void InjicereVelocitatem(int id, float vel) {
            if (!EstActivum(id)) return;
            for (int i = 0; i < _longitudoStratum; i++) {
                _lusoris[id, i].InjicereVelocitatem(vel);
            }
        }

        public void Purgere(int id, IDCivisAnimationisStratum stratum) {
            if (!ConareLegoLusor(id, stratum, out LusorAnimationis lusor)) return;
            lusor.Purgere();
        }

        public void Pulsus() {
            for (int id = 0; id < _tabulaCivis.Longitudo; id++) {
                if (!EstActivum(id)) continue;
                float tempusFundamenti = _lusoris[id, (int)IDCivisAnimationisStratum.Fundamentum].LegereSimulataneum();
                for (int i = 1; i < _longitudoStratum; i++) {
                    _lusoris[id, i].ContemporareLusor(tempusFundamenti);
                }
            }
        }

        private bool ConareLegoLusor(int id, IDCivisAnimationisStratum stratum, out LusorAnimationis lusor) {
            lusor = null;
            if (!EstActivum(id)) return false;

            int indexusStrati = (int)stratum;
            if (indexusStrati < 0 || indexusStrati >= _longitudoStratum) {
                return false;
            }

            lusor = _lusoris[id, indexusStrati];
            return lusor != null;
        }
    }
}
