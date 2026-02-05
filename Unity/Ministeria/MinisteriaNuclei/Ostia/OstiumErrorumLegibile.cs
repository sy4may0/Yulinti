using Yulinti.Unity.Ministeria;
using Yulinti.Nucleus;
using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Unity.Ministeria {
    internal sealed class OstiumErrorumLegibile : IOstiumErrorumLegibile {
        public void Fatal(IDErrorum error) {
            Errorum.Fatal(error);
        }
    }
}


