using Yulinti.MinisteriaUnity.ConfiguratioDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Thesaurus {
    public sealed class ThesaurusPuellaeStatusIncubitusAmbulationis {
        public IDPuellaeAnimationisCorporis IdAnimationis { get; set; } = IDPuellaeAnimationisCorporis.Crouch;
        public float VelocitasDesiderata { get; set; } = 0.9f;
        public float Acceleratio { get; set; } = 10f;
        public float Deceleratio { get; set; } = 20f;
        public bool EstLevigatum { get; set; } = true;

        public ThesaurusPuellaeStatusIncubitusAmbulationis() {
        }

        public ThesaurusPuellaeStatusIncubitusAmbulationis(ConfiguratioPuellaeStatusIncubitusAmbulationem configuratio) {
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
