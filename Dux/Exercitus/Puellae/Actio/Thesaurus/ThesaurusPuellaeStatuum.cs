using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ThesaurusPuellaeStatuum {
        public float LimenInputQuadratum { get; set; } = 0.001f;
        public float TempusLevigatumMax { get; set; } = 1.0f;
        public float TempusLevigatumMin { get; set; } = 0.05f;
        public float TempusLevigatumRotationis { get; set; } = 0.2f;
        public float AcceleratioGravitatis { get; set; } = 9.8f;
        public float VelocitasContactus { get; set; } = -9.8f;
        public float VelocitasVerticalisMax { get; set; } = -50f;

        public ThesaurusPuellaeStatuum(IConfiguratioPuellaeStatuum configuratio) {
            LimenInputQuadratum = configuratio.LimenInputQuadratum;
            TempusLevigatumMax = configuratio.TempusLevigatumMax;
            TempusLevigatumMin = configuratio.TempusLevigatumMin;
            TempusLevigatumRotationis = configuratio.TempusLevigatumRotationis;
            AcceleratioGravitatis = configuratio.AcceleratioGravitatis;
            VelocitasContactus = configuratio.VelocitasContactus;
            VelocitasVerticalisMax = configuratio.VelocitasVerticalisMax;
        }
    }
}