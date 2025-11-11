using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.UnityServices.ComponentServices {
    public interface IFukaBoneCommand {
        void SetBonePosition(BoneID boneID, System.Numerics.Vector3 position);
        void SetBoneRotation(BoneID boneID, System.Numerics.Quaternion rotation);
        void SetBoneScale(BoneID boneID, System.Numerics.Vector3 scale);
    }
}