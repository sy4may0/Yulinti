using UnityEngine;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceContracts;
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

        public Vector3 LegoPositionem(BoneID boneID) => _tabulaOssium.Lego(boneID).position;
        public Quaternion LegoRotationem(BoneID boneID) => _tabulaOssium.Lego(boneID).rotation;
        public Vector3 LegoScalam(BoneID boneID) => _tabulaOssium.Lego(boneID).localScale;

        public void PonoPositionem(BoneID boneID, Vector3 positio) => _tabulaOssium.PonoPositionem(boneID, positio);
        public void PonoRotationem(BoneID boneID, Quaternion rotatio) => _tabulaOssium.PonoRotationem(boneID, rotatio);
        public void PonoScalam(BoneID boneID, Vector3 scala) => _tabulaOssium.PonoScalam(boneID, scala);
    }
}