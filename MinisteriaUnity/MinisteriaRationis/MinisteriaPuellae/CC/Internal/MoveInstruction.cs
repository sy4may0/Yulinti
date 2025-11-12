using UnityEngine;

namespace Yulinti.UnityServices.ComponentServices.FukaService.CC.Internal {
    public sealed class MoveInstruction {
        private Vector3 _additionalMove;
        private float _additionalYawDeg;

        public MoveInstruction() {
            _additionalMove = Vector3.zero;
            _additionalYawDeg = 0f;
        }

        public void AddMove(Vector3 move) {
            _additionalMove += move;
        }

        public void AddYawDeg(float yawDeg) {
            _additionalYawDeg += yawDeg;
        }

        public void Reset() {
            _additionalMove = Vector3.zero;
            _additionalYawDeg = 0f;
        }

        public Vector3 AdditionalMove => _additionalMove;
        public float AdditionalYawDeg => _additionalYawDeg;
    }
}