using UnityEngine;
using Cysharp.Threading.Tasks;
using System;
using Yulinti.Dux.ContractusDucis;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumCivis {
        private readonly TabulaCivis _tabulaCivis;

        private bool _estPonoAdIncarnare;
        private bool _estPonoAdSpirituare;
        private Action<int> _adIncarnare;
        private Action<int> _adSpirituare;

        public MinisteriumCivis(TabulaCivis tabulaCivis, IConfiguratioCivisGenerator configuratio) {
            _tabulaCivis = tabulaCivis;
            _adIncarnare = null;
            _adSpirituare = null;
            _estPonoAdIncarnare = false;
            _estPonoAdSpirituare = false;
        }

        public int[] IDs => _tabulaCivis.IDs;
        public int Longitudo => _tabulaCivis.Longitudo;
        public int LongitudoActivum => longitudoActivum();
        public bool EstActivum(int id) => estActivum(id);

        public void Incarnare(int id) {
            if (id < 0 || id >= _tabulaCivis.Longitudo) return;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return;
            anchora.Incarnare();
            _adIncarnare?.Invoke(id);
        }

        public void Spirituare(int id) {
            if (id < 0 || id >= _tabulaCivis.Longitudo) return;
            if (!_tabulaCivis.ConareLego(id, out IAnchoraCivis anchora)) return;
            anchora.Spirituare();
            _adSpirituare?.Invoke(id);
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

        public void PonoAdIncarnare(Action<int> adIncarnare) {
            if (_estPonoAdIncarnare) {
                Errorum.Fatal(IDErrorum.CIVIS_ADINCARNARE_ALREADY_SET);
            }
            _adIncarnare = adIncarnare;
            _estPonoAdIncarnare = true;
        }
        public void PonoAdSpirituare(Action<int> adSpirituare) {
            if (_estPonoAdSpirituare) {
                Errorum.Fatal(IDErrorum.CIVIS_ADSPIRITUARE_ALREADY_SET);
            }
            _adSpirituare = adSpirituare;
            _estPonoAdSpirituare = true;
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