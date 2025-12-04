using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ThesaurusPuellaeStatusPartis {
        public IDStatusPartis Id { get; set; }
        public IDPuellaeAnimationisPartis IdAnimationis { get; set; }
        public bool EstLevigatum { get; set; }

        public ThesaurusPuellaeStatusPartis(IConfiguratioPuellaeStatusPartis configuratio) {
            Id = configuratio.Id;
            IdAnimationis = configuratio.IdAnimationis;
            EstLevigatum = configuratio.EstLevigatum;
        }
    }
}