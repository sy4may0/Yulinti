using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ThesaurusPuellaeStatusCorporis {
        public float VelocitasDesiderata { get; set; } = 1.2f;
        public float Acceleratio { get; set; } = 20f;
        public float Deceleratio { get; set; } = 10f;
        public bool EstLevigatum { get; set; } = true;

        public ThesaurusPuellaeStatusCorporis(IConfiguratioPuellaeStatusCorporis configuratio) {
            VelocitasDesiderata = configuratio.VelocitasDesiderata;
            Acceleratio = configuratio.Acceleratio;
            Deceleratio = configuratio.Deceleratio;
            EstLevigatum = configuratio.EstLevigatum;
        }
    }
}