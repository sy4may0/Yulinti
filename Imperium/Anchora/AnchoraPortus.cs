using Yulinti.Nucleus.Instrumentarium;
using UnityEngine;
using Yulinti.Nucleus.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.Imperium.Anchora {
    public sealed class AnchoraPortus : MonoBehaviour {
        [SerializeField] private AnchoraCamera _anchoraCamera;
        [SerializeField] private AnchoraPuellae _anchoraPuellae;
        [SerializeField] private AnchoraPuellaeCrinis[] _anchoraPuellaeCrinis;

        public AnchoraCamera AnchoraCamera => _anchoraCamera;
        public AnchoraPuellae AnchoraPuellae => _anchoraPuellae;
        public AnchoraPuellaeCrinis[] AnchoraPuellaeCrinis => _anchoraPuellaeCrinis;

        public void Resolvo() {
            if (_anchoraCamera == null) {
                Notarius.Memorare(LogTextus.AnchoraPortus_ANCHORAPORTUS_ANCHORACAMERA_NULL);
            }
            if (_anchoraPuellae == null) {
                Notarius.Memorare(LogTextus.AnchoraPortus_ANCHORAPORTUS_ANCHORAPUELLAE_NULL);
            }
            if (_anchoraPuellaeCrinis == null) {
                Notarius.Memorare(LogTextus.AnchoraPortus_ANCHORAPORTUS_ANCHORAPUELLAECRINIS_NULL);
            }
        }

        public void Validare() {
            if (_anchoraCamera == null ||
                _anchoraPuellae == null ||
                _anchoraPuellaeCrinis == null) {
                Carnifex.Intermissio(LogTextus.AnchoraPortus_ANCHORAPORTUS_RESOLVE_FAILED);
                return;
            }

            _anchoraCamera.Validare();
            _anchoraPuellae.Validare();
            foreach (var item in _anchoraPuellaeCrinis) {
                if (item != null) {
                    item.Validare();
                }
            }
        }
    }
}