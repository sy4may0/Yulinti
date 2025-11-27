using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumPuellaeCrinisAdiunctionisMutabile : IOstiumPuellaeCrinisAdiunctionisMutabile {
        private readonly MinisteriumPuellaeCrinisAdiunctionis _miPuellaeCrinisAdiunctionis;

        public OstiumPuellaeCrinisAdiunctionisMutabile(MinisteriumPuellaeCrinisAdiunctionis miPuellaeCrinisAdiunctionis) {
            if (miPuellaeCrinisAdiunctionis == null) {
                Errorum.Fatal(IDErrorum.OSTIUMPUELLAECRINISADIUNCTIONISMUTABILE_INSTANCE_NULL);
            }
            _miPuellaeCrinisAdiunctionis = miPuellaeCrinisAdiunctionis;
        }

        public void Manifestatio(IDPuellaeCrinis idCrinis) {
            _miPuellaeCrinisAdiunctionis.Manifestatio(idCrinis);
        }
        public void Deletio() {
            _miPuellaeCrinisAdiunctionis.Deletio();
        }
    }
}
