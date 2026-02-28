using UnityEngine;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using UnityEngine.UIElements;

namespace Yulinti.Regnum.Anchora {
    public class AnchoraVelumRadicis : MonoBehaviour, IAnchoraVelumRadicis {
        [SerializeField] private UIDocument _uiConfirmationis;
        [SerializeField] private UIDocument _uiMonitionis;

        public UIDocument UIConfirmationis => _uiConfirmationis;
        public UIDocument UIMonitionis => _uiMonitionis;

        public bool Validare() {
            if (_uiConfirmationis == null) {
                Carnifex.Intermissio(LogTextus.AnchoraVelumRadicis_ANCHORAVELUMRADICIS_UICONFIRMATIONIS_NULL);
                return false;
            }
            if (_uiMonitionis == null) {
                Carnifex.Intermissio(LogTextus.AnchoraVelumRadicis_ANCHORAVELUMRADICIS_UIMONITIONIS_NULL);
                return false;
            }
            return true;
        }
    }
}