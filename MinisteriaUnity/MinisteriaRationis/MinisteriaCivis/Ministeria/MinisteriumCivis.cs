using UnityEngine;
using Cysharp.Threading.Tasks;
using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumCivis {
        private readonly TabulaCivis _tabulaCivis;
        private bool[] _estServam;

        public MinisteriumCivis(TabulaCivis tabulaCivis, IConfiguratioCivisGenerator configuratio) {
            _tabulaCivis = tabulaCivis;
            _estServam = new bool[tabulaCivis.Longitudo];
            for (int id = 0; id < tabulaCivis.Longitudo; id++) {
                _estServam[id] = false;
            }
        }

        public int[] IDs => _tabulaCivis.IDs;
        public int Longitudo => _tabulaCivis.Longitudo;
        public int LongitudoActivum => longitudoActivum();
        public bool EstActivum(int id) => estActivum(id);
        public bool EstServam(int id) => _estServam[id];

        public void Dominare(int id) {
            if (id < 0 || id >= _tabulaCivis.Longitudo) return;
            _estServam[id] = true;
        }

        public void Liberare(int id) {
            if (id < 0 || id >= _tabulaCivis.Longitudo) return;
            _estServam[id] = false;
        }

        public void Incarnare(int id) {
            if (id < 0 || id >= _tabulaCivis.Longitudo) return;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return;
            anchora.Incarnare();
        }

        public void Spirituare(int id) {
            if (id < 0 || id >= _tabulaCivis.Longitudo) return;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return;
            anchora.Spirituare();
        }

        // 非実体化ID(Incarnareされていない者)を取得
        public int LegoIDIntactus() {
            int id = -1;
            for (int i = 0; i < _tabulaCivis.Longitudo; i++) {
                if (!_tabulaCivis.ConareLego(i, out IAnchoraCivis anchora)) continue;
                if (anchora.EstActivum) continue;
                id = i;
                break;
            }
            return id;
        }

        private bool estActivum(int id) {
            if (id < 0 || id >= _tabulaCivis.Longitudo) return false;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return false;
            if (!anchora.EstActivum) return false;
            return true;
        }

        private int longitudoActivum() {
            int longitudo = 0;
            for (int i = 0; i < _tabulaCivis.Longitudo; i++) {
                if (estActivum(i)) longitudo++;
            }
            return longitudo;
        }
    }
}