using UnityEngine;
using Yulinti.Unity.Contractus;
using Yulinti.Nucleus.Contractus;
using Yulinti.Nucleus.Instrumentarium;
using UnityEngine.UIElements;

namespace Yulinti.Regnum.Anchora {
    public class AnchoraVelumRadicis : MonoBehaviour, IAnchoraVelumRadicis {
        [SerializeField] private UIDocument _uiNotati;
        [SerializeField] private UIDocument _uiErroris;
        [SerializeField] private UIDocument _uiIntermissionis;

        public UIDocument UINotati => _uiNotati;
        public UIDocument UIErroris => _uiErroris;
        public UIDocument UIIntermissionis => _uiIntermissionis;

        public bool Validare() {
            if (_uiNotati == null) {
                Carnifex.Intermissio(LogTextus.AnchoraVelumRadicis_ANCHORAVELUMRADICIS_UINOTATI_NULL);
                return false;
            }
            if (_uiErroris == null) {
                Carnifex.Intermissio(LogTextus.AnchoraVelumRadicis_ANCHORAVELUMRADICIS_UIERRORIS_NULL);
                return false;
            }
            if (_uiIntermissionis == null) {
                Carnifex.Intermissio(LogTextus.AnchoraVelumRadicis_ANCHORAVELUMRADICIS_UIINTERMISSIONIS_NULL);
                return false;
            }
            return true;
        }
    }
}