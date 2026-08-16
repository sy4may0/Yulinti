using UnityEngine;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.ImperiumMaius.Anchora {
    [System.Serializable]
    public sealed class AnchoraVelumPuellaeVeletudinis {
        [SerializeField] private AnchoraVelumSpatiiPuellaeVeletudinis _anchoraVelumSpatiiPuellaeVeletudinis;

        public AnchoraVelumSpatiiPuellaeVeletudinis AnchoraVelumSpatiiPuellaeVeletudinis => _anchoraVelumSpatiiPuellaeVeletudinis;

        public void Validare() {
            if (_anchoraVelumSpatiiPuellaeVeletudinis == null) {
                Carnifex.Intermissio(LogTextus.AnchoraVelumPuellaeVeletudinis_ANCHORAVELUMPUELLAEVELETDUNIS_RESOLVE_FAILED);
                return;
            }

            if (!_anchoraVelumSpatiiPuellaeVeletudinis.Validare()) {
                Carnifex.Intermissio(LogTextus.AnchoraVelumPuellaeVeletudinis_ANCHORAVELUMPUELLAEVELETDUNIS_VALIDATE_FAILED);
                return;
            }

        }

    }
}
