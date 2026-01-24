using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumPuellaeCrinisAdiunctionisMutabile : IOstiumPuellaeCrinisAdiunctionisMutabile {
        private readonly MinisteriumPuellaeCrinisAdiunctionis _miPuellaeCrinisAdiunctionis;

        public OstiumPuellaeCrinisAdiunctionisMutabile(MinisteriumPuellaeCrinisAdiunctionis miPuellaeCrinisAdiunctionis) {
            if (miPuellaeCrinisAdiunctionis == null) {
                Errorum.Fatal(IDErrorum.OSTIUMPUELLAECRINISADIUNCTIONISMUTABILE_INSTANCE_NULL);
            }
            _miPuellaeCrinisAdiunctionis = miPuellaeCrinisAdiunctionis;
        }

        public void Muto(IDPuellaeCrinis idCrinis) {
            _miPuellaeCrinisAdiunctionis.Muto(idCrinis);
        }
        public void Deleto() {
            _miPuellaeCrinisAdiunctionis.Deleto();
        }
    }
}


