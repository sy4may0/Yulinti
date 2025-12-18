using UnityEngine;
using Cysharp.Threading.Tasks;
using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumCivis {
        private int _id;
        private IAnchoraCivis _anchora;

        public MinisteriumCivis(int id, IAnchoraCivis anchora) {
            _id = id;
            _anchora = anchora;
        }

        public void Creare() {
            CreareAsync().Forget(e => Memorator.MemorareException(e));
        }

        private async UniTask CreareAsync() {
            await _anchora.Manifestatio();
            bool ex = _anchora.ValidareManifestatio();

            if (!ex) {
                _anchora.Deleto();
                Memorator.MemorareErrorum(IDErrorum.CIVIS_INSTANTIATE_FAILED);
            }
        }

        public void Destuere() {
            _anchora.Deleto();
        }

        public void Incarnare() {
            _anchora.Incarnare();
        }

        public void Spirituare() {
            _anchora.Spirituare();
        }

        public int ID => _id;
        public bool EstActivum => _anchora.EstActivum;

    }
}