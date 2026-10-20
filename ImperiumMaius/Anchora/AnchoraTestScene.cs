using Yulinti.Nucleus.Instrumentarium;
using UnityEngine;
using Yulinti.Nucleus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumMaius.Anchora {
    [System.Serializable]
    public sealed class AnchoraTestScene {
        [SerializeField] private AnchoraCamera _anchoraCamera;
        [SerializeField] private AnchoraPuellae _anchoraPuellae;
        [SerializeField] private AnchoraPuellaeCrinisBasis[] _anchoraPuellaeCrinisBasis;
        [SerializeField] private AnchoraPuellaeCrinisPosterior[] _anchoraPuellaeCrinisPosterior;
        [SerializeField] private AnchoraPuellaeCrinisAnterior[] _anchoraPuellaeCrinisAnterior;
        [SerializeField] private AnchoraPunctumViae[] _anchoraPunctumViae;
        [SerializeField] private AnchoraCivis[] _anchoraCivis;

        public AnchoraCamera AnchoraCamera => _anchoraCamera;
        public AnchoraPuellae AnchoraPuellae => _anchoraPuellae;
        public AnchoraPuellaeCrinisBasis[] AnchoraPuellaeCrinisBasis => _anchoraPuellaeCrinisBasis;
        public AnchoraPuellaeCrinisPosterior[] AnchoraPuellaeCrinisPosterior => _anchoraPuellaeCrinisPosterior;
        public AnchoraPuellaeCrinisAnterior[] AnchoraPuellaeCrinisAnterior => _anchoraPuellaeCrinisAnterior;
        public AnchoraPunctumViae[] AnchoraPunctumViae => _anchoraPunctumViae;
        public AnchoraCivis[] AnchoraCivis => _anchoraCivis;

        public void Resolvo() {
            if (_anchoraCamera == null) {
                Notarius.Memorare(LogTextus.AnchoraTestScene_REX_ANCHORA_NOT_SET);
            }

            if (_anchoraPuellae == null) {
                Notarius.Memorare(LogTextus.AnchoraTestScene_REX_ANCHORA_NOT_SET);
            }

            if (_anchoraPuellaeCrinisBasis == null) {
                Notarius.Memorare(LogTextus.AnchoraTestScene_REX_ANCHORA_NOT_SET);
            }

            if (_anchoraPuellaeCrinisPosterior == null) {
                Notarius.Memorare(LogTextus.AnchoraTestScene_REX_ANCHORA_NOT_SET);
            }

            if (_anchoraPuellaeCrinisAnterior == null) {
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
                _anchoraPuellae == null ||
                _anchoraPuellaeCrinisBasis == null ||
                _anchoraPuellaeCrinisPosterior == null ||
                _anchoraPuellaeCrinisAnterior == null ||
                _anchoraPunctumViae == null ||
                _anchoraCivis == null) {
                Carnifex.Intermissio(LogTextus.AnchoraTestScene_REX_ANCHORA_RESOLVE_FAILED);
                return;
            }

            _anchoraCamera.Validare();
            _anchoraPuellae.Validare();

            foreach (var item in _anchoraPuellaeCrinisBasis) {
                if (item != null) {
                    item.Validare();
                }
            }
            foreach (var item in _anchoraPuellaeCrinisPosterior) {
                if (item != null) {
                    item.Validare();
                }
            }
            foreach (var item in _anchoraPuellaeCrinisAnterior) {
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
