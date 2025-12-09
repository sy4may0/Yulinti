using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;
using System;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MachinaPuellaeStatuum : IPulsabilis {
        private readonly TabulaPuellaeStatuumCorporis _tabulaStatuumCorporis;
        private readonly TabulaRamiPuellaeCorporis _tabulaRamiCorporis;
        private readonly IResFluidaPuellaeMotusLegibile _resFluidaMotusLeg;
        private readonly MotorPuellae _motor;

        private IStatusPuellaeCorporis _statusCorporisActualis;
        private IDStatus _idStatusActualis;
        private IDStatus _idStatusProximus;

        private Action _adMutareStatus;


        public MachinaPuellaeStatuum(
            IConfiguratioPuellaeStatuum configuratioStatuum,
            IConfiguratioPuellaeStatusCorporis[] configurationemCorporis,
            IOstiumInputMotusLegibile osInputMotusLeg,
            IOstiumTemporisLegibile osTemporisLeg,
            IOstiumCameraLegibile osCameraLeg,
            IOstiumPuellaeAnimationesMutabile osAnimationes,
            IOstiumPuellaeLociMutabile osPuellaeLociMut,
            IOstiumPuellaeLociLegibile osPuellaeLociLeg,
            IResFluidaPuellaeMotusLegibile resFluidaMotusLeg
        ) {
            _adMutareStatus = AdMutareStatus;

            _motor = new MotorPuellae(
                osPuellaeLociMut,
                osPuellaeLociLeg,
                osTemporisLeg
            );

            _tabulaStatuumCorporis = new TabulaPuellaeStatuumCorporis(
                configuratioStatuum,
                configurationemCorporis,
                osInputMotusLeg,
                osTemporisLeg,
                osCameraLeg,
                osAnimationes
            );
            _tabulaRamiCorporis = new TabulaRamiPuellaeCorporis(
                configuratioStatuum,
                osInputMotusLeg
            );
            _resFluidaMotusLeg = resFluidaMotusLeg;

            _statusCorporisActualis = _tabulaStatuumCorporis.Lego(IDStatus.Quies);
            _idStatusActualis = IDStatus.Quies;
            _idStatusProximus = IDStatus.None;

            InitareAnimationem(configuratioStatuum.IdAnimationisPraedefinitus, osAnimationes);
        }

        private void InitareAnimationem(
            IDPuellaeAnimationisContinuata idAnimationis, 
            IOstiumPuellaeAnimationesMutabile osAnimationes
        ) {
            osAnimationes.Postulare(idAnimationis, null, null);
        }

        public void Pulsus() {
            OrdinatioPuellaeMotus ordinatio = _statusCorporisActualis.Ordinare(_resFluidaMotusLeg);
            _motor.ApplicareMotus(ordinatio);

            MutareStatus();
        }

        private void MutareStatus() {
            IRamusPuellaeStatusCorporis[] rami = _tabulaRamiCorporis.Lego(_idStatusActualis);
            foreach (IRamusPuellaeStatusCorporis ramus in rami) {
                if (ramus.Conditio(_resFluidaMotusLeg) && ramus.IdStatusProximus != _idStatusProximus) {
                    _idStatusProximus = ramus.IdStatusProximus;
                    _statusCorporisActualis.Exire(_resFluidaMotusLeg, _adMutareStatus);
                    return;
                }
            }
        }

        private void AdMutareStatus() {
            _statusCorporisActualis = _tabulaStatuumCorporis.Lego(_idStatusProximus);
            _statusCorporisActualis.Intrare(_resFluidaMotusLeg, null);
            _idStatusActualis = _idStatusProximus;
            _idStatusProximus = IDStatus.Quies;
        }
    }
}