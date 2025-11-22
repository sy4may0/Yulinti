using Yulinti.MinisteriaUnity.MinisteriaRationis;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumErrorumLegibile : IOstiumErrorumLegibile {
        public void Fatal(string message) {
            ModeratorErrorum.Fatal(message);
        }
    }
}