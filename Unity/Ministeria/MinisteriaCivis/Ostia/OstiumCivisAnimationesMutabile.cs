using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Unity.Ministeria {
    internal sealed class OstiumCivisAnimationesMutabile : IOstiumCivisAnimationesMutabile {
        private readonly MinisteriumCivisAnimationes _miCivisAnimationes;

        public OstiumCivisAnimationesMutabile(MinisteriumCivisAnimationes miCivisAnimationes) {
            _miCivisAnimationes = miCivisAnimationes;
        }

        public int[] IDs => _miCivisAnimationes.IDs;
        public int Longitudo => _miCivisAnimationes.Longitudo;

        public bool EstExhibens(int id, IDCivisAnimationisStratum stratum) {
            if (id < 0 || id >= _miCivisAnimationes.Longitudo) return false;
            return _miCivisAnimationes.EstExhibens(id, stratum);
        }

        public bool EstDesinens(int id, IDCivisAnimationisStratum stratum) {
            if (id < 0 || id >= _miCivisAnimationes.Longitudo) return false;
            return _miCivisAnimationes.EstDesinens(id, stratum);
        }

        public bool EstExhibensIterans(int id, IDCivisAnimationisStratum stratum) {
            if (id < 0 || id >= _miCivisAnimationes.Longitudo) return false;
            return _miCivisAnimationes.EstExhibensIterans(id, stratum);
        }

        public void Exhibere(int id, IDCivisAnimationisStratum stratum, IDCivisAnimationis idAnimationis) {
            if (id < 0 || id >= _miCivisAnimationes.Longitudo) return;
            _miCivisAnimationes.Exhibere(id, stratum, idAnimationis);
        }

        public void Desinere(int id, IDCivisAnimationisStratum stratum) {
            if (id < 0 || id >= _miCivisAnimationes.Longitudo) return;
            _miCivisAnimationes.Desinere(id, stratum);
        }

        public void InjicereVelocitatem(int id, float vel) {
            if (id < 0 || id >= _miCivisAnimationes.Longitudo) return;
            _miCivisAnimationes.InjicereVelocitatem(id, vel);
        }

        public void Purgere(int id, IDCivisAnimationisStratum stratum) {
            if (id < 0 || id >= _miCivisAnimationes.Longitudo) return;
            _miCivisAnimationes.Purgere(id, stratum);
        }
    }
}
