using UnityEngine;
using UnityEngine.InputSystem;
using Yulinti.CharacterControlUtils;

namespace Yulinti.CharacterControlUtils {
    [System.Serializable]
    public class IdleState : IMoveState {
        [Header("IdleState移動制御")]
        [SerializeField] private float _accelerationToTargetSpeed = 10f;
        [SerializeField] private float _decelerationToTargetSpeed = 14f;

        public void Enter(MoveContext context) {}
        public void Exit(MoveContext context) {}
        public MoveOutput Tick(MoveContext context, float deltaTime) {
            float smoothTime = context.CharacterControlUtil.CalculateSpeedSmoothTime(
                0f, context.CurrentSpeed,
                _accelerationToTargetSpeed, _decelerationToTargetSpeed,
                context.MaxSmoothTime, context.MinSmoothTime
            );
            return new MoveOutput {
                DesiredSpeed = 0f,
                DesiredDirection = Quaternion.Euler(0, context.CurrentYaw, 0),
                SpeedSmoothTime = smoothTime
            };
        }

        public IMoveState TryTransition(MoveContext context) {
            if (context.MoveAction.sqrMagnitude > context.MoveInputDeadZoneSq) {
                return context.WalkState;
            }
            return null;
        }
    }
}