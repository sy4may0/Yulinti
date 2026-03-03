using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Yulinti.Exercitus.Contractus {
    public interface ITurrisSalsamentiLegibile {
        Task<int> LongitudoManualis(CancellationToken ct = default);
        int LongitudoManualisMaxima { get; }
        Task<int> LongitudoAutomaticus(CancellationToken ct = default);
        int LongitudoAutomaticusMaxima { get; }

        IOstiumSalsamenti Actualis { get; }
        bool ConareActualis(out IOstiumSalsamenti actualis);

        Task<bool> EstNovissimus(CancellationToken ct = default);

        Task<IReadOnlyList<IOstiumSalsamentiNotitiae>> ArcessereNotitiamManualem(CancellationToken ct = default);
        Task<IReadOnlyList<IOstiumSalsamentiNotitiae>> ArcessereNotitiamAutomaticam(CancellationToken ct = default);
    }
}