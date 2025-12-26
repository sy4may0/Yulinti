using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    internal class CivisModiNavmeshMigrareAditorium : ICivisModiNavmesh {
        private readonly IConfiguratioCivisStatusNavmesh _configurationNavmesh;
        private readonly IDCivisModiNavmesh _idModi = IDCivisModiNavmesh.MigrareAditorium;
        private readonly IOstiumPunctumViaeLegibile _osPunctumViae;
        private readonly IOstiumCivisLociNavmeshLegibile _osLoci;
        private readonly IOstiumCivisLociNavmeshMutabile _osLociMutabile;

        // ランダムにエントリーポイントを周回する。
        public CivisModiNavmeshMigrareAditorium(
            IConfiguratioCivisStatusNavmesh configurationNavmesh,
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
                _osLociMutabile.PonoVelocitatem(idCivis, _configurationNavmesh.VelocitasDesiderata);
                _osLociMutabile.PonoAccelerationem(idCivis, _configurationNavmesh.Acceleratio);
                _osLociMutabile.PonoVelocitatemRotationis(idCivis, _configurationNavmesh.VelocitasRotationis);
                _osLociMutabile.PonoDistantiaDeaccelerationis(idCivis, _configurationNavmesh.DistantiaDeaccelerationis);
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