using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using Cysharp.Threading.Tasks;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Officia.Contractus;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Officia.Ministeria {
    public sealed class LacusAnchorarumCivis : ILacusAnchorarumCivisLegibile {
        private readonly int _longitudo;
        private readonly IAnchoraCivis[] _anchorae;
        private readonly IReadOnlyList<IOperatioAnchoraCivis> _operationumAnchorae;
        private readonly IReadOnlyList<IOperatioCivisGenerationis> _operationumCivisGenerationis;

        public LacusAnchorarumCivis(
            IAnchoraCivis[] anchorae,
            IReadOnlyList<IOperatioAnchoraCivis> operationumAnchorae,
            IReadOnlyList<IOperatioCivisGenerationis> operationumCivisGenerationis
        ) {
            _longitudo = anchorae.Length;
            ValidareAnchorae(anchorae);
            _operationumAnchorae = operationumAnchorae;
            _operationumCivisGenerationis = operationumCivisGenerationis;
            _anchorae = new IAnchoraCivis[_longitudo];

            for (int i = 0; i < _longitudo; i++) {
                _anchorae[i] = anchorae[i];
            }
        }

        private void ValidareAnchorae(IAnchoraCivis[] anchorae) {
            if (anchorae == null) {
                Carnifex.Intermissio(LogTextus.LacusAnchorarumCivis_LACUSANCHORARUMCIVIS_ANCHORAE_NULL);
            }
            var s = new HashSet<IAnchoraCivis>(ComparatorReferentialis<IAnchoraCivis>.Instantia);
            for (int i = 0; i < anchorae.Length; i++) {
                var a = anchorae[i];
                if (a == null) {
                    Carnifex.Intermissio(LogTextus.LacusAnchorarumCivis_LACUSANCHORARUMCIVIS_ANCHORA_NULL);
                }
                if (!s.Add(a)) {
                    Carnifex.Intermissio(LogTextus.LacusAnchorarumCivis_LACUSANCHORARUMCIVIS_ANCHORA_DUPLICATE);
                }
            }
        }


        // ILacusAnchorarumCivisLegibile
        // 内部ROインターフェース
        public int Longitudo => _anchorae.Length;
        public bool ConareLego(int idCivis, out IAnchoraCivis anchora) {
            if (idCivis < 0 || idCivis >= _longitudo) {
                anchora = null;
                return false;
            }
            if (!_anchorae[idCivis].EstEns) {
                anchora = null;
                return false;
            }
            anchora = _anchorae[idCivis];
            return true;
        }

        public bool EstEns(int idCivis) {
            if (idCivis < 0 || idCivis >= _longitudo) {
                return false;
            }
            return _anchorae[idCivis].EstEns;
        }

        public bool EstActivum(int idCivis) {
            if (idCivis < 0 || idCivis >= _longitudo) {
                return false;
            }
            return _anchorae[idCivis].EstActivum;
        }

        // 内部RWインターフェース
        public async UniTask ManifestatioAsync(
            IDCivisPersonae idCivisPersonae,
            AssetReferenceGameObject schema = null
        ) {
            int idCivis = -1;
            for (int i = 0; i < _longitudo; i++) {
                if (_anchorae[i].EstManifestatum) continue;
                if (_anchorae[i].EstEns) continue;
                idCivis = i;
                break;
            }
            if (idCivis == -1) return;
            
            // Prefab指定Manifestatio
            if (schema != null) {
                if (!_anchorae[idCivis].PonoSchemam(schema)) {
                    Notarius.Memorare(LogTextus.LacusAnchorarumCivis_LACUSANCHORARUMCIVIS_CHANGE_SCHEMA_FAILED);
                };
            }
            
            // !!ここより前に絶対にawaitを入れるな。!!
            // idCivisの二重確保が起きうるようになる。Manifestatio()の先頭当たりまでUnityMainで動かすこと。
            await _anchorae[idCivis].Manifestatio();

            //メインスレッド
            await UniTask.SwitchToMainThread();

            if (!_anchorae[idCivis].EstEns) {
                Notarius.Memorare(LogTextus.LacusAnchorarumCivis_LACUSANCHORARUMCIVIS_MANIFESTATIO_FAILED);
                return;
            }

            // ここでアクティブにする。必ずActive直後にOperatioが実行されるように。
            _anchorae[idCivis].Incarnare();

            // Operationum実行
            foreach (IOperatioAnchoraCivis operatio in _operationumAnchorae) {
                operatio.ExecutareManifestatio(idCivis, _anchorae[idCivis]);
            }
            foreach (IOperatioCivisGenerationis operatio in _operationumCivisGenerationis) {
                operatio.ExecutareManifestatio(idCivis, idCivisPersonae);
                operatio.ExecutareIncarnare(idCivis);
            }

            // idCivisは返さないでいいと思う。
            // idCivisとanchoraがほしかったらOperatioを流し込んでくれ給えよ。
        }

        public void Deleto(int idCivis) {
            if (idCivis < 0 || idCivis >= _longitudo) {
                return;
            }
            if (!_anchorae[idCivis].EstEns) {
                return;
            }
            _anchorae[idCivis].Deleto();

            foreach (IOperatioCivisGenerationis operatio in _operationumCivisGenerationis) {
                operatio.ExecutareSpirituare(idCivis);
                operatio.ExecutareDeleto(idCivis);
            }
            foreach (IOperatioAnchoraCivis operatio in _operationumAnchorae) {
                operatio.ExecutareDeleto(idCivis);
            }
        }

        public void Incarnare(int idCivis) {
            if (idCivis < 0 || idCivis >= _longitudo) {
                return;
            }
            if (!_anchorae[idCivis].EstEns) {
                return;
            }
            _anchorae[idCivis].Incarnare();
            foreach (IOperatioCivisGenerationis operatio in _operationumCivisGenerationis) {
                operatio.ExecutareIncarnare(idCivis);
            }
        }

        public void Spirituare(int idCivis) {
            if (idCivis < 0 || idCivis >= _longitudo) {
                return;
            }
            if (!_anchorae[idCivis].EstEns) {
                return;
            }
            _anchorae[idCivis].Spirituare();
            foreach (IOperatioCivisGenerationis operatio in _operationumCivisGenerationis) {
                operatio.ExecutareSpirituare(idCivis);
            }
        }

        public int LongitudoManifestationes() {
            int longitudo = 0;
            for (int i = 0; i < _longitudo; i++) {
                if (
                    _anchorae[i].EstEns ||
                    _anchorae[i].EstManifestatum
                ) longitudo++;
            }
            return longitudo;
        }
    }
}
