using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    internal class CivisModiNavmeshMigrareAditrium : ICivisModiNavmesh {
        private readonly IConfiguratioCivisStatusCorporis _configurationCorporis;
        private readonly IDCivisModiNavmesh _idModi = IDCivisModiNavmesh.MigrareAditrium;
        private readonly IOstiumPunctumViaeLegibile _osPunctumViae;
        private readonly IOstiumCivisLociNavmeshLegibile _osLoci;
        private readonly IOstiumCivisLociNavmeshMutabile _osLociMutabile;

        // ランダムにエントリーポイントを周回する。
        public CivisModiNavmeshMigrareAditrium(
            IConfiguratioCivisStatusCorporis configurationCorporis,
            IOstiumCivisLociNavmeshLegibile osLoci,
            IOstiumCivisLociNavmeshMutabile osLociMutabile,
            IOstiumPunctumViaeLegibile osPunctumViae
        ) {
            _osPunctumViae = osPunctumViae;
            _osLoci = osLoci;
            _osLociMutabile = osLociMutabile;
        }

        public IDCivisModiNavmesh IdModi => _idModi;

        public IPunctumViaeLegibile Intrare(
            int idCivis
        ) {
            // WayPointを取得(ランダムAdritorium)
            ErrorAut<IPunctumViaeLegibile> errorAut = _osPunctumViae.LegoTemere();
            if (errorAut.EstError()) {
                // 見つからなければCrematoriumに向かう。
                errorAut = _osPunctumViae.LegoCrematoriumTemere();
            }
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