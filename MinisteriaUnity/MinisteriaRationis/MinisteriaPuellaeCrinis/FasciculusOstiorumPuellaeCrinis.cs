using Yulinti.MinisteriaUnity.Anchora;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class FasciculusOstiorumPuellaeCrinis {
        private readonly IOstiumPuellaeCrinisAdiunctionisMutabile _osPuellaeCrinisAdiunctionisMut;

        public FasciculusOstiorumPuellaeCrinis(AnchoraPuellaeCrinis[] anchora, AnchoraPuellae anchoraPuellae) {
            _osPuellaeCrinisAdiunctionisMut = new OstiumPuellaeCrinisAdiunctionisMutabile(
                new MinisteriumPuellaeCrinisAdiunctionis(anchora, anchoraPuellae)
            );
        }

        public IOstiumPuellaeCrinisAdiunctionisMutabile OsPuellaeCrinisAdiunctionisMut => _osPuellaeCrinisAdiunctionisMut;
    }
}
