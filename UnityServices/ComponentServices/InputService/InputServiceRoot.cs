using Yulinti.MinisteriaNuclei.ModeratorErrorum;
using Yulinti.UnityServices.ServiceConfig;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class InputServiceRoot {
        private readonly MoveInputService _moveInputService;

        private readonly MoveInputRO _moveInputRO;

        public InputServiceRoot(InputConfig inputConfig) {
            if (inputConfig == null) {
                ModeratorErrorum.Fatal("コンポーネントサービス(InputService)のInputConfigがnullです。");
            }

            _moveInputService = new MoveInputService(inputConfig.MoveInputConfig);
            _moveInputRO = new MoveInputRO(_moveInputService);
        }

        public MoveInputRO MoveRO => _moveInputRO;
    }
}