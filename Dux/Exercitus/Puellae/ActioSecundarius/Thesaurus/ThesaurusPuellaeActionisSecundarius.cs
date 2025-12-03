using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ThesaurusPuellaeActionisSecundarius {
        public float RaycastAltitudo { get; set; } = 1.0f;
        public float RaycastDistantia { get; set; } = 1.0f;
        public float PesYCorrectivus { get; set; } = 0.113f;
        public float DigitusPedisYCorrectivus { get; set; } = 0.034f;
        public float MaxElevatio { get; set; } = 0.45f;

        public ThesaurusPuellaeActionisSecundarius(IConfiguratioPuellaeActionisSecundarius configuratio) {
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