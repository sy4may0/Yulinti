using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using System;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class TabulaCivis {
        private readonly IAnchoraCivis[] _anchorae;
        private readonly int[] _ids;

        private readonly IReadOnlyList<IOperatioInitiumCivis> _operationum;

        public TabulaCivis(IAnchoraCivis[] anchorae, IReadOnlyList<IOperatioInitiumCivis> operationum) {
            _ids = new int[anchorae.Length];
            VaridareAnchorae(anchorae);
            _operationum = operationum;
            _anchorae = new IAnchoraCivis[anchorae.Length];

            for (int i = 0; i < anchorae.Length; i++) {
                _anchorae[i] = anchorae[i];
                _ids[i] = i;
            }
        }

        // IMinisteriumIncipabilisから呼ぶこと。
        public void Initiare() {
            for (int i = 0; i < _anchorae.Length; i++) {
                InitiareAsync(i).Forget(e => Notarius.Memorare(e));
            }
        }

        private void VaridareAnchorae(IAnchoraCivis[] anchorae) {
            if (anchorae == null) {
                Carnifex.Intermissio(LogTextus.TabulaCivis_TABULACIVIS_ANCHORAE_NULL);
            }

            var s = new HashSet<IAnchoraCivis>(ComparatorReferentialis<IAnchoraCivis>.Instantia);

            for (int i = 0; i < anchorae.Length; i++) {
                var a = anchorae[i];
                if (a == null) {
                    Carnifex.Intermissio(LogTextus.TabulaCivis_TABULACIVIS_ANCHORA_NULL);
                }
                if (!s.Add(a)) {
                    Carnifex.Intermissio(LogTextus.TabulaCivis_TABULACIVIS_ANCHORA_DUPLICATE);
                }
            }
        }

        private async UniTask InitiareAsync(int id) {
            IAnchoraCivis anchora = _anchorae[id];
            if (anchora.EstEns) return;
            try {
                await anchora.Manifestatio();

                if (!anchora.EstEns) {
                    Carnifex.Intermissio(LogTextus.TabulaCivis_TABULACIVIS_INITIARE_FAILED);
                    return;
                }

                foreach (IOperatioInitiumCivis operatio in _operationum) {
                    operatio.Executare(id);
                }
            } catch (Exception e) {
                Notarius.Memorare(e);
                Carnifex.Intermissio(LogTextus.TabulaCivis_TABULACIVIS_INITIARE_FAILED);
            }
        }

        public int[] IDs => _ids;
        public int Longitudo => _ids.Length;

        public void Terminare() {
            for (int i = 0; i < _anchorae.Length; i++) {
                _anchorae[i].Deleto();
            }
        }

        public bool ConareLego(int id, out IAnchoraCivis anchora) {
            if (id < 0 || id >= _anchorae.Length) {
                anchora = null;
                return false;
            }
            if (!_anchorae[id].EstEns) {
                anchora = null;
                return false;
            }
            anchora = _anchorae[id];
            return true;
        }

        public bool EstEns(int id) {
            if (id < 0 || id >= _anchorae.Length) {
                return false;
            }
            return _anchorae[id].EstEns;
        }
    }
}
