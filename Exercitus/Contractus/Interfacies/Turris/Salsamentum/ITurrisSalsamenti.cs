using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Yulinti.Exercitus.Contractus {
    public interface ITurrisSalsamenti {
        // 各種値
        Task<int> LongitudoManualis(CancellationToken ct = default);
        int LongitudoManualisMaxima { get; }
        Task<int> LongitudoAutomaticus(CancellationToken ct = default);
        int LongitudoAutomaticusMaxima { get; }

        Task<bool> EstNovissimus(CancellationToken ct = default);

        // 管理Utilたち。
        // P1 Notitiaの全取得
        Task<IReadOnlyList<IOstiumSalsamentiNotitiae>> ArcessereNotitiamManualem(CancellationToken ct = default);
        Task<IReadOnlyList<IOstiumSalsamentiNotitiae>> ArcessereNotitiamAutomaticam(CancellationToken ct = default);

        // P2 Load セーブデータをロード。
        Task Arcessere(Guid id, CancellationToken ct = default);
        // P3 セーブデータ削除
        Task Deleto(Guid id, CancellationToken ct = default);

        // P2-Ex1 新規セーブデータ作成
        Task<Guid> Creare(CancellationToken ct = default);
        // P2-Ex2 最新セーブデータをロード
        Task<Guid> ArcessereNovissimus(CancellationToken ct = default);


        // ランタイムUtilたち。
        // P5 セーブデータをセーブ。
        Task<Guid> Servare(
            Guid id,
            IPhantasmaPuellaePersonae phantasmaPuellaePersonae,
            CancellationToken ct = default
        );

        // P5-ex オートセーブデータをセーブ。
        Task<Guid> ServareAutomaticus(
            IPhantasmaPuellaePersonae phantasmaPuellaePersonae,
            CancellationToken ct = default
        );
    }
}
