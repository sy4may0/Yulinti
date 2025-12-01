using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class FasciculusOstiorumInput {
        private readonly MinisteriumInputMotus _miInputMotus;

        private readonly IOstiumInputMotusLegibile _osInputMotusLeg;

        public FasciculusOstiorumInput(IVasculumMinisteriumInput vasculumInput) {
            _miInputMotus = new MinisteriumInputMotus(vasculumInput.AnchoraInput);
            _osInputMotusLeg = new OstiumInputMotusLegibile(_miInputMotus);
        }

        public IOstiumInputMotusLegibile MotusLeg => _osInputMotusLeg;
    }
}



