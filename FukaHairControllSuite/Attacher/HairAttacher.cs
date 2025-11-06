using UnityEngine;

namespace Yulinti.FukaHairControllSuite {
    public class HairAttacher {
        private Transform headBone;
        private Transform hairRoot;

        public HairAttacher(HairConfig config) {
            headBone = config.HeadBone;
            hairRoot = config.HairRoot;
        }

        public void Initialize() {
            if (headBone == null || hairRoot == null) {
                return;
            }

            hairRoot.SetParent(headBone);
            hairRoot.localPosition = Vector3.zero;
            hairRoot.localRotation = Quaternion.identity;
        }
    }
}
