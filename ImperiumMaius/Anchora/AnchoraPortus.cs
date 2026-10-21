using Yulinti.Nucleus.Instrumentarium;
using UnityEngine;
using Yulinti.Nucleus.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Anchora {
    public sealed class AnchoraPortus : MonoBehaviour {
        [SerializeField] private AnchoraCamera _anchoraCamera;
        [SerializeField] private AnchoraPuellae _anchoraPuellae;
        [SerializeField] private AnchoraPuellaeCrinisBasis[] _anchoraPuellaeCrinisBasis;
        [SerializeField] private AnchoraPuellaeCrinisPosterior[] _anchoraPuellaeCrinisPosterior;
        [SerializeField] private AnchoraPuellaeCrinisAnterior[] _anchoraPuellaeCrinisAnterior;

        public AnchoraCamera AnchoraCamera => _anchoraCamera;
        public AnchoraPuellae AnchoraPuellae => _anchoraPuellae;
        public AnchoraPuellaeCrinisBasis[] AnchoraPuellaeCrinisBasis => _anchoraPuellaeCrinisBasis;
        public AnchoraPuellaeCrinisPosterior[] AnchoraPuellaeCrinisPosterior => _anchoraPuellaeCrinisPosterior;
        public AnchoraPuellaeCrinisAnterior[] AnchoraPuellaeCrinisAnterior => _anchoraPuellaeCrinisAnterior;

        public void Resolvo() {
            if (_anchoraCamera == null) {
                Notarius.Memorare(LogTextus.AnchoraPortus_ANCHORAPORTUS_ANCHORACAMERA_NULL);
            }
            if (_anchoraPuellae == null) {
                Notarius.Memorare(LogTextus.AnchoraPortus_ANCHORAPORTUS_ANCHORAPUELLAE_NULL);
            }
            if (_anchoraPuellaeCrinisBasis == null) {
                Notarius.Memorare(LogTextus.AnchoraPortus_ANCHORAPORTUS_ANCHORAPUELLAECRINISBASIS_NULL);
            }
            if (_anchoraPuellaeCrinisPosterior == null) {
                Notarius.Memorare(LogTextus.AnchoraPortus_ANCHORAPORTUS_ANCHORAPUELLAECRINISPOSTERIOR_NULL);
            }
            if (_anchoraPuellaeCrinisAnterior == null) {
                Notarius.Memorare(LogTextus.AnchoraPortus_ANCHORAPORTUS_ANCHORAPUELLAECRINISANTERIOR_NULL);
            }
        }

        public void Validare() {
            if (_anchoraCamera == null ||
                _anchoraPuellae == null ||
                _anchoraPuellaeCrinisBasis == null ||
                _anchoraPuellaeCrinisPosterior == null ||
                _anchoraPuellaeCrinisAnterior == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPortus_ANCHORAPORTUS_RESOLVE_FAILED);
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
        }
    }
}