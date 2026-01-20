using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
using System;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal enum CivisGenerationisStatus {
        None = 0,
        Initio = 1,
        Paratus = 2,
        Termino = 3
    }
    internal sealed class CuratorCivisGenerationis {
        private readonly int _id;
        private readonly IAnchoraCivis _anchora;
        private List<Action<int>> _adInitium;
        private CivisGenerationisStatus _status;

        public CuratorCivisGenerationis(int id, IAnchoraCivis anchora) {
            _id = id;
            _anchora = anchora;
            _adInitium = new List<Action<int>>();
            _status = CivisGenerationisStatus.None;
            Initiare();
        }

        public void Initiare() {
            if (_anchora.EstEns || _status != CivisGenerationisStatus.None) return;
            _status = CivisGenerationisStatus.Initio;
            InitiareAsync().Forget(e => Memorator.MemorareException(e));
        }

        // Manifestatio成功後は呼び出せない。エラーの場合はゲームを落とす。
        // Updateループでの生成は想定しない。
        private async UniTask InitiareAsync() {
            if (_anchora.EstEns || _status != CivisGenerationisStatus.Initio) return;
            try {

                await _anchora.Manifestatio();
                bool ex = _anchora.ValidareManifestatio();

                if (!ex) {
                    _anchora.Deleto();
                    _status = CivisGenerationisStatus.None;
                    Errorum.Fatal(IDErrorum.CIVIS_INSTANTIATE_FAILED);
                }
                _status = CivisGenerationisStatus.Paratus;

                _adInitium?.ForEach(a => a.Invoke(_id));
                _adInitium = null;
            } catch (Exception e) {
                _status = CivisGenerationisStatus.None;
                Errorum.Fatal(e);
            }
        }

        public void Terminare() {
            if (!_anchora.EstEns || _status != CivisGenerationisStatus.Paratus) return;
            _anchora.Deleto();
            _status = CivisGenerationisStatus.Termino;
        }

        public NihilAut<IAnchoraCivis> Lego() {
            if (_status != CivisGenerationisStatus.Paratus) return new NihilAut<IAnchoraCivis>(null);
            return new NihilAut<IAnchoraCivis>(_anchora);
        }
        public bool ConareLego(out IAnchoraCivis anchora) {
            if (_status != CivisGenerationisStatus.Paratus) {
                anchora = null;
                return false;
            }
            if (_anchora == null || !_anchora.EstEns) {
                anchora = null;
                return false;
            }
            anchora = _anchora;
            return true;
        }

        public void PonoAdInitium(Action<int> adInitium) {
            if (_status >= CivisGenerationisStatus.Paratus && _anchora.EstEns) {
                adInitium?.Invoke(_id);
                return;
            }
            if (adInitium == null) return;
            _adInitium.Add(adInitium);
        }

        public int Id => _id;
        public CivisGenerationisStatus Status => _status;
        public bool EstParatus() => _status == CivisGenerationisStatus.Paratus && _anchora.EstEns;
    }

    internal sealed class TabulaCivis {
        private readonly CuratorCivisGenerationis[] _curatoris;
        private readonly int[] _ids;

        public TabulaCivis(IAnchoraCivis[] anchorae) {
            _ids = new int[anchorae.Length];
            VaridareAnchorae(anchorae);
            _curatoris = new CuratorCivisGenerationis[anchorae.Length];
            for (int i = 0; i < anchorae.Length; i++) {
                _curatoris[i] = new CuratorCivisGenerationis(i, anchorae[i]);
                _ids[i] = i;
            }
        }

        public void VaridareAnchorae(IAnchoraCivis[] anchorae) {
            if (anchorae == null) {
                Errorum.Fatal(IDErrorum.TABULACIVIS_ANCHORAE_NULL);
            }

            var s = new HashSet<IAnchoraCivis>(ComparatorReferentialis<IAnchoraCivis>.Instantia);

            for (int i = 0; i < anchorae.Length; i++) {
                var a = anchorae[i];
                if (a == null) {
                    Errorum.Fatal(IDErrorum.TABULACIVIS_ANCHORA_NULL);
                }
                if (!s.Add(a)) {
                    Errorum.Fatal(IDErrorum.TABULACIVIS_ANCHORA_DUPLICATE);
                }
            }
        }

        public int[] IDs => _ids;
        public int Longitudo => _ids.Length;

        public void PonoAdInitium(int id, Action<int> adInitium) {
            if (id < 0 || id >= _curatoris.Length) return;
            _curatoris[id].PonoAdInitium(adInitium);
        }

        public void Initiare() {
            for (int i = 0; i < _curatoris.Length; i++) {
                _curatoris[i].Initiare();
            }
        }

        public void Terminare() {
            for (int i = 0; i < _curatoris.Length; i++) {
                _curatoris[i].Terminare();
            }
        }

        public NihilAut<IAnchoraCivis> Lego(int id) {
            if (id < 0 || id >= _curatoris.Length) return new NihilAut<IAnchoraCivis>(null);
            return _curatoris[id].Lego();
        }

        public bool ConareLego(int id, out IAnchoraCivis anchora) {
            if (id < 0 || id >= _curatoris.Length) {
                anchora = null;
                return false;
            }
            return _curatoris[id].ConareLego(out anchora);
        }

        public bool EstParatus(int id) {
            if (id < 0 || id >= _curatoris.Length) return false;
            return _curatoris[id].EstParatus();
        }
    }
}