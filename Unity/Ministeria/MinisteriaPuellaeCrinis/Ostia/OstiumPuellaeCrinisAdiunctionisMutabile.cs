using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Unity.Ministeria {
    internal sealed class OstiumPuellaeCrinisAdiunctionisMutabile : IOstiumPuellaeCrinisAdiunctionisMutabile {
        private readonly MinisteriumPuellaeCrinisAdiunctionis _miPuellaeCrinisAdiunctionis;

        public OstiumPuellaeCrinisAdiunctionisMutabile(MinisteriumPuellaeCrinisAdiunctionis miPuellaeCrinisAdiunctionis) {
            if (miPuellaeCrinisAdiunctionis == null) {
                Carnifex.Intermissio(LogTextus.OstiumPuellaeCrinisAdiunctionisMutabile_OSTIUMPUELLAECRINISADIUNCTIONISMUTABILE_INSTANCE_NULL);
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


