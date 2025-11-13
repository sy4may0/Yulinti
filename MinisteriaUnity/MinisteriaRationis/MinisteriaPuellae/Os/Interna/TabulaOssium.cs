using UnityEngine;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis.MinisteriaPuellae.Os.Interna {
    public sealed class TabulaOssium {
        private readonly Transform[] _ossa;

        public TabulaOssium(IFukaBoneConfig boneConfig) {
            int longitudo = (int)BoneID.Count;
            _ossa = new Transform[longitudo];
            Transform rigRoot = boneConfig.RigRoot;

            _ossa[(int)BoneID.Root] = rigRoot.Find(boneConfig.RootPath);
            _ossa[(int)BoneID.Hips] = rigRoot.Find(boneConfig.HipsPath);
            _ossa[(int)BoneID.RightUpperLeg] = rigRoot.Find(boneConfig.RightUpperLegPath);
            _ossa[(int)BoneID.RightLowerLeg] = rigRoot.Find(boneConfig.RightLowerLegPath);
            _ossa[(int)BoneID.RightFoot] = rigRoot.Find(boneConfig.RightFootPath);
            _ossa[(int)BoneID.LeftUpperLeg] = rigRoot.Find(boneConfig.LeftUpperLegPath);
            _ossa[(int)BoneID.LeftLowerLeg] = rigRoot.Find(boneConfig.LeftLowerLegPath);
            _ossa[(int)BoneID.LeftFoot] = rigRoot.Find(boneConfig.LeftFootPath);
            _ossa[(int)BoneID.RightX150pin] = rigRoot.Find(boneConfig.RightX150pinPath);
            _ossa[(int)BoneID.RightY90pin] = rigRoot.Find(boneConfig.RightY90pinPath);
            _ossa[(int)BoneID.LeftX150pin] = rigRoot.Find(boneConfig.LeftX150pinPath);
            _ossa[(int)BoneID.LeftY90pin] = rigRoot.Find(boneConfig.LeftY90pinPath);

            for (int i = 0; i < longitudo; i++) {
                if (_ossa[i] == null) {
                    ModeratorErrorum.Fatal($"BoneID {(BoneID)i} が見つかりません。IFukaBoneConfigのパス設定を確認してください。");
                }
            }
        }

        public Transform Lego(BoneID boneid) => _ossa[(int)boneid];
        public void PonoPositionem(
            BoneID boneID, Vector3 positio
        ) => _ossa[(int)boneID].position = positio;
        public void PonoRotationem(
            BoneID boneID, Quaternion rotatio
        ) => _ossa[(int)boneID].rotation = rotatio;
        public void PonoScalam(
            BoneID boneID, Vector3 scala
        ) => _ossa[(int)boneID].localScale = scala;
    }
}