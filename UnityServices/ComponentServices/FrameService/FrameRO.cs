using Yulinti.UnityServices.CoreServices;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class FrameRO : IFrameQuery {
        private readonly FrameService _frameService;

        public FrameRO(FrameService frameService) {
            if (frameService == null) {
                ErrorHandleService.Fatal("コンポーネントサービス(FrameService)のインスタンスがnullです。");
            }
            _frameService = frameService;
        }

        public float DeltaTime => _frameService.DeltaTime;
        public float FixedDeltaTime => _frameService.FixedDeltaTime;
    }
}