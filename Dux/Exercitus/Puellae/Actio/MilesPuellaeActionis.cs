using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesPuellaeActionis : IMilesPuellaeActionis {
        private readonly MachinaPuellaeStatuum _machinaPuellaeStatuum;
        private readonly IResFluidaPuellaeMotusLegibile _resFluidaMotusLeg;
        private readonly IOstiumPuellaeLociLegibile _osPuellaeLociLeg;
        private ResFluidaPuellaeMotus _resFluidaMotus;

        // VContainer注入
        public MilesPuellaeActionis(
            IConfiguratioPuellaeStatuum configuratioStatuum,
            IConfiguratioPuellaeStatusCorporis[] configurationemCorporis,
            IOstiumInputMotusLegibile osInputMotusLeg,
            IOstiumTemporisLegibile osTemporisLeg,
            IOstiumCameraLegibile osCameraLeg,
            IOstiumPuellaeAnimationesMutabile osAnimationes,
            IOstiumPuellaeLociMutabile osPuellaeLociMut,
            IOstiumPuellaeLociLegibile osPuellaeLociLeg
        ) {
            _resFluidaMotus = new ResFluidaPuellaeMotus();
            _resFluidaMotusLeg = new ResFluidaPuellaeMotusLegibile(_resFluidaMotus);
 
            _machinaPuellaeStatuum = new MachinaPuellaeStatuum(
                configuratioStatuum,
                configurationemCorporis,
                osInputMotusLeg,
                osTemporisLeg,
                osCameraLeg,
                osAnimationes,
                osPuellaeLociMut,
                osPuellaeLociLeg,
                _resFluidaMotusLeg
            );
       }

        public IDStatus StatusCorporisActualis => _machinaPuellaeStatuum.IdStatusActualis;

        public void Opero() {
            _machinaPuellaeStatuum.Opero();
        }

        public void RenovareFluidaMotus() {
            _resFluidaMotus.Renovare(
                _osPuellaeLociLeg.VelHorizontalisActualis,
                _osPuellaeLociLeg.VelVerticalisActualis,
                _osPuellaeLociLeg.RotatioYActualis,
                true // 接地判定は未設計。高所落下を実装するのであればここになんか作らないといけない。
            );
            _machinaPuellaeStatuum.InjicereVelocitatem(_resFluidaMotus.VelocitasActualisHorizontalis);
        }
    }
}