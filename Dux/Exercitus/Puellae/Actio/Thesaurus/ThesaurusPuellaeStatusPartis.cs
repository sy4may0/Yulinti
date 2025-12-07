using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ThesaurusPuellaeStatusPartis {
        private readonly IDStatusPartis _id;
        private readonly IDPuellaeAnimationisContinuata _idAnimationisIntrare;
        private readonly IDPuellaeAnimationisContinuata _idAnimationisExire;
        private readonly bool _ludereExire;
        private readonly bool _estLevigatum;

        public IDStatusPartis Id => _id;
        public IDPuellaeAnimationisContinuata IdAnimationisIntrare => _idAnimationisIntrare;
        public IDPuellaeAnimationisContinuata IdAnimationisExire => _idAnimationisExire;
        public bool LudereExire => _ludereExire;
        public bool EstLevigatum => _estLevigatum;

        public ThesaurusPuellaeStatusPartis(IConfiguratioPuellaeStatusPartis configuratio) {
            _id = configuratio.Id;
            _idAnimationisIntrare = configuratio.IdAnimationisIntrare;
            _idAnimationisExire = configuratio.IdAnimationisExire;
            _ludereExire = configuratio.LudereExire;
            _estLevigatum = configuratio.EstLevigatum;
        }
    }
}