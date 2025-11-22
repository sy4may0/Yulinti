using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class FasciculusOstiorumPuellaeCrinis {
        private readonly IOstiumPuellaeCrinisAdiunctionisMutabile _osPuellaeCrinisAdiunctionisMut;

        public FasciculusOstiorumPuellaeCrinis(FasciculusConfigurationumPuellaeCrinis configurationum) {
            _osPuellaeCrinisAdiunctionisMut = new OstiumPuellaeCrinisAdiunctionisMutabile(
                new MinisteriumPuellaeCrinisAdiunctionis(configurationum)
            );
        }

        public IOstiumPuellaeCrinisAdiunctionisMutabile OsPuellaeCrinisAdiunctionisMut => _osPuellaeCrinisAdiunctionisMut;
    }
}