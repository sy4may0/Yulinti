using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesPuellaeActionis {
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;
        private readonly MachinaPuellaeStatuumCorporis _machinaCorporis;
        private readonly MotorPuellaeActionis _motorActionis;
        private readonly MotorPuellaeAnimationis _motorAnimationis;

        private OrdinatioPuellaeActionis _ordinatioActionis;

        public MilesPuellaeActionis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum,
            IOstiumPuellaeAnimationesMutabile osAnimationes,
            IOstiumPuellaeLociMutabile osLociMutabile
        ) {
            _contextusOstiorum = contextusOstiorum;
            _machinaCorporis = new MachinaPuellaeStatuumCorporis(
                _contextusOstiorum
            );
            _motorActionis = new MotorPuellaeActionis(
                _contextusOstiorum,
                osLociMutabile
            );
            _motorAnimationis = new MotorPuellaeAnimationis(
                osAnimationes
            );
            _motorAnimationis.InitiarePreadefinitus(
                contextusOstiorum.Configuratio.Statuum.IdAnimationisPraedefinitus
            );
        }

        public void OrdinareActionis(
            IResFluidaPuellaeLegibile resFluida
        ) {
            _ordinatioActionis = _machinaCorporis.OrdinareActionis(resFluida);
        }

        public OrdinatioPuellaeVeletudinis OrdinareVeletudinis(
            IResFluidaPuellaeLegibile resFluida
        ) {
            return _machinaCorporis.OrdinareVeletudinis(resFluida);
        }

        public void MutareStatus(
            IResFluidaPuellaeLegibile resFluida
        ) {
            _machinaCorporis.MutareStatus(
                resFluida,
                in _motorAnimationis
            );
        }

        public void ApplicareActionis(
            IResFluidaPuellaeLegibile resFluida
        ) {
            if (_ordinatioActionis.EstApplicandum) {
                _motorActionis.ApplicareActionis(_ordinatioActionis);
            }
        }

        public void RenovareResFluidaMotus(
            in ResFluidaPuellaeMotus resFluidaMotus
        ) {
            resFluidaMotus.Renovare(
                _contextusOstiorum.Loci.VelHorizontalisActualis,
                _contextusOstiorum.Loci.VelVerticalisActualis,
                _contextusOstiorum.Loci.RotatioYActualis,
                true
            );
        }

        public void InjicereVelocitatis(
            IResFluidaPuellaeLegibile resFluida
        ) {
            _motorAnimationis.InjicereVelocitatem(resFluida.Motus.VelocitasActualisHorizontalis);
        }
    }
}