using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public interface IOstiumPuellaeOssisLegibile {
        System.Numerics.Vector3 LegoPositionem(BoneID boneID);
        System.Numerics.Quaternion LegoRotationem(BoneID boneID);
        System.Numerics.Vector3 LegoScalam(BoneID boneID);
    }
}