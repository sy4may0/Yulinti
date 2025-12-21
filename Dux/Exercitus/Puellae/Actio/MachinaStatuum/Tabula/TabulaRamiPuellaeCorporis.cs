using Yulinti.Dux.ContractusDucis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Yulinti.Dux.Exercitus {
    internal sealed class TabulaRamiPuellaeCorporis {
        private readonly Dictionary<int, IRamusPuellaeStatusCorporis[]> _tabula;

        public TabulaRamiPuellaeCorporis(
            IConfiguratioPuellaeStatuum configuratioStatuum,
            IOstiumInputMotusLegibile osInputMotusLeg
        ) {
            RamiPuellaeCorporis ramiCorporis = new RamiPuellaeCorporis(configuratioStatuum, osInputMotusLeg);
            FasciculusRamiPuellaeCorporis fasciculus = new FasciculusRamiPuellaeCorporis(ramiCorporis);

            int longitudo = Enum.GetValues(typeof(IDPuellaeStatusCorporis)).Length;
            _tabula = new Dictionary<int, IRamusPuellaeStatusCorporis[]>();

            // IdStatusActualisごとに配列を分割
            for (int i = 1; i < longitudo; i++) {
                IDPuellaeStatusCorporis idStatus = (IDPuellaeStatusCorporis)i;
                IRamusPuellaeStatusCorporis[] rami = fasciculus.Rami
                    .Where(r => r.IdStatusActualis == idStatus)
                    .ToArray();
                _tabula[i] = rami;
            }
        }

        public IRamusPuellaeStatusCorporis[] Lego(IDPuellaeStatusCorporis id) {
            return _tabula[(int)id];
        }
    }
}

