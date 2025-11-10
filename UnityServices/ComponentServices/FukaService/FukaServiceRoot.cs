using Yulinti.UnityServices.CoreServices;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.UnityServices.Internal.LifeCycle;

namespace Yulinti.UnityServices.ComponentServices {
    public sealed class FukaServiceRoot : IServiceTickable, IServiceLateTickable {
        private readonly FukaBoneService _fukaBoneService;
        private readonly FukaCharacterControllerService _fukaCharacterControllerService;
        private readonly FukaAnimationService _fukaAnimationService;
        private readonly FukaHipsSkinnedMeshRendererService _fukaHipsSkinnedMeshRendererService;
        private readonly FukaKneeSkinnedMeshRendererService _fukaRightKneeSkinnedMeshRendererService;
        private readonly FukaKneeSkinnedMeshRendererService _fukaLeftKneeSkinnedMeshRendererService;
        // RO/RW外部アクセス無し。現状LateTickでのみアクセスする。
        private readonly FukaGrounderService _fukaGrounderService;

        private readonly FukaBoneRO _fukaBoneRO;
        private readonly FukaBoneRW _fukaBoneRW;
        private readonly FukaCharacterControllerRO _fukaCharacterControllerRO;
        private readonly FukaCharacterControllerRW _fukaCharacterControllerRW;
        private readonly FukaAnimationRW _fukaAnimationRW;
        private readonly FukaHipsSkinnedMeshRendererRO _fukaHipsSkinnedMeshRendererRO;
        private readonly FukaHipsSkinnedMeshRendererRW _fukaHipsSkinnedMeshRendererRW;
        private readonly FukaKneeSkinnedMeshRendererRO _fukaRightKneeSkinnedMeshRendererRO;
        private readonly FukaKneeSkinnedMeshRendererRW _fukaRightKneeSkinnedMeshRendererRW;
        private readonly FukaKneeSkinnedMeshRendererRO _fukaLeftKneeSkinnedMeshRendererRO;
        private readonly FukaKneeSkinnedMeshRendererRW _fukaLeftKneeSkinnedMeshRendererRW;

        public FukaServiceRoot(FukaRootConfig fukaConfig) {
            if (fukaConfig == null) {
                ErrorHandleService.Fatal("コンポーネントサービス(FukaService)のFukaConfigがnullです。");
            }

            _fukaBoneService = new FukaBoneService(fukaConfig.FukaBoneConfig);
            _fukaCharacterControllerService = new FukaCharacterControllerService(fukaConfig.FukaCharacterControllerConfig);
            _fukaAnimationService = new FukaAnimationService(fukaConfig.FukaAnimationConfig);
            _fukaHipsSkinnedMeshRendererService = new FukaHipsSkinnedMeshRendererService(fukaConfig.FukaCorrectiveShapeConfig.HipsCorrectiveShapeConfig);
            _fukaRightKneeSkinnedMeshRendererService = new FukaKneeSkinnedMeshRendererService(fukaConfig.FukaCorrectiveShapeConfig.RightKneeCorrectiveShapeConfig);
            _fukaLeftKneeSkinnedMeshRendererService = new FukaKneeSkinnedMeshRendererService(fukaConfig.FukaCorrectiveShapeConfig.LeftKneeCorrectiveShapeConfig);
            _fukaGrounderService = new FukaGrounderService(fukaConfig.FukaGrounderConfig);
            _fukaBoneRO = new FukaBoneRO(_fukaBoneService);
            _fukaBoneRW = new FukaBoneRW(_fukaBoneService);
            _fukaCharacterControllerRO = new FukaCharacterControllerRO(_fukaCharacterControllerService);
            _fukaCharacterControllerRW = new FukaCharacterControllerRW(_fukaCharacterControllerService);
            _fukaAnimationRW = new FukaAnimationRW(_fukaAnimationService);
            _fukaHipsSkinnedMeshRendererRO = new FukaHipsSkinnedMeshRendererRO(_fukaHipsSkinnedMeshRendererService);
            _fukaHipsSkinnedMeshRendererRW = new FukaHipsSkinnedMeshRendererRW(_fukaHipsSkinnedMeshRendererService);
            _fukaRightKneeSkinnedMeshRendererRO = new FukaKneeSkinnedMeshRendererRO(_fukaRightKneeSkinnedMeshRendererService);
            _fukaRightKneeSkinnedMeshRendererRW = new FukaKneeSkinnedMeshRendererRW(_fukaRightKneeSkinnedMeshRendererService);
            _fukaLeftKneeSkinnedMeshRendererRO = new FukaKneeSkinnedMeshRendererRO(_fukaLeftKneeSkinnedMeshRendererService);
            _fukaLeftKneeSkinnedMeshRendererRW = new FukaKneeSkinnedMeshRendererRW(_fukaLeftKneeSkinnedMeshRendererService);
        }

        public FukaBoneRO BoneRO => _fukaBoneRO;
        public FukaBoneRW BoneRW => _fukaBoneRW;
        public FukaCharacterControllerRO CharacterControllerRO => _fukaCharacterControllerRO;
        public FukaCharacterControllerRW CharacterControllerRW => _fukaCharacterControllerRW;
        public FukaAnimationRW AnimationRW => _fukaAnimationRW;
        public FukaHipsSkinnedMeshRendererRO HipsSMRRO => _fukaHipsSkinnedMeshRendererRO;
        public FukaHipsSkinnedMeshRendererRW HipsSMRRW => _fukaHipsSkinnedMeshRendererRW;
        public FukaKneeSkinnedMeshRendererRO RightKneeSMRRO => _fukaRightKneeSkinnedMeshRendererRO;
        public FukaKneeSkinnedMeshRendererRW RightKneeSMRRW => _fukaRightKneeSkinnedMeshRendererRW;
        public FukaKneeSkinnedMeshRendererRO LeftKneeSMRRO => _fukaLeftKneeSkinnedMeshRendererRO;
        public FukaKneeSkinnedMeshRendererRW LeftKneeSMRRW => _fukaLeftKneeSkinnedMeshRendererRW;

        public void Tick(float deltaTime) {
            _fukaAnimationService.Tick(deltaTime);
        }

        public void LateTick(float deltaTime) {
            _fukaGrounderService.LateTick(deltaTime);
        }
    }
}