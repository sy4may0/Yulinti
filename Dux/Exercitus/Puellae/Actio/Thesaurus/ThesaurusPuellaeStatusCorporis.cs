using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ThesaurusPuellaeStatusCorporis {
        public IDStatus Id { get; set; }
        public IDPuellaeModiMotus IdModusMotus { get; set; }
        public IDPuellaeAnimationisCorporis IdAnimationis { get; set; }
        public float VelocitasDesiderata { get; set; } = 1.2f;
        public float Acceleratio { get; set; } = 20f;
        public float Deceleratio { get; set; } = 10f;
        public bool EstLevigatum { get; set; } = true;

        public ThesaurusPuellaeStatusCorporis(IConfiguratioPuellaeStatusCorporis configuratio) {
            Id = configuratio.Id;
            IdModusMotus = configuratio.IdModusMotus;
            IdAnimationis = configuratio.IdAnimationis;
            VelocitasDesiderata = configuratio.VelocitasDesiderata;
            Acceleratio = configuratio.Acceleratio;
            Deceleratio = configuratio.Deceleratio;
            EstLevigatum = configuratio.EstLevigatum;
        }
    }
}