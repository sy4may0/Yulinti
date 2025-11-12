using NVec3 = System.Numerics.Vector3;
using NVec2 = System.Numerics.Vector2;
using NQuat = System.Numerics.Quaternion;
using UVec3 = UnityEngine.Vector3;
using UVec2 = UnityEngine.Vector2;
using UQuat = UnityEngine.Quaternion;

namespace Yulinti.Nucleus.InstrumentaMinisterii {
    public static class InterpressNumericus {
        public static NVec3 ToNumerics(UVec3 vector) {
            return new NVec3(vector.x, vector.y, vector.z);
        }
        public static NVec2 ToNumerics(UVec2 vector) {
            return new NVec2(vector.x, vector.y);
        }
        public static NQuat ToNumerics(UQuat quaternion) {
            return new NQuat(quaternion.x, quaternion.y, quaternion.z, quaternion.w);
        }
        public static UVec3 ToUnity(NVec3 vector) {
            return new UVec3(vector.X, vector.Y, vector.Z);
        }
        public static UVec2 ToUnity(NVec2 vector) {
            return new UVec2(vector.X, vector.Y);
        }
        public static UQuat ToUnity(NQuat quaternion) {
            return new UQuat(quaternion.X, quaternion.Y, quaternion.Z, quaternion.W);
        }
    }
}
