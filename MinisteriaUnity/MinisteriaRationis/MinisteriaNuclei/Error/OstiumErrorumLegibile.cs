using Yulinti.MinisteriaUnity.Interna;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class OstiumErrorumLegibile : IOstiumErrorumLegibile {
        public void Fatal(string message) {
            ModeratorErrorum.Fatal(message);
        }
    }
}