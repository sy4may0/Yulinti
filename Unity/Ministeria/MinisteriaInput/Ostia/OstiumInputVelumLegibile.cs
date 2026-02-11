using Yulinti.Unity.Ministeria;
using Yulinti.Nucleus;
using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Unity.Ministeria {
    internal sealed class OstiumInputVelumLegibile : IOstiumInputVelumLegibile {
        private readonly MinisteriumInputVelum _miInputVelum;

        public OstiumInputVelumLegibile(MinisteriumInputVelum miInputVelum) {
            if (miInputVelum == null) {
                Carnifex.Intermissio(LogTextus.OstiumInputVelumLegibile_OSTIUMINPUTVELUMLEGIBILE_INSTANCE_NULL);
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