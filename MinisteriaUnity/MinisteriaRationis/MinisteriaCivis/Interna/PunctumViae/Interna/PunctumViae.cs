using UnityEngine;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class PunctumViae {
        private IAnchoraPunctumViae _anchoraPunctumViae;

        private bool _estActivum = false;
        private IResolvorPunctumViae _resolvorPunctumViae;
        private TabulaPunctumViae _tabulaPunctumViae;
        private PunctumViae[] _arcaPunctorum = null;

        public IDPunctumViaeTypi Typus => _anchoraPunctumViae.Typus;
        public bool EstActivum => _estActivum;
        public Vector3 Positio => _anchoraPunctumViae.Positio;

        public PunctumViae(
            IAnchoraPunctumViae anchoraPunctumViae,
            IResolvorPunctumViae resolvorPunctumViae,
            TabulaPunctumViae tabulaPunctumViae
        ) {
            _anchoraPunctumViae = anchoraPunctumViae;
            _resolvorPunctumViae = resolvorPunctumViae;
            _tabulaPunctumViae = tabulaPunctumViae;
        }

        public void Activare() {
            _estActivum = true;
        }

        public void Deactivare() {
            _estActivum = false;
        }

        public ErrorAut<PunctumViae> Resolvo(PunctumViae pAntecedens) {
            if (_arcaPunctorum == null) {
                _arcaPunctorum = _tabulaPunctumViae.IacereOrdinem(_anchoraPunctumViae.PunctaViaeConsequens);
            }
            return _resolvorPunctumViae.Resolvo(pAntecedens, _arcaPunctorum);
        }

        public void Initio() {
            _arcaPunctorum = _tabulaPunctumViae.IacereOrdinem(_anchoraPunctumViae.PunctaViaeConsequens);
            Activare();
        }
    }
}



