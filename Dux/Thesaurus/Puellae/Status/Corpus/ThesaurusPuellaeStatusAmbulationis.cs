using Yulinti.MinisteriaUnity.ConfiguratioDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Thesaurus {
    public sealed class ThesaurusPuellaeStatusAmbulationis {
        public IDPuellaeAnimationisCorporis IdAnimationis { get; set; } = IDPuellaeAnimationisCorporis.None;
        public float VelocitasDesiderata { get; set; } = 1.2f;
        public float Acceleratio { get; set; } = 20f;
        public float Deceleratio { get; set; } = 10f;
        public bool EstLevigatum { get; set; } = true;

        public ThesaurusPuellaeStatusAmbulationis() {
        }

        public ThesaurusPuellaeStatusAmbulationis(ConfiguratioPuellaeStatusAmbulationis configuratio) {
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
