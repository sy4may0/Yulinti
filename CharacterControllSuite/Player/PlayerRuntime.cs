using UnityEngine;
using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    // DeltaTimeはCommands/ReadOnlyから設定不可にする。
    // これによりOrchestrator以外がDeltaTimeを設定できなくなる。
    // [注意] PlayerRuntimeをOrchestrator以外に渡すな。
    public sealed class PlayerRuntime {
        public float CurrentSpeedHorizontal;
        public float CurrentSpeedVertical;
        public float CurrentYaw;
        public bool IsGrounded;
        public FrameContext FrameContext;
        public StateID CurrentStateID;

        public PlayerRuntime(FrameContext frameContext) {
            CurrentSpeedHorizontal = 0;
            CurrentSpeedVertical = 0;
            CurrentYaw = 0;
            IsGrounded = true;
            CurrentStateID = StateID.None;
            FrameContext = frameContext;
        }
    }

    public sealed class PlayerRuntimeCommands {
        private readonly PlayerRuntime _playerRuntime;
        public PlayerRuntimeCommands(PlayerRuntime playerRuntime) {
            _playerRuntime = playerRuntime;
        }

        public void ApplyMoveRuntime(MoveRuntimeReadOnly moveRuntimeRO) {
            _playerRuntime.CurrentSpeedHorizontal = moveRuntimeRO.CurrentSpeedHorizontal;
            _playerRuntime.CurrentSpeedVertical = moveRuntimeRO.CurrentSpeedVertical;
            _playerRuntime.CurrentYaw = moveRuntimeRO.CurrentYaw;
            _playerRuntime.IsGrounded = moveRuntimeRO.IsGrounded;
        }

        public void ApplyStateID(StateID stateID) {
            _playerRuntime.CurrentStateID = stateID;
        }
    }

    public sealed class PlayerRuntimeReadOnly {
        private readonly PlayerRuntime _playerRuntime;
        public PlayerRuntimeReadOnly(PlayerRuntime playerRuntime) {
            _playerRuntime = playerRuntime;
        }

        public float CurrentSpeedHorizontal => _playerRuntime.CurrentSpeedHorizontal;
        public float CurrentSpeedVertical => _playerRuntime.CurrentSpeedVertical;
        public float CurrentYaw => _playerRuntime.CurrentYaw;
        public bool IsGrounded => _playerRuntime.IsGrounded;
        public StateID CurrentStateID => _playerRuntime.CurrentStateID;
        public float DeltaTime => _playerRuntime.FrameContext.DeltaTime;
    }
}