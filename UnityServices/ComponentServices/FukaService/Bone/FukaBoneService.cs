using UnityEngine;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.MinisteriaNuclei.ModeratorErrorum;
using Yulinti.UnityServices.ServiceContracts;
using Yulinti.UnityServices.ComponentServices.FukaService.Bone.Internal;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class FukaBoneService {
        private readonly FukaBoneMap _boneMap;

        public FukaBoneService(IFukaBoneConfig boneConfig) {
            if (boneConfig == null) {
                ModeratorErrorum.Fatal("コンポーネントサービス(FukaBoneService)のBoneConfigがnullです。");
            }
            _boneMap = new FukaBoneMap(boneConfig);
        }

        public Vector3 GetBonePosition(BoneID boneID) => _boneMap.Get(boneID).position;
        public Quaternion GetBoneRotation(BoneID boneID) => _boneMap.Get(boneID).rotation;
        public Vector3 GetBoneScale(BoneID boneID) => _boneMap.Get(boneID).localScale;

        public void SetBonePosition(BoneID boneID, Vector3 position) => _boneMap.Get(boneID).position = position;
        public void SetBoneRotation(BoneID boneID, Quaternion rotation) => _boneMap.Get(boneID).rotation = rotation;
        public void SetBoneScale(BoneID boneID, Vector3 scale) => _boneMap.Get(boneID).localScale = scale;
    }
}