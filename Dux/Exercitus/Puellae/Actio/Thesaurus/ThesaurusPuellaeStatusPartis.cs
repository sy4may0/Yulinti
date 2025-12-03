using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ThesaurusPuellaeStatusPartis {
        public bool EstLevigatum { get; set; }

        public ThesaurusPuellaeStatusPartis(IConfiguratioPuellaeStatusPartis configuratio) {
            EstLevigatum = configuratio.EstLevigatum;
        }
    }
}