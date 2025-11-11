using UnityEngine;
using Yulinti.UnityServices.TranslateUtils;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.MinisteriaNuclei.ModeratorErrorum;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class MoveInputService {
        private readonly IMoveInputConfig _moveInputConfig;

        public MoveInputService(IMoveInputConfig moveInputConfig) {
            if (moveInputConfig == null) {
                ModeratorErrorum.Fatal("コンポーネントサービス(MoveInputService)のMoveInputConfigがnullです。");
            }
            _moveInputConfig = moveInputConfig;
        }

        public Vector2 Move => _moveInputConfig.MoveInput?.action?.enabled == true ? _moveInputConfig.MoveInput.action.ReadValue<Vector2>() : Vector2.zero;
        public bool Sprint => _moveInputConfig.SprintInput?.action?.enabled == true && _moveInputConfig.SprintInput.action.IsPressed();
        public bool Crouch => _moveInputConfig.CrouchInput?.action?.enabled == true && _moveInputConfig.CrouchInput.action.IsPressed();
    }
}