using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceConfig;
using Yulinti.Nucleus.Interfacies;

// 消す
using Yulinti.UnityServices.ComponentServices;


namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class FasciculusOstiorumPuellae : IPulsabilis, IPulsabilisTardus {
        private readonly MinisteriumPuellaeOssis _miPuellaeOssis;
        private readonly MiniateriumPuellaeLoci _miPuellaeLoci;
        private readonly MinisteriumPuellaeAnimationes _miPuellaeAnimationes;
        private readonly FukaHipsSkinnedMeshRendererService _fukaHipsSkinnedMeshRendererService;
        private readonly FukaKneeSkinnedMeshRendererService _fukaRightKneeSkinnedMeshRendererService;
        private readonly FukaKneeSkinnedMeshRendererService _fukaLeftKneeSkinnedMeshRendererService;
        // RO/RW外部アクセス無し。現状LateTickでのみアクセスする。
        private readonly FukaGrounderService _fukaGrounderService;

        private readonly OstiumPuellaeOssisLegibile _osPuellaeOssisLeg;
        private readonly OstiumPuellaeOssisMutabile _osPuellaeOssisMut;
        private readonly OstiumPuellaeLociLegibile _osPuellaeLociLeg;
        private readonly OstiumPuellaeLociMutabile _osPuellaeLociMut;
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

            _miPuellaeOssis = new MinisteriumPuellaeOssis(fukaConfig.FukaBoneConfig);
            _miPuellaeLoci = new MiniateriumPuellaeLoci(fukaConfig.FukaCharacterControllerConfig);
            _miPuellaeAnimationes = new MinisteriumPuellaeAnimationes(fukaConfig.FukaAnimationConfig);
            _fukaHipsSkinnedMeshRendererService = new FukaHipsSkinnedMeshRendererService(fukaConfig.FukaCorrectiveShapeConfig.HipsCorrectiveShapeConfig);
            _fukaRightKneeSkinnedMeshRendererService = new FukaKneeSkinnedMeshRendererService(fukaConfig.FukaCorrectiveShapeConfig.RightKneeCorrectiveShapeConfig);
            _fukaLeftKneeSkinnedMeshRendererService = new FukaKneeSkinnedMeshRendererService(fukaConfig.FukaCorrectiveShapeConfig.LeftKneeCorrectiveShapeConfig);
            _fukaGrounderService = new FukaGrounderService(fukaConfig.FukaGrounderConfig);
            _osPuellaeOssisLeg = new OstiumPuellaeOssisLegibile(_miPuellaeOssis);
            _osPuellaeOssisMut = new OstiumPuellaeOssisMutabile(_miPuellaeOssis);
            _osPuellaeLociLeg = new OstiumPuellaeLociLegibile(_miPuellaeLoci);
            _osPuellaeLociMut = new OstiumPuellaeLociMutabile(_miPuellaeLoci);
            _osPuellaeAnimationesM = new OstiumPuellaeAnimationesMutabile(_miPuellaeAnimationes);
            _fukaHipsSkinnedMeshRendererRO = new FukaHipsSkinnedMeshRendererRO(_fukaHipsSkinnedMeshRendererService);
            _fukaHipsSkinnedMeshRendererRW = new FukaHipsSkinnedMeshRendererRW(_fukaHipsSkinnedMeshRendererService);
            _fukaRightKneeSkinnedMeshRendererRO = new FukaKneeSkinnedMeshRendererRO(_fukaRightKneeSkinnedMeshRendererService);
            _fukaRightKneeSkinnedMeshRendererRW = new FukaKneeSkinnedMeshRendererRW(_fukaRightKneeSkinnedMeshRendererService);
            _fukaLeftKneeSkinnedMeshRendererRO = new FukaKneeSkinnedMeshRendererRO(_fukaLeftKneeSkinnedMeshRendererService);
            _fukaLeftKneeSkinnedMeshRendererRW = new FukaKneeSkinnedMeshRendererRW(_fukaLeftKneeSkinnedMeshRendererService);
        }

        public OstiumPuellaeOssisLegibile OssisLeg => _osPuellaeOssisLeg;
        public OstiumPuellaeOssisMutabile OssisMut => _osPuellaeOssisMut;
        public OstiumPuellaeLociLegibile LociLeg => _osPuellaeLociLeg;
        public OstiumPuellaeLociMutabile LociMut => _osPuellaeLociMut;
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