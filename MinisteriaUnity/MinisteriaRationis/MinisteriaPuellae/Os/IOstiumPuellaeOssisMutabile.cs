using Yulinti.UnityServices.ServiceContracts;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public interface IOstiumPuellaeOssisMutabile {
        void PonoPositionem(BoneID boneID, System.Numerics.Vector3 positio);
        void PonoRotationem(BoneID boneID, System.Numerics.Quaternion rotatio);
        void PonoScalam(BoneID boneID, System.Numerics.Vector3 scala);
    }
}