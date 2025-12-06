using Yulinti.MinisteriaUnity.ConfiguratioDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Thesaurus {
    public sealed class ThesaurusPuellaeStatuumGlobalis {
        public float LimenInputQuadratum { get; set; } = 0.001f;
        public float TempusLevigatumMax { get; set; } = 1.0f;
        public float TempusLevigatumMin { get; set; } = 0.05f;
        public float TempusLevigatumRotationis { get; set; } = 0.2f;
        public float AcceleratioGravitatis { get; set; } = 9.8f;
        public float VelocitasVerticalisMax { get; set; } = -50f;
        public float VelocitasContactus { get; set; } = -9.8f;
        public IDPuellaeAnimationisContinuata IdAnimationisFun { get; set; } = IDPuellaeAnimationisContinuata.StandardBase;

        public ThesaurusPuellaeStatuumGlobalis() {
        }

        public ThesaurusPuellaeStatuumGlobalis(ConfiguratioPuellaeStatuumGlobalis configuratio) {
            if (configuratio == null) {
                return;
            }

            LimenInputQuadratum = configuratio.LimenInputQuadratum;
            TempusLevigatumMax = configuratio.TempusLevigatumMax;
            TempusLevigatumMin = configuratio.TempusLevigatumMin;
            TempusLevigatumRotationis = configuratio.TempusLevigatumRotationis;
            AcceleratioGravitatis = configuratio.AcceleratioGravitatis;
            VelocitasVerticalisMax = configuratio.VelocitasVerticalisMax;
            VelocitasContactus = configuratio.VelocitasContactus;
            IdAnimationisFun = configuratio.IdAnimationisFun;
        }
    }
}
