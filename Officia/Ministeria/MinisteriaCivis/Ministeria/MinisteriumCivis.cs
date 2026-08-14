using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using System;

namespace Yulinti.Officia.Ministeria {
    internal sealed class MinisteriumCivis : IMinisteriumIncipabilis {
        private readonly LacusAnchorarumCivis _lacusAnchorarumCivis;
        private readonly TabulaCivisSchemarum _tabulaCivisSchemarum;
        private bool[] _estActivumTemporarium;
        private readonly Random _random;

        public MinisteriumCivis(
            LacusAnchorarumCivis lacusAnchorarumCivis,
            IConfiguratioCivisSchemarum configSchemarum,
            Random random
        ) {
            _lacusAnchorarumCivis = lacusAnchorarumCivis;
            _estActivumTemporarium = new bool[_lacusAnchorarumCivis.Longitudo];
            _tabulaCivisSchemarum = new TabulaCivisSchemarum(configSchemarum.Schemarum);
            _random = random;
        }

        public int Longitudo => _lacusAnchorarumCivis.Longitudo;
        public int LongitudoActivum => longitudoActivum();
        public int LongitudoManifestationes => longitudoManifestationes();
        public bool EstActivum(int id) => _lacusAnchorarumCivis.EstActivum(id);
        public bool[] EstActivumOmne => estActivumOmne();

        public void Incipere() {
        }

        public void Incarnare(int id) {
            _lacusAnchorarumCivis.Incarnare(id);
        }

        public void Spirituare(int id) {
            _lacusAnchorarumCivis.Spirituare(id);
        }

        public void Manifestatio(IDCivisPersonae idCivisPersonae) {
            // Schemaを選択する。
            AssetReferenceGameObject schema = _tabulaCivisSchemarum.LegereTemere(idCivisPersonae, _random);
            if (schema == null) {
                Notarius.Memorare(LogTextus.TabulaCivisSchemarum_TABULACIVISSCHEMARUM_SCHEMA_NOT_FOUND);
                return;
            }
            // Fire and Forget
            _lacusAnchorarumCivis.ManifestatioAsync(idCivisPersonae, schema)
                .Forget(e => Notarius.Memorare(e));
        }

        public void Deleto(int id) {
            _lacusAnchorarumCivis.Deleto(id);
        }

        // 非実体化ID(Incarnareされていない者)を取得
        public int LegoIDIntactus() {
            int id = -1;
            for (int i = 0; i < _lacusAnchorarumCivis.Longitudo; i++) {
                if (!_lacusAnchorarumCivis.ConareLego(i, out IAnchoraCivis anchora)) continue;
                if (!anchora.EstSpiritus) continue;
                id = i;
                break;
            }
            return id;
        }

        private bool estActivum(int id) {
            if (id < 0 || id >= _lacusAnchorarumCivis.Longitudo) return false;
            if (!_lacusAnchorarumCivis.ConareLego(id, out IAnchoraCivis anchora)) return false;
            if (!anchora.EstActivum) return false;
            return true;
        }

        private int longitudoActivum() {
            int longitudo = 0;
            for (int i = 0; i < _lacusAnchorarumCivis.Longitudo; i++) {
                if (estActivum(i)) longitudo++;
            }
            return longitudo;
        }

        private int longitudoManifestationes() {
            return _lacusAnchorarumCivis.LongitudoManifestationes();
        }

        private bool[] estActivumOmne() {
            for (int i = 0; i < Longitudo; i++) {
                _estActivumTemporarium[i] = estActivum(i);
            }
            return _estActivumTemporarium;
        }
    }
}
