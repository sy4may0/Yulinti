using UnityEngine;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumPuellaeOssis {
        private readonly TabulaPuellaeOssium _tabulaOssium;

        public MinisteriumPuellaeOssis(IConfiguratioPuellaeOssis config) {
            if (config == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeOssisのConfiguratioPuellaeOssisがnullです。");
            }
            _tabulaOssium = new TabulaPuellaeOssium(config);
        }

        public Vector3 LegoPositionem(IDPuellaeOssis idOssis) => _tabulaOssium.Lego(idOssis).position;
        public Quaternion LegoRotationem(IDPuellaeOssis idOssis) => _tabulaOssium.Lego(idOssis).rotation;
        public Vector3 LegoScalam(IDPuellaeOssis idOssis) => _tabulaOssium.Lego(idOssis).localScale;

        public void PonoPositionem(IDPuellaeOssis idOssis, Vector3 positio) => _tabulaOssium.PonoPositionem(idOssis, positio);
        public void PonoRotationem(IDPuellaeOssis idOssis, Quaternion rotatio) => _tabulaOssium.PonoRotationem(idOssis, rotatio);
        public void PonoScalam(IDPuellaeOssis idOssis, Vector3 scala) => _tabulaOssium.PonoScalam(idOssis, scala);
    }
}
