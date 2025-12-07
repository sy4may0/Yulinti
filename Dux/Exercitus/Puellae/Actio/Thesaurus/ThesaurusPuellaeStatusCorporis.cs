using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ThesaurusPuellaeStatusCorporis {
        private readonly IDStatus _id;
        private readonly IDPuellaeModiMotus _idModusMotus;
        private readonly IDPuellaeAnimationisContinuata _idAnimationisIntrare;
        private readonly IDPuellaeAnimationisContinuata _idAnimationisExire;
        private readonly bool _ludereExire;
        private readonly bool _estLevigatum;
        public float VelocitasDesiderata { get; set; } = 1.2f;
        public float Acceleratio { get; set; } = 20f;
        public float Deceleratio { get; set; } = 10f;

        public IDStatus Id => _id;
        public IDPuellaeModiMotus IdModusMotus => _idModusMotus;
        public IDPuellaeAnimationisContinuata IdAnimationisIntrare => _idAnimationisIntrare;
        public IDPuellaeAnimationisContinuata IdAnimationisExire => _idAnimationisExire;
        public bool LudereExire => _ludereExire;
        public bool EstLevigatum => _estLevigatum;

        public ThesaurusPuellaeStatusCorporis(IConfiguratioPuellaeStatusCorporis configuratio) {
            _id = configuratio.Id;
            _idModusMotus = configuratio.IdModusMotus;
            _idAnimationisIntrare = configuratio.IdAnimationisIntrare;
            _idAnimationisExire = configuratio.IdAnimationisExire;
            _ludereExire = configuratio.LudereExire;
            _estLevigatum = configuratio.EstLevigatum;
            VelocitasDesiderata = configuratio.VelocitasDesiderata;
            Acceleratio = configuratio.Acceleratio;
            Deceleratio = configuratio.Deceleratio;
        }
    }
}