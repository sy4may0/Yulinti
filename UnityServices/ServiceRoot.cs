using Yulinti.UnityServices.CoreServices;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.UnityServices.ComponentServices;
using Yulinti.UnityServices.Internal.LifeCycle;


namespace Yulinti.UnityServices {
    public sealed class ServiceRoot : IServiceTickable, IServiceFixedTickable {
        private readonly FrameService _frameService;
        private readonly CameraServiceRoot _cameraServiceRoot;
        private readonly InputServiceRoot _inputServiceRoot;
        private readonly FukaServiceRoot _fukaServiceRoot;

        private readonly FrameRO _frameRO;
        private readonly FrameRW _frameRW;

        public ServiceRoot(ServiceRootConfig serviceConfig) {
            if (serviceConfig == null) {
                ErrorHandleService.Fatal("サービス(Service)のServiceConfigがnullです。");
            }

            _frameService = new FrameService();
            _cameraServiceRoot = new CameraServiceRoot(serviceConfig.CameraConfig);
            _inputServiceRoot = new InputServiceRoot(serviceConfig.InputConfig);
            _fukaServiceRoot = new FukaServiceRoot(serviceConfig.FukaConfig);

            _frameRO = new FrameRO(_frameService);
            _frameRW = new FrameRW(_frameService);
        }

        public FrameRO FrameRO => _frameRO;
        public FrameRW FrameRW => _frameRW;

        public CameraRO MainCameraRO => _cameraServiceRoot.MainCameraRO;
        public CameraRW MainCameraRW => _cameraServiceRoot.MainCameraRW;

        public MoveInputRO MoveInputRO => _inputServiceRoot.MoveRO;

        public FukaBoneRO FukaBoneRO => _fukaServiceRoot.BoneRO;
        public FukaBoneRW FukaBoneRW => _fukaServiceRoot.BoneRW;
        public FukaCharacterControllerRO FukaCharacterControllerRO => _fukaServiceRoot.CharacterControllerRO;
        public FukaCharacterControllerRW FukaCharacterControllerRW => _fukaServiceRoot.CharacterControllerRW;
        public FukaAnimationRW FukaAnimationRW => _fukaServiceRoot.AnimationRW;
        public FukaHipsSkinnedMeshRendererRO FukaHipsSkinnedMeshRendererRO => _fukaServiceRoot.HipsSMRRO;
        public FukaHipsSkinnedMeshRendererRW FukaHipsSkinnedMeshRendererRW => _fukaServiceRoot.HipsSMRRW;
        public FukaKneeSkinnedMeshRendererRO FukaRightKneeSkinnedMeshRendererRO => _fukaServiceRoot.RightKneeSMRRO;
        public FukaKneeSkinnedMeshRendererRW FukaRightKneeSkinnedMeshRendererRW => _fukaServiceRoot.RightKneeSMRRW;
        public FukaKneeSkinnedMeshRendererRO FukaLeftKneeSkinnedMeshRendererRO => _fukaServiceRoot.LeftKneeSMRRO;
        public FukaKneeSkinnedMeshRendererRW FukaLeftKneeSkinnedMeshRendererRW => _fukaServiceRoot.LeftKneeSMRRW;

        public void Tick(float deltaTime) {
            _frameService.Tick(deltaTime);
            _fukaServiceRoot.Tick(deltaTime);
        }

        public void FixedTick(float fixedDeltaTime) {
            _frameService.FixedTick(fixedDeltaTime);
        }
    }


}


