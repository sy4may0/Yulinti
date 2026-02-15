using System.Threading;
using System.Threading.Tasks;

namespace Yulinti.Exercitus.Contractus {
    public interface ITurrisSalsamenti {
        int Longitudo { get; }
        long Revisio { get; }
        
        // 現在選択されているSalsamentumを返す。
        int IDSalsamentumActualis { get; }
        IOstiumSalsamenti SalsamentumActualis { get; }

        // ゲーム開始用IF。
        // 新規Salsamentumを作成。NewGameで実行する。
        bool Creare();
        // 指定IDのSalsamentumを選択。LoadGameで実行する。
        bool Seligere(int idSalsamentum);
        // Revisionが最新のSalsamentumを選択。ContinueGameで実行する。
        bool SeligereNovissimum();

        // 操作用IF。
        // 指定IDのSalsamentumを取得。UIでセーブデータリストとか出す際に使う。
        IOstiumSalsamenti Lego(int idSalsamentum);
        // 更新用IF。
        // 指定IDのSalsamentumの削除フラグを立てる。
        void Liberare(int idSalsamentum);
        // 指定IDのSalsamentumの更新フラグを立てる。
        void Renovere(int idSalsamentum);
        // Salsamentumを再選択

        // ランタイムIF。
        // 指定IDのSalsamentumのDTOを更新。
        void Renovere(IResFluidaPuellaePersonaeLegibile resFluida);
        // 更新されたDTOをファイルに反映、または削除。
        // Creare, Liberare, Renovereがフレーム内で呼ばれていたらLateUpdateで実行するべき。
        Task ServareAsync(CancellationToken ct);
    }
}