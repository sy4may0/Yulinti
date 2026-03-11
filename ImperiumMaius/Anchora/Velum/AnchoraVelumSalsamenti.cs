using UnityEngine;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using UnityEngine.UIElements;

namespace Yulinti.ImperiumMaius.Anchora {
    public class AnchoraVelumSalsamenti : MonoBehaviour, IAnchoraVelumSalsamenti {
        [SerializeField] private UIDocument _uiDocument;
        [SerializeField] private VisualTreeAsset _formaArticulusSalsamenti;

        public UIDocument UIDocument => _uiDocument;
        public VisualTreeAsset FormaArticulusSalsamenti => _formaArticulusSalsamenti;

        public bool Validare() {
            if (_uiDocument == null) {
                Carnifex.Intermissio(LogTextus.AnchoraVelumSalsamenti_ANCHORAVELUMSALSAMENTI_UIDOCUMENT_NULL);
                return false;
            }

            if (_formaArticulusSalsamenti == null) {
                Carnifex.Intermissio(LogTextus.AnchoraVelumSalsamenti_ANCHORAVELUMSALSAMENTI_FORMAARTICULUSSALSAMENTI_NULL);
                return false;
            }

            return true;
        }
    }
}