using Yulinti.Dux.ContractusDucis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Yulinti.Dux.Exercitus {
    internal sealed class TabulaRamiCivisCorporis {
        private readonly Dictionary<int, IRamusCivisStatusCorporis[]> _tabula;

        public TabulaRamiCivisCorporis(
            IOstiumCivisLociNavmeshLegibile osLociNavmeshLegibile,
            TabulaCivisVitae tabulaVitae
        ) {
            RamiCivisCorporis ramiCorporis = new RamiCivisCorporis(osLociNavmeshLegibile, tabulaVitae);
            FasciculusRamiCivisCorporis fasciculus = new FasciculusRamiCivisCorporis(ramiCorporis);

            int longitudo = Enum.GetValues(typeof(IDCivisStatusCorporis)).Length;
            _tabula = new Dictionary<int, IRamusCivisStatusCorporis[]>();

            // IdStatusActualisごとに配列を分割
            for (int i = 1; i < longitudo; i++) {
                IDCivisStatusCorporis idStatus = (IDCivisStatusCorporis)i;
                IRamusCivisStatusCorporis[] rami = fasciculus.Rami
                    .Where(r => r.IdStatusActualis == idStatus)
                    .ToArray();
                _tabula[i] = rami;
            }
        }

        public IRamusCivisStatusCorporis[] Lego(IDCivisStatusCorporis id) {
            return _tabula[(int)id];
        }
    }
}