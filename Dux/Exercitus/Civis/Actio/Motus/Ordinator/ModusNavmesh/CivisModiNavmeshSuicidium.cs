using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    internal class CivisModiNavmeshSuicidium : ICivisModiNavmesh {
        private readonly IConfiguratioCivisStatusCorporis _configurationCorporis;
        private readonly IDCivisModiNavmesh _idModi = IDCivisModiNavmesh.Suicidium;
        private readonly IOstiumCivisLociNavmeshLegibile _osLoci;
        private readonly IOstiumCivisLociNavmeshMutabile _osLociMutabile;
        private readonly IOstiumPunctumViaeLegibile _osPunctumViae;

        // Crematriumに移動する。
        public CivisModiNavmeshSuicidium(
            IConfiguratioCivisStatusCorporis configurationCorporis,
            IOstiumCivisLociNavmeshLegibile osLoci,
            IOstiumCivisLociNavmeshMutabile osLociMutabile,
            IOstiumPunctumViaeLegibile osPunctumViae
        ) {
            _configurationCorporis = configurationCorporis;
            _osLoci = osLoci;
            _osLociMutabile = osLociMutabile;
            _osPunctumViae = osPunctumViae;
        }

        public IDCivisModiNavmesh IdModi => _idModi;

        public IPunctumViaeLegibile Intrare(
            int idCivis
        ) {
            // Crematriumを取得
            ErrorAut<IPunctumViaeLegibile> errorAut = _osPunctumViae.LegoCrematoriumTemere();
            if (errorAut.Conare(out IPunctumViaeLegibile punctumViae)) {
                _osLociMutabile.Activare(idCivis);
                _osLociMutabile.IncipereMigrare(idCivis, punctumViae.Positio);
                _osLociMutabile.PonoVelocitatem(idCivis, _configurationCorporis.VelocitasDesiderata);
                _osLociMutabile.PonoAccelerationem(idCivis, _configurationCorporis.Acceleratio);
                _osLociMutabile.PonoVelocitatemRotationis(idCivis, _configurationCorporis.VelocitasRotationis);
                _osLociMutabile.PonoDistantiaDeaccelerationis(idCivis, _configurationCorporis.DistantiaDeaccelerationis);
                return punctumViae;
            } else {
                return null;
            }
        }

        public bool Exire(int idCivis) {
            _osLociMutabile.TerminareMigrare(idCivis);
            _osLociMutabile.Deactivare(idCivis);
            return true;
        }
    }
}