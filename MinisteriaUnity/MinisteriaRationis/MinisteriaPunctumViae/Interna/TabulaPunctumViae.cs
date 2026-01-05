using Yulinti.MinisteriaUnity.ContractusMinisterii;
using System.Collections.Generic;
using Yulinti.Dux.ContractusDucis;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class TabulaPunctumViae {
        private readonly Dictionary<IDPunctumViaeTypi, PunctumViae[]> _tabula;
        private readonly PunctumViae[] _punctaViae;
        private readonly PunctumViae[] _crematorium;
        private readonly PunctumViae[] _natorium;
        private readonly PunctumViae[] _aditrium;

        private readonly IPunctumViaeLegibile[] _punctaViaeLegibile;

        public TabulaPunctumViae(
            IAnchoraPunctumViae[] anchoraPunctumViae,
            IDPunctumViaeTypi[] crematorium,
            IDPunctumViaeTypi[] natorium,
            IDPunctumViaeTypi[] aditrium
        ) {
            _punctaViae = new PunctumViae[anchoraPunctumViae.Length];
            Dictionary<IDPunctumViaeTypi, List<PunctumViae>> tabula = new Dictionary<IDPunctumViaeTypi, List<PunctumViae>>();

            HashSet<IDPunctumViaeTypi> c_set = new HashSet<IDPunctumViaeTypi>(crematorium);
            HashSet<IDPunctumViaeTypi> n_set = new HashSet<IDPunctumViaeTypi>(natorium);
            HashSet<IDPunctumViaeTypi> a_set = new HashSet<IDPunctumViaeTypi>(aditrium);
            List<PunctumViae> c_list = new List<PunctumViae>();
            List<PunctumViae> n_list = new List<PunctumViae>();
            List<PunctumViae> a_list = new List<PunctumViae>();
            List<IPunctumViaeLegibile> ostium_list = new List<IPunctumViaeLegibile>();

            for (int i = 0; i < anchoraPunctumViae.Length; i++) {
                _punctaViae[i] = new PunctumViae(i, anchoraPunctumViae[i]);
                IAnchoraPunctumViae a = anchoraPunctumViae[i];
                if (!tabula.ContainsKey(a.Typus)) {
                    tabula[a.Typus] = new List<PunctumViae>();
                }
                tabula[a.Typus].Add(new PunctumViae(i, a));

                if (c_set.Contains(a.Typus)) {
                    c_list.Add(_punctaViae[i]);
                }
                if (n_set.Contains(a.Typus)) {
                    n_list.Add(_punctaViae[i]);
                }
                if (a_set.Contains(a.Typus)) {
                    a_list.Add(_punctaViae[i]);
                }
                ostium_list.Add(new PunctumViaeLegibile(_punctaViae[i]));
            }

            _tabula = new Dictionary<IDPunctumViaeTypi, PunctumViae[]>(tabula.Count);
            foreach (var item in tabula) {
                _tabula[item.Key] = item.Value.ToArray();
            }
            _crematorium = c_list.ToArray();
            _natorium = n_list.ToArray();
            _aditrium = a_list.ToArray();
            _punctaViaeLegibile = ostium_list.ToArray();
        }

        public PunctumViae[] Lego(IDPunctumViaeTypi typus) => _tabula[typus];
        public PunctumViae LegoIndexis(int indexis) => _punctaViae[indexis];

        public PunctumViae[] LegoCrematorium() => _crematorium;
        public PunctumViae[] LegoNatorium() => _natorium;
        public PunctumViae[] LegoAditrium() => _aditrium;
        public IPunctumViaeLegibile LegoOstium(int indexis) => _punctaViaeLegibile[indexis];
    }
}