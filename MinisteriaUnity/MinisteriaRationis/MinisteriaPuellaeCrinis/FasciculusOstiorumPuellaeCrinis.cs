
using Yulinti.MinisteriaUnity.ContractusMinisterii;
namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class FasciculusOstiorumPuellaeCrinis {
        private readonly IOstiumPuellaeCrinisAdiunctionisMutabile _osPuellaeCrinisAdiunctionisMut;

        public FasciculusOstiorumPuellaeCrinis(IAnchoraPuellaeCrinis[] anchora, IAnchoraPuellae anchoraPuellae) {
            _osPuellaeCrinisAdiunctionisMut = new OstiumPuellaeCrinisAdiunctionisMutabile(
                new MinisteriumPuellaeCrinisAdiunctionis(anchora, anchoraPuellae)
            );
        }

        public IOstiumPuellaeCrinisAdiunctionisMutabile OsPuellaeCrinisAdiunctionisMut => _osPuellaeCrinisAdiunctionisMut;
    }
}


