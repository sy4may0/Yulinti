using System.Threading.Tasks;
using System.Threading;
using System;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface ITurrisSalsamenti : ITurrisSalsamentiLegibile {
        // ロード: Thesaurus → Phantasma
        Task Arcessere(Guid id, CancellationToken ct = default);
        Task Deleto(Guid id, CancellationToken ct = default);
        Task<Guid> Creare(CancellationToken ct = default);
        Task<Guid> ArcessereNovissimus(CancellationToken ct = default);

        // セーブ: Phantasma → Thesaurus
        // Executor.Confirmare が済んだ状態の Phantasma を保存する。
        Task<Guid> Servare(CancellationToken ct = default);
        Task<Guid> ServareAutomaticus(CancellationToken ct = default);
    }
}
