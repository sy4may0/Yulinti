using Yulinti.MinisteriaUnity.ConfiguratioDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Thesaurus {
    public sealed class ThesaurusPuellaeStatusIncubitus {
        public IDPuellaeAnimationisCorporis IdAnimationis { get; set; } = IDPuellaeAnimationisCorporis.Crouch;
        public float VelocitasDesiderata { get; set; } = 0f;
        public float Acceleratio { get; set; } = 10f;
        public float Deceleratio { get; set; } = 10f;
        public bool EstLevigatum { get; set; } = true;

        public ThesaurusPuellaeStatusIncubitus() {
        }

        public ThesaurusPuellaeStatusIncubitus(ConfiguratioPuellaeStatusIncubitus configuratio) {
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
