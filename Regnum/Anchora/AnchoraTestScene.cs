using Yulinti.Nucleus.Instrumentarium;
using UnityEngine;
using Yulinti.Nucleus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Regnum.Anchora {
    [System.Serializable]
    public sealed class AnchoraTestScene {
        [SerializeField] private AnchoraCamera _anchoraCamera;
        [SerializeField] private AnchoraInput _anchoraInput;
        [SerializeField] private AnchoraPuellae _anchoraPuellae;
        [SerializeField] private AnchoraPuellaeCrinis[] _anchoraPuellaeCrinis;
        [SerializeField] private AnchoraPunctumViae[] _anchoraPunctumViae;
        [SerializeField] private AnchoraCivis[] _anchoraCivis;

        public AnchoraCamera AnchoraCamera => _anchoraCamera;
        public AnchoraInput AnchoraInput => _anchoraInput;
        public AnchoraPuellae AnchoraPuellae => _anchoraPuellae;
        public AnchoraPuellaeCrinis[] AnchoraPuellaeCrinis => _anchoraPuellaeCrinis;
        public AnchoraPunctumViae[] AnchoraPunctumViae => _anchoraPunctumViae;
        public AnchoraCivis[] AnchoraCivis => _anchoraCivis;

        public void Resolvo() {
            if (_anchoraCamera == null) {
                Notarius.Memorare(LogTextus.AnchoraTestScene_REX_ANCHORA_NOT_SET);
            }

            if (_anchoraInput == null) {
                Notarius.Memorare(LogTextus.AnchoraTestScene_REX_ANCHORA_NOT_SET);
            }

            if (_anchoraPuellae == null) {
                Notarius.Memorare(LogTextus.AnchoraTestScene_REX_ANCHORA_NOT_SET);
            }

            if (_anchoraPuellaeCrinis == null) {
                Notarius.Memorare(LogTextus.AnchoraTestScene_REX_ANCHORA_NOT_SET);
            }

            if (_anchoraPunctumViae == null) {
                Notarius.Memorare(LogTextus.AnchoraTestScene_REX_ANCHORA_NOT_SET);
            }

            if (_anchoraCivis == null) {
                Notarius.Memorare(LogTextus.AnchoraTestScene_REX_ANCHORA_NOT_SET);
            }
        }

        public void Validare() {
            if (_anchoraCamera == null ||
                _anchoraInput == null ||
                _anchoraPuellae == null ||
                _anchoraPuellaeCrinis == null ||
                _anchoraPunctumViae == null ||
                _anchoraCivis == null) {
                Carnifex.Intermissio(LogTextus.AnchoraTestScene_REX_ANCHORA_RESOLVE_FAILED);
                return;
            }

            _anchoraCamera.Validare();
            _anchoraInput.Validare();
            _anchoraPuellae.Validare();

            foreach (var item in _anchoraPuellaeCrinis) {
                if (item != null) {
                    item.Validare();
                }
            }

            foreach (var item in _anchoraPunctumViae) {
                if (item != null) {
                    item.Validare();
                }
            }

            foreach (var item in _anchoraCivis) {
                if (item != null) {
                    item.Validare();
                }
            }
        }
    }
}
