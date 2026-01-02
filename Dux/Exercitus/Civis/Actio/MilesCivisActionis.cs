using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesCivisActionis {
        private readonly ContextusCivisOstiorumLegibile _contextusOstiorum;
        private readonly MachinaCivisStatuumCorporis[] _machinaCorporis;
        private readonly MotorCivisActionis _motorActionis;
        private readonly MotorCivisAnimationis _motorAnimationis;

        private OrdinatioCivisActionis[] _ordinatioActionis;

        public MilesCivisActionis(
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IOstiumCivisAnimationesMutabile osAnimationes,
            IOstiumCivisLociMutabile osLociMutabile,
            IOstiumCivisLociNavmeshMutabile osLociNavmeshMutabile
        ) {
            _contextusOstiorum = contextusOstiorum;
            _machinaCorporis = new MachinaCivisStatuumCorporis[contextusOstiorum.Civis.Longitudo];
            for (int i = 0; i < contextusOstiorum.Civis.Longitudo; i++) {
                _machinaCorporis[i] = new MachinaCivisStatuumCorporis(
                    i,
                    contextusOstiorum
                );
            }
            _motorActionis = new MotorCivisActionis(
                contextusOstiorum,
                osLociMutabile,
                osLociNavmeshMutabile
            );
            _motorAnimationis = new MotorCivisAnimationis(
                osAnimationes
            );
        }

        public OrdinatioCivisVeletudinis InitareServatum(
            int idCivis
        ) {
            _machinaCorporis[idCivis].Initare();
            return _motorActionis.InitareNavmesh(idCivis);
        }

        public void OrdinareActionis(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            _ordinatioActionis[idCivis] = _machinaCorporis[idCivis].OrdinareActionis(resFluida);
        }

        public OrdinatioCivisVeletudinis OrdinareVeletudinis(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            // OrdinatioCivisActionisがErrorの場合は、NPC除去
            if (_ordinatioActionis[idCivis].EstError) {
                return new OrdinatioCivisVeletudinis(idCivis, 0f, estSpirituare: true);
            }
            return _machinaCorporis[idCivis].OrdinareVeletudinis(resFluida);
        }

        public void MutareStatus(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            _machinaCorporis[idCivis].MutareStatus(resFluida, in _motorAnimationis);
        }

        public void ApplicareActionis(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            _motorActionis.ApplicareActionis(_ordinatioActionis[idCivis]);
        }

        public void RenovareResFluidaMotus(
            int idCivis,
            IResFluidaCivisLegibile resFluida,
            ResFluidaCivisMotus resFluidaMotus
        ) {
            resFluidaMotus.RenovareVelocitasActualisHorizontalis(idCivis, _motorActionis.VelocitasHorizontalisActualis(idCivis));
            resFluidaMotus.RenovareVelocitasActualisVerticalis(idCivis, _motorActionis.VelocitasVerticalisActualis(idCivis));
            resFluidaMotus.RenovareRotatioYActualis(idCivis, _motorActionis.RotatioYActualis(idCivis));
            resFluidaMotus.RenovareEstInTerra(idCivis, true);
        }

        public void InjicereVelocitatis(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            _motorAnimationis.InjicereVelocitatem(idCivis, resFluida.Motus.VelocitasActualisHorizontalis(idCivis));
        }
    }
}