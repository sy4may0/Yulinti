using UnityEngine;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
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
