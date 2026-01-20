using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumPunctumViaeMutabile : IOstiumPunctumViaeMutabile {
        private readonly MinisteriumPunctumViae _miPunctumViae;

        public OstiumPunctumViaeMutabile(MinisteriumPunctumViae miPunctumViae) {
            _miPunctumViae = miPunctumViae;
        }

        public void Activare(int id) {
            _miPunctumViae.Activare(id);
        }

        public void Deactivare(int id) {
            _miPunctumViae.Deactivare(id);
        }
    }
}