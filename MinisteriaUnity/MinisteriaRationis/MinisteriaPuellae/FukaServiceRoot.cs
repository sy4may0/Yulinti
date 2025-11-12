using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.Nucleus.Interfacies;


namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class MinisteriumPuellae : IPulsabilis, IPulsabilisFixus, IPulsabilisTardus {
        private readonly FukaBoneService _fukaBoneService;
        private readonly FukaCharacterControllerService _fukaCharacterControllerService;
        private readonly MinisteriumPuellaeAnimationes _miPuellaeAnimationes;
        private readonly FukaHipsSkinnedMeshRendererService _fukaHipsSkinnedMeshRendererService;
        private readonly FukaKneeSkinnedMeshRendererService _fukaRightKneeSkinnedMeshRendererService;
        private readonly FukaKneeSkinnedMeshRendererService _fukaLeftKneeSkinnedMeshRendererService;
        // RO/RW外部アクセス無し。現状LateTickでのみアクセスする。
        private readonly FukaGrounderService _fukaGrounderService;

        private readonly FukaBoneRO _fukaBoneRO;
        private readonly FukaBoneRW _fukaBoneRW;
        private readonly FukaCharacterControllerRO _fukaCharacterControllerRO;
        private readonly FukaCharacterControllerRW _fukaCharacterControllerRW;
        private readonly OstiumPuellaeAnimationesMutabile _osPuellaeAnimationesM;
        private readonly FukaHipsSkinnedMeshRendererRO _fukaHipsSkinnedMeshRendererRO;
        private readonly FukaHipsSkinnedMeshRendererRW _fukaHipsSkinnedMeshRendererRW;
        private readonly FukaKneeSkinnedMeshRendererRO _fukaRightKneeSkinnedMeshRendererRO;
        private readonly FukaKneeSkinnedMeshRendererRW _fukaRightKneeSkinnedMeshRendererRW;
        private readonly FukaKneeSkinnedMeshRendererRO _fukaLeftKneeSkinnedMeshRendererRO;
        private readonly FukaKneeSkinnedMeshRendererRW _fukaLeftKneeSkinnedMeshRendererRW;

        public FasciculusOstiorumPuellae(FukaRootConfig fukaConfig) {
            if (fukaConfig == null) {
                ModeratorErrorum.Fatal("FasciculusOstiorumPuellaeのPuellaeConfigがnullです。");
            }

            _fukaBoneService = new FukaBoneService(fukaConfig.FukaBoneConfig);
            _fukaCharacterControllerService = new FukaCharacterControllerService(fukaConfig.FukaCharacterControllerConfig);
            _miPuellaeAnimationes = new MinisteriumPuellaeAnimationes(fukaConfig.FukaAnimationConfig);
            _fukaHipsSkinnedMeshRendererService = new FukaHipsSkinnedMeshRendererService(fukaConfig.FukaCorrectiveShapeConfig.HipsCorrectiveShapeConfig);
            _fukaRightKneeSkinnedMeshRendererService = new FukaKneeSkinnedMeshRendererService(fukaConfig.FukaCorrectiveShapeConfig.RightKneeCorrectiveShapeConfig);
            _fukaLeftKneeSkinnedMeshRendererService = new FukaKneeSkinnedMeshRendererService(fukaConfig.FukaCorrectiveShapeConfig.LeftKneeCorrectiveShapeConfig);
            _fukaGrounderService = new FukaGrounderService(fukaConfig.FukaGrounderConfig);
            _fukaBoneRO = new FukaBoneRO(_fukaBoneService);
            _fukaBoneRW = new FukaBoneRW(_fukaBoneService);
            _fukaCharacterControllerRO = new FukaCharacterControllerRO(_fukaCharacterControllerService);
            _fukaCharacterControllerRW = new FukaCharacterControllerRW(_fukaCharacterControllerService);
            _osPuellaeAnimationesM = new OstiumPuellaeAnimationesMutabile(_miPuellaeAnimationes);
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
        public OstiumPuellaeAnimationesMutabile AnimationesMut => _osPuellaeAnimationesM;
        public FukaHipsSkinnedMeshRendererRO HipsSMRRO => _fukaHipsSkinnedMeshRendererRO;
        public FukaHipsSkinnedMeshRendererRW HipsSMRRW => _fukaHipsSkinnedMeshRendererRW;
        public FukaKneeSkinnedMeshRendererRO RightKneeSMRRO => _fukaRightKneeSkinnedMeshRendererRO;
        public FukaKneeSkinnedMeshRendererRW RightKneeSMRRW => _fukaRightKneeSkinnedMeshRendererRW;
        public FukaKneeSkinnedMeshRendererRO LeftKneeSMRRO => _fukaLeftKneeSkinnedMeshRendererRO;
        public FukaKneeSkinnedMeshRendererRW LeftKneeSMRRW => _fukaLeftKneeSkinnedMeshRendererRW;

        public void Pulsus() {
            _miPuellaeAnimationes.Pulsus();
        }

        public void PulsusTardus() {
            // Grounder更新
        }
    }
}