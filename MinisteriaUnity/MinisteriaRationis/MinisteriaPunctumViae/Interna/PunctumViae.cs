using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;
using UnityEngine;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class PunctumViae {
        private readonly int _id;
        private readonly IAnchoraPunctumViae _anchoraPunctumViae;
        private bool _estActivum = true;

        public PunctumViae(int id, IAnchoraPunctumViae anchoraPunctumViae) {
            _id = id;
            _anchoraPunctumViae = anchoraPunctumViae;
        }

        public int ID => _id;
        public IDPunctumViaeTypi Typus => _anchoraPunctumViae.Typus;
        public Vector3 Positio => _anchoraPunctumViae.Positio;

        public bool EstActivum => _estActivum;

        public void Activare() {
            _estActivum = true;
        }

        public void Deactivare() {
            _estActivum = false;
        }
    }
}