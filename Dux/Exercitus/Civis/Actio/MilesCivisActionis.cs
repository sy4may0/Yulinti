using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal sealed class MilesCivisActionis {
        private readonly ContextusCivisOstiorumLegibile _contextusOstiorum;
        private readonly MachinaCivisStatuumCorporis[] _machinaCorporis;
        private readonly MotorCivisActionis _motorActionis;
        private readonly MotorCivisAnimationis _motorAnimationis;

        public MilesCivisActionis(
            ContextusCivisOstiorumLegibile contextusOstiorum,
            IOstiumCivisAnimationesMutabile osAnimationes,
            IOstiumCivisLociMutabile osLociMutabile
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
                osLociMutabile
            );
            _motorAnimationis = new MotorCivisAnimationis(
                osAnimationes
            );
        }

        public (OrdinatioCivis Initare, OrdinatioCivis IntrareStatus) InitareServatum(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            _motorAnimationis.InitiarePreadefinitus(
                idCivis, _contextusOstiorum.Configuratio.Statuum.IdAnimationisPraedefinitus
            );
            return _machinaCorporis[idCivis].Initare(resFluida);
        }

        public void Purgere(int idCivis) {
            _motorAnimationis.Purgere(idCivis);
        }

        public OrdinatioCivis Ordinare(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            return _machinaCorporis[idCivis].Ordinare(resFluida);
        }

        public (OrdinatioCivis Exire, OrdinatioCivis Intrare) MutareStatus(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            return _machinaCorporis[idCivis].MutareStatus(resFluida);
        }

        public void ApplicareActionis(
            OrdinatioCivisActionis ordinatio
        ) {
            _motorActionis.ApplicareActionis(ordinatio);
        }

        public void ApplicareAnimationis(
            OrdinatioCivisAnimationis animationis
        ) {
            _motorAnimationis.ApplicareAnimationis(animationis);
        }

        public void RenovareResFluidaMotus(
            int idCivis,
            IResFluidaCivisLegibile resFluida,
            ResFluidaCivisMotus resFluidaMotus
        ) {
            resFluidaMotus.RenovareVelocitasActualisHorizontalis(idCivis, _motorActionis.VelocitasHorizontalisActualis(idCivis));
            // 垂直移動は未実装。
            resFluidaMotus.RenovareVelocitasActualisVerticalis(idCivis, 9.81f);
            resFluidaMotus.RenovareRotatioYActualis(idCivis, _motorActionis.RotatioYActualis(idCivis));
            resFluidaMotus.RenovareEstInTerra(idCivis, true);
        }

        public void InjicereVelocitatis(
            int idCivis,
            IResFluidaCivisLegibile resFluida
        ) {
            _motorAnimationis.InjicereVelocitatem(idCivis, resFluida.Motus.VelocitasActualisHorizontalis(idCivis));
        }

        public OrdinatioCivis VerificareNavmesh(int idCivis) {
            return _motorActionis.VerificareNavmesh(idCivis);
        }
    }
}
