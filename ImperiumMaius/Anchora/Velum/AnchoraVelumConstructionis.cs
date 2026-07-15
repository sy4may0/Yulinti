using UnityEngine;
using Yulinti.Officia.Contractus;
using UnityEngine.UIElements;

namespace Yulinti.ImperiumMaius.Anchora {
    public class AnchoraVelumConstructionis : MonoBehaviour, IAnchoraVelumConstructionis {
        [SerializeField] private UIDocument _uiDocument;
        [SerializeField] private VisualTreeAsset _elementumLapsorCorporis;
        [SerializeField] private VisualTreeAsset _elementumLapsorFaciei;
        [SerializeField] private VisualTreeAsset _elementumSubligaculi;
        [SerializeField] private VisualTreeAsset _elementumTunicae;
        [SerializeField] private VisualTreeAsset _elementumOrnamenti;
        [SerializeField] private VisualTreeAsset _elementumSalsamenti;

        public UIDocument UIDocument => _uiDocument;
        public VisualTreeAsset ElementumLapsorCorporis => _elementumLapsorCorporis;
        public VisualTreeAsset ElementumLapsorFaciei => _elementumLapsorFaciei;
        public VisualTreeAsset ElementumSubligaculi => _elementumSubligaculi;
        public VisualTreeAsset ElementumTunicae => _elementumTunicae;
        public VisualTreeAsset ElementumOrnamenti => _elementumOrnamenti;
        public VisualTreeAsset ElementumSalsamenti => _elementumSalsamenti;
    }
}