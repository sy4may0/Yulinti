using Yulinti.Dux.ContractusDucis;
using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Miles {
    internal sealed class Crinis {
        private readonly IOstiumPuellaeCrinisAdiunctionisMutabile _osPuellaeCrinisAdiunctionisMut;

        public Crinis(
            IOstiumPuellaeCrinisAdiunctionisMutabile osPuellaeCrinisAdiunctionisMut
        ) {
            _osPuellaeCrinisAdiunctionisMut = osPuellaeCrinisAdiunctionisMut;
            _osPuellaeCrinisAdiunctionisMut.Muto(IDPuellaeCrinis.Resiliens);
        }
    }
}
