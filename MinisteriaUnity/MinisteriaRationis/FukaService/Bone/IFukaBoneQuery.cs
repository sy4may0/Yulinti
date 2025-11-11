using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.UnityServices.ComponentServices {
    public interface IFukaBoneQuery {
        System.Numerics.Vector3 GetBonePosition(BoneID boneID);
        System.Numerics.Quaternion GetBoneRotation(BoneID boneID);
        System.Numerics.Vector3 GetBoneScale(BoneID boneID);
    }
}