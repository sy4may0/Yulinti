using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumCivisLegibile : IOstiumCivisLegibile {
        private readonly MinisteriumCivis _miCivis;

        public OstiumCivisLegibile(MinisteriumCivis miCivis) {
            _miCivis = miCivis;
        }

        public int[] IDs => _miCivis.IDs;
        public int Longitudo => _miCivis.Longitudo;
        public int LongitudoActivum => _miCivis.LongitudoActivum;
        public int LegoIDIntactus() => _miCivis.LegoIDIntactus();
        public bool EstActivum(int id) {
            if (id < 0 || id >= _miCivis.Longitudo) return false;
            return _miCivis.EstActivum(id);
        }
    }
}