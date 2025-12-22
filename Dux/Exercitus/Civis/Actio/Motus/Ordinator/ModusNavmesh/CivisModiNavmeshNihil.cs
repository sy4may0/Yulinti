using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal class CivisModiNavmeshNihil : ICivisModiNavmesh {
        private readonly IDCivisModiNavmesh _idModi = IDCivisModiNavmesh.None;
        private readonly IOstiumCivisLociNavmeshLegibile _osLoci;
        private readonly IOstiumCivisLociNavmeshMutabile _osLociMutabile;

        // Navmeshを使わないCharacterController使用ステートなどで使用する。
        public CivisModiNavmeshNihil(
            IOstiumCivisLociNavmeshLegibile osLoci,
            IOstiumCivisLociNavmeshMutabile osLociMutabile
        ) {
            _osLoci = osLoci;
            _osLociMutabile = osLociMutabile;
        }

        public IDCivisModiNavmesh IdModi => _idModi;

        // 常にNavmeshを無効化
        public IPunctumViaeLegibile Intrare(
            int idCivis,
            float velocitasDesiderata,
            float acceleratio,
            int velocitasRotationis,
            float distantiaDeaccelerationis
        ) {
            _osLociMutabile.Deactivare(idCivis);
            return null;
        }

        // 常にNavmeshを無効化
        public bool Exire(int idCivis) {
            _osLociMutabile.Deactivare(idCivis);
            return true;
        }
    }
}