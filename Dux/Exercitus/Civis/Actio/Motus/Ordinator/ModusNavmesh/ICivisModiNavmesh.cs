using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    public interface ICivisModiNavmesh {
        IDCivisModiNavmesh IdModi { get; }
        // Navmesh移動開始。成功したら目的地を返す。
        // 失敗したらnullを返す。リカバリ不能のため、ここでnullが返ったら強制的にNPCをキル。
        IPunctumViaeLegibile Intrare(int idCivis);
        // Navmesh移動終了。成功したらtrueを返す。
        // 失敗したらfalseを返す。リカバリ不能のため、ここでfalseが返ったら強制的にNPCをキル。
        bool Exire(int idCivis);
    }
}