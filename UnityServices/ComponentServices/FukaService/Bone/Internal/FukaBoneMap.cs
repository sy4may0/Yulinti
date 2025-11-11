using UnityEngine;
using Yulinti.MinisteriaNuclei.ModeratorErrorum;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.UnityServices.ComponentServices.FukaService.Bone.Internal {
    public sealed class FukaBoneMap {
        private readonly Transform[] _bones;

        public FukaBoneMap(IFukaBoneConfig boneConfig) {
            int length = (int)BoneID.Count;
            _bones = new Transform[length];
            Transform rigRoot = boneConfig.RigRoot;

            _bones[(int)BoneID.Root] = rigRoot.Find(boneConfig.RootPath);
            _bones[(int)BoneID.Hips] = rigRoot.Find(boneConfig.HipsPath);
            _bones[(int)BoneID.RightUpperLeg] = rigRoot.Find(boneConfig.RightUpperLegPath);
            _bones[(int)BoneID.RightLowerLeg] = rigRoot.Find(boneConfig.RightLowerLegPath);
            _bones[(int)BoneID.RightFoot] = rigRoot.Find(boneConfig.RightFootPath);
            _bones[(int)BoneID.LeftUpperLeg] = rigRoot.Find(boneConfig.LeftUpperLegPath);
            _bones[(int)BoneID.LeftLowerLeg] = rigRoot.Find(boneConfig.LeftLowerLegPath);
            _bones[(int)BoneID.LeftFoot] = rigRoot.Find(boneConfig.LeftFootPath);
            _bones[(int)BoneID.RightX150pin] = rigRoot.Find(boneConfig.RightX150pinPath);
            _bones[(int)BoneID.RightY90pin] = rigRoot.Find(boneConfig.RightY90pinPath);
            _bones[(int)BoneID.LeftX150pin] = rigRoot.Find(boneConfig.LeftX150pinPath);
            _bones[(int)BoneID.LeftY90pin] = rigRoot.Find(boneConfig.LeftY90pinPath);

            for (int i = 0; i < length; i++) {
                if (_bones[i] == null) {
                    ModeratorErrorum.Fatal($"BoneID {(BoneID)i} が見つかりません。IFukaBoneConfigのパス設定を確認してください。");
                }
            }
        }

        public Transform Get(BoneID boneid) => _bones[(int)boneid];
    }
}