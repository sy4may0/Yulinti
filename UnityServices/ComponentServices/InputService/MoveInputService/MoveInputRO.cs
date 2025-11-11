using Yulinti.MinisteriaNuclei.ModeratorErrorum;
using Yulinti.InstrumentaMinisterii;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class MoveInputRO : IMoveInputQuery {
        private readonly MoveInputService _moveInputService;

        public MoveInputRO(MoveInputService moveInputService) {
            if (moveInputService == null) {
                ModeratorErrorum.Fatal("コンポーネントサービス(MoveInputRO)のMoveInputServiceがnullです。");
            }
            _moveInputService = moveInputService;
        }

        public System.Numerics.Vector2 Move => InterpressNumericus.ToNumerics(_moveInputService.Move);
        public bool Sprint => _moveInputService.Sprint;
        public bool Crouch => _moveInputService.Crouch;
    }
}