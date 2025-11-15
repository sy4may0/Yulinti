using UnityEngine;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.ContractusMinisterii.Puellae;
using Yulinti.MinisteriaUnity.MinisteriaRationis.MinisteriaPuellae.Os.Interna;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class MinisteriumPuellaeOssis {
        private readonly TabulaOssium _tabulaOssium;

        public MinisteriumPuellaeOssis(IFukaBoneConfig boneConfig) {
            if (boneConfig == null) {
                ModeratorErrorum.Fatal("MinisteriumPuellaeOssisのBoneConfigがnullです。");
            }
            _tabulaOssium = new TabulaOssium(boneConfig);
        }

        public Vector3 LegoPositionem(IDPuellaeOssis idOssis) => _tabulaOssium.Lego(idOssis).position;
        public Quaternion LegoRotationem(IDPuellaeOssis idOssis) => _tabulaOssium.Lego(idOssis).rotation;
        public Vector3 LegoScalam(IDPuellaeOssis idOssis) => _tabulaOssium.Lego(idOssis).localScale;

        public void PonoPositionem(IDPuellaeOssis idOssis, Vector3 positio) => _tabulaOssium.PonoPositionem(idOssis, positio);
        public void PonoRotationem(IDPuellaeOssis idOssis, Quaternion rotatio) => _tabulaOssium.PonoRotationem(idOssis, rotatio);
        public void PonoScalam(IDPuellaeOssis idOssis, Vector3 scala) => _tabulaOssium.PonoScalam(idOssis, scala);
    }
}