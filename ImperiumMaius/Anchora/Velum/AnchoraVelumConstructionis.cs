using UnityEngine;
using Yulinti.Officia.Contractus;
using UnityEngine.UIElements;

namespace Yulinti.ImperiumMaius.Anchora {
    public class AnchoraVelumConstructionis : MonoBehaviour, IAnchoraVelumConstructionis {
        [SerializeField] private UIDocument _uiDocument;
        [SerializeField] private VisualTreeAsset _formaLapsorCorporis;

        public UIDocument UIDocument => _uiDocument;
        public VisualTreeAsset FormaLapsorCorporis => _formaLapsorCorporis;
    }
}