using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesPuellaeCrinis {
        private readonly IOstiumPuellaeCrinisAdiunctionisMutabile _osPuellaeCrinisAdiunctionisMut;

        // VContainer注入
        public MilesPuellaeCrinis(
            IOstiumPuellaeCrinisAdiunctionisMutabile osPuellaeCrinisAdiunctionisMut
        ) {
            _osPuellaeCrinisAdiunctionisMut = osPuellaeCrinisAdiunctionisMut;
            // Default Hair
            _osPuellaeCrinisAdiunctionisMut.Muto(IDPuellaeCrinis.Resiliens);
        }

        public void MutareComam(IDPuellaeCrinis idCrinis) {
            _osPuellaeCrinisAdiunctionisMut.Muto(idCrinis);
        }

        public void AscendeCalve() {
            _osPuellaeCrinisAdiunctionisMut.Deleto();
        }
    }
}