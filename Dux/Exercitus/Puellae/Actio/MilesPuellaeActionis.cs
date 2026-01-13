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

        public OrdinatioPuellae Ordinare(
            IResFluidaPuellaeLegibile resFluida
        ) {
            return _machinaCorporis.Ordinare(resFluida);
        }

        public (OrdinatioPuellae Exire, OrdinatioPuellae Intrare) MutareStatus(
            IResFluidaPuellaeLegibile resFluida
        ) {
            return _machinaCorporis.MutareStatus(resFluida);
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

        public OrdinatioPuellae ValidereNavmesh(IResFluidaPuellaeLegibile resFluida) {
            if (!_motorActionis.EstInNavmesh()) {
                _motorAnimationis.Purgere();
                return _machinaCorporis.Initare(resFluida);
            }
            return OrdinatioPuellae.Nihil();
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
