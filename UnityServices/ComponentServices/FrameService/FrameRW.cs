using Yulinti.UnityServices.CoreServices;
using Yulinti.UnityServices.Internal.LifeCycle;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class FrameRW : IFrameCommand, IFrameQuery {
        private readonly FrameService _frameService;

        public FrameRW(FrameService frameService) {
            if (frameService == null) {
                ErrorHandleService.Fatal("コンポーネントサービス(FrameService)のインスタンスがnullです。");
            }
            _frameService = frameService;
        }

        public float DeltaTime => _frameService.DeltaTime;
        public float FixedDeltaTime => _frameService.FixedDeltaTime;

        public void Tick(float deltaTime) {
            _frameService.Tick(deltaTime);
        }

        public void FixedTick(float fixedDeltaTime) {
            _frameService.FixedTick(fixedDeltaTime);
        }
    }
}