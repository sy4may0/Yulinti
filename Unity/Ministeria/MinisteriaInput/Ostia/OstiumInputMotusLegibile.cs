using Yulinti.Unity.Ministeria;
using Yulinti.Nucleus;
using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Unity.Ministeria {
    internal sealed class OstiumInputMotusLegibile : IOstiumInputMotusLegibile {
        private readonly MinisteriumInputMotus _miInputMotus;

        public OstiumInputMotusLegibile(MinisteriumInputMotus miInputMotus) {
            if (miInputMotus == null) {
                Carnifex.Intermissio(LogTextus.OstiumInputMotusLegibile_OSTIUMINPUTMOTUSLEGIBILE_INSTANCE_NULL);
            }
            _miInputMotus = miInputMotus;
        }

        public System.Numerics.Vector2 LegoMotus => InterpressNumericus.ToNumerics(_miInputMotus.LegoMotus);
        public bool LegoCursus => _miInputMotus.LegoCursus;
        public bool LegoIncumbo => _miInputMotus.LegoIncumbo;
    }
}


