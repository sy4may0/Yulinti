using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;
using System.Collections.Generic;

namespace Yulinti.Officia.Ministeria {
    internal sealed class MinisteriumCivis : IMinisteriumIncipabilis {
        private readonly TabulaCivis _tabulaCivis;
        private readonly IReadOnlyList<IOperatioCivisGenerationis> _operationum;
        private bool[] _estActivumTemporarium;

        public MinisteriumCivis(
            TabulaCivis tabulaCivis, 
            IReadOnlyList<IOperatioCivisGenerationis> operationum
        ) {
            _tabulaCivis = tabulaCivis;
            _operationum = operationum;
            _estActivumTemporarium = new bool[tabulaCivis.Longitudo];
        }

        public int[] IDs => _tabulaCivis.IDs;
        public int Longitudo => _tabulaCivis.Longitudo;
        public int LongitudoActivum => longitudoActivum();
        public bool EstActivum(int id) => estActivum(id);
        public bool[] EstActivumOmne => estActivumOmne();

        // IMinisteriumIncipabilis
        // 全CivisをManifestatioする。
        public void Incipere() {
            _tabulaCivis.Initiare();
        }

        public void Incarnare(int id) {
            if (id < 0 || id >= _tabulaCivis.Longitudo) return;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return;
            anchora.Incarnare();
            foreach (IOperatioCivisGenerationis operatio in _operationum) {
                operatio.ExecutareIncarnare(id);
            }
        }

        public void Spirituare(int id) {
            if (id < 0 || id >= _tabulaCivis.Longitudo) return;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return;
            anchora.Spirituare();
            foreach (IOperatioCivisGenerationis operatio in _operationum) {
                operatio.ExecutareSpirituare(id);
            }
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

        private bool[] estActivumOmne() {
            for (int i = 0; i < Longitudo; i++) {
                _estActivumTemporarium[i] = estActivum(i);
            }
            return _estActivumTemporarium;
        }
    }
}