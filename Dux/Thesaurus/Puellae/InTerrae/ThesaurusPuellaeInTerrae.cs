using Yulinti.MinisteriaUnity.ConfiguratioDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Thesaurus {
    public sealed class ThesaurusPuellaeInTerrae {
        public float RaycastAltitudo { get; set; } = 1.0f;
        public float RaycastDistantia { get; set; } = 1.0f;
        public float PesYCorrectivus { get; set; } = 0.113f;
        public float DigitusPedisYCorrectivus { get; set; } = 0.034f;
        public float MaxElevatio { get; set; } = 0.45f;

        public ThesaurusPuellaeInTerrae() {
        }

        public ThesaurusPuellaeInTerrae(ConfiguratioPuellaeInTerrae configuratio) {
            if (configuratio == null) {
                return;
            }

            RaycastAltitudo = configuratio.RaycastAltitudo;
            RaycastDistantia = configuratio.RaycastDistantia;
            PesYCorrectivus = configuratio.PesYCorrectivus;
            DigitusPedisYCorrectivus = configuratio.DigitusPedisYCorrectivus;
            MaxElevatio = configuratio.MaxElevatio;
        }
    }
}
