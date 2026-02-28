using Yulinti.Exercitus.Contractus;
using UnityEngine;
using UnityEngine.InputSystem;
using Yulinti.Unity.Contractus;
using Yulinti.Unity.Instrumentarium;

namespace Yulinti.Unity.Turris {
    internal sealed class TurrisIntroductionis : ITurrisIntroductionis {
        //// Motus ////
        private readonly InputActionReference _moveInput;
        private readonly InputActionReference _sprintInput;
        private readonly InputActionReference _crouchInput;

        //// Velum ////
        private readonly InputActionReference _clickInput;
        private readonly InputActionReference _clickRightInput;
        private readonly InputActionReference _submitInput;
        private readonly InputActionReference _cancelInput;
        private readonly InputActionReference _navigateInput;

        public TurrisIntroductionis(IAnchoraInput anchoraInput) {
            _moveInput = anchoraInput.MoveInput;
            _sprintInput = anchoraInput.SprintInput;
            _crouchInput = anchoraInput.CrouchInput;

            _clickInput = anchoraInput.ClickInput;
            _clickRightInput = anchoraInput.ClickRightInput;
            _submitInput = anchoraInput.SubmitInput;
            _cancelInput = anchoraInput.CancelInput;
            _navigateInput = anchoraInput.NavigateInput;

        }

        public System.Numerics.Vector2 LegoMotus => _moveInput?.action?.enabled == true 
            ? InterpressNumericus.ToNumerics(_moveInput.action.ReadValue<Vector2>()) :
            new System.Numerics.Vector2(0f, 0f);
        public bool LegoCursus => _sprintInput?.action?.enabled == true && _sprintInput.action.IsPressed();
        public bool LegoIncumbo => _crouchInput?.action?.enabled == true && _crouchInput.action.IsPressed();

        public bool LegoClick => _clickInput?.action?.enabled == true && _clickInput.action.IsPressed();
        public bool LegoClickRight => _clickRightInput?.action?.enabled == true && _clickRightInput.action.IsPressed();
        public bool LegoSubmit => _submitInput?.action?.enabled == true && _submitInput.action.IsPressed();
        public bool LegoCancel => _cancelInput?.action?.enabled == true && _cancelInput.action.IsPressed();
        public bool LegoNavigate => _navigateInput?.action?.enabled == true && _navigateInput.action.IsPressed();

        public void DebugEnabled() {
            UnityEngine.Debug.Log($"_moveInput.action.enabled={_moveInput.action.enabled}");
            UnityEngine.Debug.Log($"_sprintInput.action.enabled={_sprintInput.action.enabled}");
            UnityEngine.Debug.Log($"_crouchInput.action.enabled={_crouchInput.action.enabled}");
            UnityEngine.Debug.Log($"_clickInput.action.enabled={_clickInput.action.enabled}");
            UnityEngine.Debug.Log($"_clickRightInput.action.enabled={_clickRightInput.action.enabled}");
            UnityEngine.Debug.Log($"_submitInput.action.enabled={_submitInput.action.enabled}");
            UnityEngine.Debug.Log($"_cancelInput.action.enabled={_cancelInput.action.enabled}");
            UnityEngine.Debug.Log($"_navigateInput.action.enabled={_navigateInput.action.enabled}");
        }
    }
}
