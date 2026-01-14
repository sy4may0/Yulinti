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

        public void Ordinare(
            IResFluidaPuellaeLegibile resFluida
        ) {
            _machinaCorporis.Ordinare(resFluida);
        }

        public void MutareStatus(
            IResFluidaPuellaeLegibile resFluida
        ) {
            _machinaCorporis.MutareStatus(resFluida);
        }

        public void ApplicareActionis(
            in OrdinatioPuellaeActionis ordinatio
        ) {
            _motorActionis.ApplicareActionis(ordinatio);
        }

        public void ApplicareAnimationis(
            in OrdinatioPuellaeAnimationis animationis
        ) {
            _motorAnimationis.ApplicareAnimationis(animationis);
        }

        public void ValidereNavmesh(IResFluidaPuellaeLegibile resFluida) {
            if (!_motorActionis.EstInNavmesh()) {
                _motorAnimationis.Purgere();
                _machinaCorporis.Initare(resFluida);
                return;
            }
        }

        public void RenovareResFluidaMotus(
            in ResFluidaPuellaeMotus resFluidaMotus
        ) {
            resFluidaMotus.Renovare(
                _motorActionis.VelocitasHorizontalisActualis(),
                _motorActionis.VelocitasVerticalisActualis(),
                _motorActionis.RotatioYActualis(),
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
