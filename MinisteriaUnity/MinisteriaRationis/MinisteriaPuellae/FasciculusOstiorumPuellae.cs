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
        private readonly MinisteriumPuellaeFiguraePelvis _miPuellaeFiguraePelvis;
        // Left
        private readonly MinisteriumPuellaeFiguraeGenus _miPuellaeFiguraeGenusSin;
        // Right
        private readonly MinisteriumPuellaeFiguraeGenus _miPuellaeFiguraeGenusDex;

        // RO/RW外部アクセス無し。現状LateTickでのみアクセスする。
        private readonly FukaGrounderService _fukaGrounderService;

        private readonly OstiumPuellaeOssisLegibile _osPuellaeOssisLeg;
        private readonly OstiumPuellaeOssisMutabile _osPuellaeOssisMut;
        private readonly OstiumPuellaeLociLegibile _osPuellaeLociLeg;
        private readonly OstiumPuellaeLociMutabile _osPuellaeLociMut;
        private readonly OstiumPuellaeAnimationesMutabile _osPuellaeAnimationesM;
        private readonly OstiumPuellaeFiguraePelvisLegibile _osPuellaeFiguraePelvisLeg;
        private readonly OstiumPuellaeFiguraePelvisMutabile _osPuellaeFiguraePelvisMut;
        private readonly OstiumPuellaeFiguraeGenusLegibile _osPuellaeFiguraeGenusSinLeg;
        private readonly OstiumPuellaeFiguraeGenusMutabile _osPuellaeFiguraeGenusSinMut;
        private readonly OstiumPuellaeFiguraeGenusLegibile _osPuellaeFiguraeGenusDexLeg;
        private readonly OstiumPuellaeFiguraeGenusMutabile _osPuellaeFiguraeGenusDexMut;

        public FasciculusOstiorumPuellae(FukaRootConfig fukaConfig) {
            if (fukaConfig == null) {
                ModeratorErrorum.Fatal("FasciculusOstiorumPuellaeのPuellaeConfigがnullです。");
            }

            _miPuellaeOssis = new MinisteriumPuellaeOssis(fukaConfig.FukaBoneConfig);
            _miPuellaeLoci = new MiniateriumPuellaeLoci(fukaConfig.FukaCharacterControllerConfig);
            _miPuellaeAnimationes = new MinisteriumPuellaeAnimationes(fukaConfig.FukaAnimationConfig);
            _miPuellaeFiguraePelvis = new MinisteriumPuellaeFiguraePelvis(fukaConfig.FukaCorrectiveShapeConfig.HipsCorrectiveShapeConfig);
            _miPuellaeFiguraeGenusSin = new MinisteriumPuellaeFiguraeGenus(fukaConfig.FukaCorrectiveShapeConfig.RightKneeCorrectiveShapeConfig);
            _miPuellaeFiguraeGenusDex = new MinisteriumPuellaeFiguraeGenus(fukaConfig.FukaCorrectiveShapeConfig.LeftKneeCorrectiveShapeConfig);
            _fukaGrounderService = new FukaGrounderService(fukaConfig.FukaGrounderConfig);
            _osPuellaeOssisLeg = new OstiumPuellaeOssisLegibile(_miPuellaeOssis);
            _osPuellaeOssisMut = new OstiumPuellaeOssisMutabile(_miPuellaeOssis);
            _osPuellaeLociLeg = new OstiumPuellaeLociLegibile(_miPuellaeLoci);
            _osPuellaeLociMut = new OstiumPuellaeLociMutabile(_miPuellaeLoci);
            _osPuellaeAnimationesM = new OstiumPuellaeAnimationesMutabile(_miPuellaeAnimationes);
            _osPuellaeFiguraePelvisLeg = new OstiumPuellaeFiguraePelvisLegibile(_miPuellaeFiguraePelvis);
            _osPuellaeFiguraePelvisMut = new OstiumPuellaeFiguraePelvisMutabile(_miPuellaeFiguraePelvis);
            _osPuellaeFiguraeGenusSinLeg = new OstiumPuellaeFiguraeGenusLegibile(_miPuellaeFiguraeGenusSin);
            _osPuellaeFiguraeGenusSinMut = new OstiumPuellaeFiguraeGenusMutabile(_miPuellaeFiguraeGenusSin);
            _osPuellaeFiguraeGenusDexLeg = new OstiumPuellaeFiguraeGenusLegibile(_miPuellaeFiguraeGenusDex);
            _osPuellaeFiguraeGenusDexMut = new OstiumPuellaeFiguraeGenusMutabile(_miPuellaeFiguraeGenusDex);
        }

        public OstiumPuellaeOssisLegibile OssisLeg => _osPuellaeOssisLeg;
        public OstiumPuellaeOssisMutabile OssisMut => _osPuellaeOssisMut;
        public OstiumPuellaeLociLegibile LociLeg => _osPuellaeLociLeg;
        public OstiumPuellaeLociMutabile LociMut => _osPuellaeLociMut;
        public OstiumPuellaeAnimationesMutabile AnimationesMut => _osPuellaeAnimationesM;
        public OstiumPuellaeFiguraePelvisLegibile FiguraePelvisLeg => _osPuellaeFiguraePelvisLeg;
        public OstiumPuellaeFiguraePelvisMutabile FiguraePelvisMut => _osPuellaeFiguraePelvisMut;
        public OstiumPuellaeFiguraeGenusLegibile FiguraeGenusSinLeg => _osPuellaeFiguraeGenusSinLeg;
        public OstiumPuellaeFiguraeGenusMutabile FiguraeGenusSinMut => _osPuellaeFiguraeGenusSinMut;
        public OstiumPuellaeFiguraeGenusLegibile FiguraeGenusDexLeg => _osPuellaeFiguraeGenusDexLeg;
        public OstiumPuellaeFiguraeGenusMutabile FiguraeGenusDexMut => _osPuellaeFiguraeGenusDexMut;

        public void Pulsus() {
            _miPuellaeAnimationes.Pulsus();
        }

        public void PulsusTardus() {
            // Grounder更新
        }
    }
}