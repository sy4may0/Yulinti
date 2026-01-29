using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.Nucleus;
using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumInputVelumLegibile : IOstiumInputVelumLegibile {
        private readonly MinisteriumInputVelum _miInputVelum;

        public OstiumInputVelumLegibile(MinisteriumInputVelum miInputVelum) {
            if (miInputVelum == null) {
                Errorum.Fatal(IDErrorum.OSTIUMINPUTVELUMLEGIBILE_INSTANCE_NULL);
            }
            _miInputVelum = miInputVelum;
        }

        public bool LegoClick => _miInputVelum.LegoClick;
        public bool LegoClickRight => _miInputVelum.LegoClickRight;
        public bool LegoSubmit => _miInputVelum.LegoSubmit;
        public bool LegoCancel => _miInputVelum.LegoCancel;
        public bool LegoNavigate => _miInputVelum.LegoNavigate;
    }
}