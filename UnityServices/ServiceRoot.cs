using Yulinti.MinisteriaNuclei.ModeratorErrorum;
using Yulinti.MinisteriaNuclei.MinisteriumTemporis;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.UnityServices.ComponentServices;
using Yulinti.UnityServices.Internal.LifeCycle;


namespace Yulinti.UnityServices {
    public sealed class ServiceRoot : IServiceTickable, IServiceFixedTickable {
        private readonly MinisteriumTemporis _frameService;
        private readonly CameraServiceRoot _cameraServiceRoot;
        private readonly InputServiceRoot _inputServiceRoot;
        private readonly FukaServiceRoot _fukaServiceRoot;

        private readonly OstiumTemporisLegibile _frameRO;
        private readonly OstiumTemporisMutabile _frameRW;

        public ServiceRoot(ServiceRootConfig serviceConfig) {
            if (serviceConfig == null) {
                ModeratorErrorum.Fatal("サービス(Service)のServiceConfigがnullです。");
            }

            _frameService = new MinisteriumTemporis();
            _cameraServiceRoot = new CameraServiceRoot(serviceConfig.CameraConfig);
            _inputServiceRoot = new InputServiceRoot(serviceConfig.InputConfig);
            _fukaServiceRoot = new FukaServiceRoot(serviceConfig.FukaConfig);

            _frameRO = new OstiumTemporisLegibile(_frameService);
            _frameRW = new OstiumTemporisMutabile(_frameService);
        }

        public OstiumTemporisLegibile FrameRO => _frameRO;
        public OstiumTemporisMutabile FrameRW => _frameRW;

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

        public void LateTick(float deltaTime) {
            _fukaServiceRoot.LateTick(deltaTime);
        }
    }


}


