using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesPuellaeActionis {
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;
        private readonly MachinaPuellaeStatuumCorporis _machinaCorporis;
        private readonly MotorPuellaeActionis _motor;
        private readonly IOstiumPuellaeAnimationesMutabile _osAnimationes;
        private readonly IOstiumPuellaeLociMutabile _osLociMutabile;

        private OrdinatioPuellaeActionis _ordinatioActionis;

        public MilesPuellaeActionis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IOstiumPuellaeAnimationesMutabile osAnimationes,
            IOstiumPuellaeLociMutabile osLociMutabile
        ) {
            _contextusOstiorum = contextusOstiorum;
            _osAnimationes = osAnimationes;
            _osLociMutabile = osLociMutabile;
            _machinaCorporis = new MachinaPuellaeStatuumCorporis(
                _contextusOstiorum,
                _osAnimationes
            );
            _motor = new MotorPuellaeActionis(
                _contextusOstiorum,
                _osLociMutabile
            );
        }

        public void OrdinareActionis(
            ContextusPuellaeResFluidaLegibile contextusResFluida
        ) {
            _ordinatioActionis = _machinaCorporis.OrdinareActionis(contextusResFluida);
        }

        public OrdinatioPuellaeVeletudinis OrdinareVeletudinis(
            ContextusPuellaeResFluidaLegibile contextusResFluida
        ) {
            return _machinaCorporis.OrdinareVeletudinis(contextusResFluida);
        }

        public void ApplicareActionis(
            ContextusPuellaeResFluidaLegibile contextusResFluida
        ) {
            if (_ordinatioActionis.EstApplicandum) {
                _motor.ApplicareActionis(_ordinatioActionis);
            }
        }

        public void RenovareResFluidaMotus(ref ResFluidaPuellaeMotus resFluida) {
            resFluida.Renovare(
                _contextusOstiorum.Loci.VelHorizontalisActualis,
                _contextusOstiorum.Loci.VelVerticalisActualis,
                _contextusOstiorum.Loci.RotatioYActualis,
                true
            );
        }

        public void InjicereVelocitatis() {
            _osAnimationes.InjicereVelocitatem(
                _contextusOstiorum.Loci.VelHorizontalisActualis
            );
        }
    }
}