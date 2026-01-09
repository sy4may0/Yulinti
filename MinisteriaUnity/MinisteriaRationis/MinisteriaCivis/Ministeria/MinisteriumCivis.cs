using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumCivis {
        private readonly TabulaCivis _tabulaCivis;
        // Dirtyフラグ。Incarnare/Spirituareにより状態が変わったらfalse、処理したらtrue。
        private bool _estServam;

        private Action<int> _adIncarnare;
        private Action<int> _adSpirituare;

        public MinisteriumCivis(TabulaCivis tabulaCivis, IConfiguratioCivisGenerator configuratio) {
            _tabulaCivis = tabulaCivis;
            _adIncarnare = null;
            _adSpirituare = null;
        }

        public int[] IDs => _tabulaCivis.IDs;
        public int Longitudo => _tabulaCivis.Longitudo;
        public int LongitudoActivum => longitudoActivum();
        public bool EstActivum(int id) => estActivum(id);
        public bool EstServam => _estServam;

        public void Incarnare(int id) {
            if (id < 0 || id >= _tabulaCivis.Longitudo) return;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return;
            anchora.Incarnare();
            _adIncarnare?.Invoke(id);
            _estServam = false;
        }

        public void Spirituare(int id) {
            if (id < 0 || id >= _tabulaCivis.Longitudo) return;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return;
            anchora.Spirituare();
            _adSpirituare?.Invoke(id);
            _estServam = false;
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

        public void Servare() {
            _estServam = true;
        }

        public void PonoAdIncarnare(Action<int> adIncarnare) {
            _adIncarnare = adIncarnare;
        }
        public void PonoAdSpirituare(Action<int> adSpirituare) {
            _adSpirituare = adSpirituare;
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