using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Exercitus {
    internal sealed class ThesaurusPuellaeStatuum {
        private readonly float _tempusLevigatumMax;
        private readonly float _tempusLevigatumMin;
        private readonly float _acceleratioGravitatis;
        private readonly float _velocitasContactus;
        private readonly float _velocitasVerticalisMax;
        private readonly IDPuellaeAnimationisContinuata _idAnimationisPraedefinitus;
        private readonly IConfiguratioPuellaeStatusCorporis[] _statusCorporum;
        private readonly IConfiguratioPuellaeStatusPartis[] _statusPartium;

        public float LimenInputQuadratum { get; set; }
        public float TempusLevigatumRotationis { get; set; }

        public float TempusLevigatumMax { get; set; }
        public float TempusLevigatumMin { get; set; }
        public float AcceleratioGravitatis { get; set; }
        public float VelocitasContactus { get; set; }
        public float VelocitasVerticalisMax { get; set; }
        public IDPuellaeAnimationisContinuata IdAnimationisPraedefinitus { get; set; }
        public IConfiguratioPuellaeStatusCorporis[] StatusCorporum { get; set; }
        public IConfiguratioPuellaeStatusPartis[] StatusPartium { get; set; }

        public ThesaurusPuellaeStatuum(IConfiguratioPuellaeStatuum configuratio) {
            LimenInputQuadratum = configuratio.LimenInputQuadratum;
            TempusLevigatumRotationis = configuratio.TempusLevigatumRotationis;
            TempusLevigatumMax = configuratio.TempusLevigatumMax;
            TempusLevigatumMin = configuratio.TempusLevigatumMin;
            AcceleratioGravitatis = configuratio.AcceleratioGravitatis;
            VelocitasContactus = configuratio.VelocitasContactus;
            VelocitasVerticalisMax = configuratio.VelocitasVerticalisMax;
            IdAnimationisPraedefinitus = configuratio.IdAnimationisPraedefinitus;
            StatusCorporum = configuratio.StatusCorporum;
            StatusPartium = configuratio.StatusPartium;
        }
    }
}