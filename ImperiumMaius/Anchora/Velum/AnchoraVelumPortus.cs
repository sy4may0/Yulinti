using UnityEngine;
using Yulinti.Officia.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using UnityEngine.UIElements;

namespace Yulinti.ImperiumMaius.Anchora {
    public class AnchoraVelumPortus : MonoBehaviour, IAnchoraVelumPortus {
        [SerializeField] private UIDocument _uiDocument;
    
        public UIDocument UIDocument => _uiDocument;
    
        public bool Validare() {
            if (_uiDocument == null) {
                Carnifex.Intermissio(LogTextus.AnchoraVelumPortus_ANCHORAVELUMPORTUS_UIDOCUMENT_NULL);
                return false;
            }
            return true;
        }
    }
}