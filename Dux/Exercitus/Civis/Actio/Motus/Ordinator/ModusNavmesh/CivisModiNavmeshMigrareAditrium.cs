using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    internal class CivisModiNavmeshMigrareAditrium : ICivisModiNavmesh {
        private readonly IDCivisModiNavmesh _idModi = IDCivisModiNavmesh.MigrareAditrium;
        private readonly IOstiumPunctumViaeLegibile _osPunctumViae;
        private readonly IOstiumCivisLociNavmeshLegibile _osLoci;
        private readonly IOstiumCivisLociNavmeshMutabile _osLociMutabile;

        // ランダムにエントリーポイントを周回する。
        public CivisModiNavmeshMigrareAditrium(
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
            int idCivis,
            float velocitasDesiderata,
            float acceleratio,
            int velocitasRotationis,
            float distantiaDeaccelerationis
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
                _osLociMutabile.PonoVelocitatem(idCivis, velocitasDesiderata);
                _osLociMutabile.PonoAccelerationem(idCivis, acceleratio);
                _osLociMutabile.PonoVelocitatemRotationis(idCivis, velocitasRotationis);
                _osLociMutabile.PonoDistantiaDeaccelerationis(idCivis, distantiaDeaccelerationis);
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