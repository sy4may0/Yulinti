using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Yulinti.Exercitus.Contractus {
    public interface ITurrisSalsamenti {
        // 管理Utilたち。
        // P1 Notitiaの全取得
        Task<IReadOnlyList<IOstiumSalsamentiNotitiae>> ArcessereNotitiamManualem(CancellationToken ct = default);
        Task<IReadOnlyList<IOstiumSalsamentiNotitiae>> ArcessereNotitiamAutomaticam(CancellationToken ct = default);

        // P2 Load セーブデータを取得してキャッシュ。
        Task Arcessere(Guid id, CancellationToken ct = default);
        // P3 セーブデータ削除
        Task Deleto(Guid id, CancellationToken ct = default);

        // P2-Ex1 新規セーブデータ作成
        Task<Guid> Creare(CancellationToken ct = default);
        // P2-Ex2 最新セーブデータをロード
        Task ArcessereNovissimus(CancellationToken ct = default);
    }
}