using Yulinti.UnityServices.CoreServices;
using Yulinti.UnityServices.TranslateUtils;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class MoveInputRO : IMoveInputQuery {
        private readonly MoveInputService _moveInputService;

        public MoveInputRO(MoveInputService moveInputService) {
            if (moveInputService == null) {
                ErrorHandleService.Fatal("コンポーネントサービス(MoveInputRO)のMoveInputServiceがnullです。");
            }
            _moveInputService = moveInputService;
        }

        public System.Numerics.Vector2 Move => NumericsTranslate.ToNumerics(_moveInputService.Move);
        public bool Sprint => _moveInputService.Sprint;
        public bool Crouch => _moveInputService.Crouch;
    }
}