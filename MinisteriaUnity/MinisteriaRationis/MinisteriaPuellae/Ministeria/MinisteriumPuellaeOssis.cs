using UnityEngine;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumPuellaeOssis {
        private readonly TabulaPuellaeOssium _tabulaOssium;

        public MinisteriumPuellaeOssis(IAnchoraPuellae anchoraPuellae) {
            _tabulaOssium = new TabulaPuellaeOssium(anchoraPuellae);
        }

        public Vector3 LegoPositionem(IDPuellaeOssis idOssis) => _tabulaOssium.Lego(idOssis).position;
        public Quaternion LegoRotationem(IDPuellaeOssis idOssis) => _tabulaOssium.Lego(idOssis).rotation;
        public Vector3 LegoScalam(IDPuellaeOssis idOssis) => _tabulaOssium.Lego(idOssis).localScale;

        public void PonoPositionem(IDPuellaeOssis idOssis, Vector3 positio) {
            Transform os = _tabulaOssium.Lego(idOssis);
            os.position = positio;
        }
        public void PonoRotationem(IDPuellaeOssis idOssis, Quaternion rotatio) {
            Transform os = _tabulaOssium.Lego(idOssis);
            os.rotation = rotatio;
        }
        public void PonoScalam(IDPuellaeOssis idOssis, Vector3 scala) {
            Transform os = _tabulaOssium.Lego(idOssis);
            os.localScale = scala;
        }
    }
}



