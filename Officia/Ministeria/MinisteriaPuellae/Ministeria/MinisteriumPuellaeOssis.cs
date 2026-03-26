using UnityEngine;
using Yulinti.Officia.Ministeria;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class MinisteriumPuellaeOssis {
        private readonly TabulaPuellaeOssium _tabulaOssium;

        public MinisteriumPuellaeOssis(IAnchoraPuellae anchoraPuellae) {
            _tabulaOssium = new TabulaPuellaeOssium(anchoraPuellae);
        }

        public Vector3 LegoPositionem(IDPuellaeOssis idOssis) => _tabulaOssium.Lego(idOssis).position;
        public Quaternion LegoRotationem(IDPuellaeOssis idOssis) => _tabulaOssium.Lego(idOssis).rotation;
        public Vector3 LegoMagnitudonem(IDPuellaeOssis idOssis) => _tabulaOssium.Lego(idOssis).localScale;

        public void PonoPositionem(IDPuellaeOssis idOssis, Vector3 positio) {
            Transform os = _tabulaOssium.Lego(idOssis);
            os.position = positio;
        }
        public void PonoRotationem(IDPuellaeOssis idOssis, Quaternion rotatio) {
            Transform os = _tabulaOssium.Lego(idOssis);
            os.rotation = rotatio;
        }
        public void PonoMagnitudonem(IDPuellaeOssis idOssis, Vector3 magnitudo) {
            Transform os = _tabulaOssium.Lego(idOssis);
            os.localScale = magnitudo;
        }
    }
}



