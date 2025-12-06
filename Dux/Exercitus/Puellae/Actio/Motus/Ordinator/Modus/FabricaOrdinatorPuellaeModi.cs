using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal static class FabricaOrdinatorPuellaeModi {
        public static IOrdinatorPuellaeModi Creare(
            IDPuellaeModiMotus modusMotus,
            IContentumOrdinatorPuellaeModi contentum
        ) {
            switch (modusMotus) {
                case IDPuellaeModiMotus.ModusMotus:
                    return new OrdinatorPuellaeModiMotus(contentum);
                case IDPuellaeModiMotus.ModusQuietus:
                    return new OrdinatorPuellaeModiQuietes(contentum);
                default:
                    return new OrdinatorPuellaeModiQuietes(contentum);
            }
        }
    }
}