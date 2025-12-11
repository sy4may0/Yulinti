using UnityEngine;
using Yulinti.MinisteriaUnity.Anchora;
using Yulinti.Nucleus;

namespace Yulinti.Rex {
    [System.Serializable]
    internal sealed class ResolvorAnchorae {
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
                var found = UnityEngine.Object.FindFirstObjectByType<AnchoraCamera>();
                if (found != null) {
                    _anchoraCamera = found;
                    Memorator.MemorareErrorum(IDErrorum.REX_ANCHORA_NOT_SET);
                }
            }

            if (_anchoraInput == null) {
                var found = UnityEngine.Object.FindFirstObjectByType<AnchoraInput>();
                if (found != null) {
                    _anchoraInput = found;
                    Memorator.MemorareErrorum(IDErrorum.REX_ANCHORA_NOT_SET);
                }
            }

            if (_anchoraPuellae == null) {
                var found = UnityEngine.Object.FindFirstObjectByType<AnchoraPuellae>();
                if (found != null) {
                    _anchoraPuellae = found;
                    Memorator.MemorareErrorum(IDErrorum.REX_ANCHORA_NOT_SET);
                }
            }

            if (_anchoraPuellaeCrinis == null) {
                var foundArray = UnityEngine.Object.FindObjectsByType<AnchoraPuellaeCrinis>(FindObjectsSortMode.None);
                if (foundArray != null && foundArray.Length > 0) {
                    _anchoraPuellaeCrinis = foundArray;
                    Memorator.MemorareErrorum(IDErrorum.REX_ANCHORA_NOT_SET);
                }
            }

            if (_anchoraPunctumViae == null) {
                var foundArray = UnityEngine.Object.FindObjectsByType<AnchoraPunctumViae>(FindObjectsSortMode.None);
                if (foundArray != null && foundArray.Length > 0) {
                    _anchoraPunctumViae = foundArray;
                    Memorator.MemorareErrorum(IDErrorum.REX_ANCHORA_NOT_SET);
                }
            }

            if (_anchoraCivis == null) {
                var foundArray = UnityEngine.Object.FindObjectsByType<AnchoraCivis>(FindObjectsSortMode.None);
                if (foundArray != null && foundArray.Length > 0) {
                    _anchoraCivis = foundArray;
                    Memorator.MemorareErrorum(IDErrorum.REX_ANCHORA_NOT_SET);
                }
            }
        }

        public void Validare() {
            if (_anchoraCamera == null ||
                _anchoraInput == null ||
                _anchoraPuellae == null ||
                _anchoraPuellaeCrinis == null ||
                _anchoraPunctumViae == null ||
                _anchoraCivis == null) {
                Errorum.Fatal(IDErrorum.REX_ANCHORA_RESOLVE_FAILED);
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
