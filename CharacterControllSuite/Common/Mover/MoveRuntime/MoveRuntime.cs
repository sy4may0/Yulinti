using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public struct MoveResult {
        public readonly float CurrentSpeedHorizontal;
        public readonly float CurrentSpeedVertical;
        public readonly float CurrentYaw;

        public MoveResult(float currentSpeedHorizontal, float currentSpeedVertical, float currentYaw) {
            CurrentSpeedHorizontal = currentSpeedHorizontal;
            CurrentSpeedVertical = currentSpeedVertical;
            CurrentYaw = currentYaw;
        }
    }

    public class MoveRuntime {
        public float CurrentSpeedHorizontal;
        public float SpeedVelRefHorizontal;
        public float CurrentYaw;
        public float YawVelRef;
        public float CurrentSpeedVertical;
        public float SpeedVelRefVertical;
        public FrameContext FrameContext;
        public bool IsGrounded;

        public MoveRuntime(
            FrameContext frameContext,
            float currentSpeedHorizontal,
            float currentSpeedVertical,
            float currentYaw,
            bool isGrounded
        ) {
            FrameContext = frameContext;
            CurrentSpeedHorizontal = currentSpeedHorizontal;
            CurrentSpeedVertical = currentSpeedVertical;
            CurrentYaw = currentYaw;
            IsGrounded = isGrounded;
            SpeedVelRefHorizontal = 0f;
            SpeedVelRefVertical = 0f;
            YawVelRef = 0f;
        }
    }

    public class MoveRuntimeCommands {
        private readonly MoveRuntime _moveRuntime;
        public MoveRuntimeCommands(MoveRuntime moveRuntime) {
            if (moveRuntime == null) {
                Debug.LogError("MoveRuntime is null");
                return;
            }
            _moveRuntime = moveRuntime;
        }

        public void SetCurrentSpeedHorizontal(float currentSpeedHorizontal) {
            _moveRuntime.CurrentSpeedHorizontal = currentSpeedHorizontal;
        }
        public void SetCurrentSpeedVertical(float currentSpeedVertical) {
            _moveRuntime.CurrentSpeedVertical = currentSpeedVertical;
        }
        public void SetCurrentYaw(float currentYaw) {
            _moveRuntime.CurrentYaw = currentYaw;
        }
        public void SetIsGrounded(bool isGrounded) {
            _moveRuntime.IsGrounded = isGrounded;
        }
        public void PostMove(MoveResult moveResult) {
            _moveRuntime.CurrentSpeedHorizontal = moveResult.CurrentSpeedHorizontal;
            _moveRuntime.CurrentSpeedVertical = moveResult.CurrentSpeedVertical;
            _moveRuntime.CurrentYaw = moveResult.CurrentYaw;
        }
    }

    public class MoveRuntimeReadOnly {
        private readonly MoveRuntime _moveRuntime;
        public MoveRuntimeReadOnly(MoveRuntime moveRuntime) {
            _moveRuntime = moveRuntime;
        }
        public float CurrentSpeedHorizontal => _moveRuntime.CurrentSpeedHorizontal;
        public float CurrentSpeedVertical => _moveRuntime.CurrentSpeedVertical;
        public float CurrentYaw => _moveRuntime.CurrentYaw;
        public bool IsGrounded => _moveRuntime.IsGrounded;
        public float DeltaTime => _moveRuntime.FrameContext.DeltaTime;
        public ref float SpeedVelRefHorizontal => ref _moveRuntime.SpeedVelRefHorizontal;
        public ref float SpeedVelRefVertical => ref _moveRuntime.SpeedVelRefVertical;
        public ref float YawVelRef => ref _moveRuntime.YawVelRef;
    }

}