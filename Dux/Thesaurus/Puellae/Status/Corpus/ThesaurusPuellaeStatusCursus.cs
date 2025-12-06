using Yulinti.MinisteriaUnity.ConfiguratioDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Thesaurus {
    public sealed class ThesaurusPuellaeStatusCursus {
        public IDPuellaeAnimationisContinuata IdAnimationis { get; set; } = IDPuellaeAnimationisContinuata.None;
        public float VelocitasDesiderata { get; set; } = 3.3f;
        public float Acceleratio { get; set; } = 15f;
        public float Deceleratio { get; set; } = 15f;
        public bool EstLevigatum { get; set; } = true;

        public ThesaurusPuellaeStatusCursus() {
        }

        public ThesaurusPuellaeStatusCursus(ConfiguratioPuellaeStatusCursus configuratio) {
            if (configuratio == null) {
                return;
            }

            IdAnimationis = configuratio.IdAnimationis;
            VelocitasDesiderata = configuratio.VelocitasDesiderata;
            Acceleratio = configuratio.Acceleratio;
            Deceleratio = configuratio.Deceleratio;
            EstLevigatum = configuratio.EstLevigatum;
        }
    }
}
