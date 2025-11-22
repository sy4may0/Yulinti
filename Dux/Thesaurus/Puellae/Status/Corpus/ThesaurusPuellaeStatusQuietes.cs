using Yulinti.MinisteriaUnity.ConfiguratioDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Thesaurus {
    public sealed class ThesaurusPuellaeStatusQuietes {
        public IDPuellaeAnimationisCorporis IdAnimationis { get; set; } = IDPuellaeAnimationisCorporis.None;
        public float VelocitasDesiderata { get; set; } = 0f;
        public float Acceleratio { get; set; } = 30f;
        public float Deceleratio { get; set; } = 20f;
        public bool EstLevigatum { get; set; } = true;

        public ThesaurusPuellaeStatusQuietes() {
        }

        public ThesaurusPuellaeStatusQuietes(ConfiguratioPuellaeStatusQuietes configuratio) {
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
