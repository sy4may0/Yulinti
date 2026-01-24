using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.Nucleus;
using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumErrorumLegibile : IOstiumErrorumLegibile {
        public void Fatal(IDErrorum error) {
            Errorum.Fatal(error);
        }
    }
}


