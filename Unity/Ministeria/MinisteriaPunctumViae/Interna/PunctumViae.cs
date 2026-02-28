using Yulinti.Exercitus.Contractus;
using Yulinti.Nucleus;
using UnityEngine;
using Yulinti.Unity.Contractus;

namespace Yulinti.Unity.Ministeria {
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