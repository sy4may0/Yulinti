using Yulinti.ImperiumDelegatum.Contractus;
using UnityEngine;
using UnityEngine.InputSystem;
using Yulinti.Officia.Contractus;
using Yulinti.Officia.Instrumentarium;

namespace Yulinti.Officia.Turris {
    internal sealed class TurrisIntroductionis : ITurrisIntroductionis {
        //// Motus ////
        private readonly InputAction _moveInput;
        private readonly InputAction _sprintInput;
        private readonly InputAction _crouchInput;

        //// Velum ////
        private readonly InputAction _clickInput;
        private readonly InputAction _clickRightInput;
        private readonly InputAction _submitInput;
        private readonly InputAction _cancelInput;
        private readonly InputAction _navigateInput;

        //// Action ////
        private readonly InputAction _spectaculumCorporisInput;

        public TurrisIntroductionis(IAnchoraInput anchoraInput) {
            _moveInput = anchoraInput.MoveInput.action;
            _sprintInput = anchoraInput.SprintInput.action;
            _crouchInput = anchoraInput.CrouchInput.action;

            _clickInput = anchoraInput.ClickInput.action;
            _clickRightInput = anchoraInput.ClickRightInput.action;
            _submitInput = anchoraInput.SubmitInput.action;
            _cancelInput = anchoraInput.CancelInput.action;
            _navigateInput = anchoraInput.NavigateInput.action;

            _spectaculumCorporisInput = anchoraInput.SpectaculumCorporisInput.action;
        }

        public System.Numerics.Vector2 LegoMotus => _moveInput?.enabled == true 
            ? InterpresNumeri.ToNumerics(_moveInput.ReadValue<Vector2>()) :
            new System.Numerics.Vector2(0f, 0f);
        public bool LegoCursus => _sprintInput?.enabled == true && _sprintInput.IsPressed();
        public bool LegoIncumbo => _crouchInput?.enabled == true && _crouchInput.IsPressed();

        public bool LegoClick => _clickInput?.enabled == true && _clickInput.WasPressedThisFrame();
        public bool LegoClickRight => _clickRightInput?.enabled == true && _clickRightInput.WasPressedThisFrame();
        public bool LegoSubmit => _submitInput?.enabled == true && _submitInput.WasPressedThisFrame();
        public bool LegoCancel => _cancelInput?.enabled == true && _cancelInput.WasPressedThisFrame();
        public System.Numerics.Vector2 LegoNavigate => _navigateInput?.enabled == true 
            ? InterpresNumeri.ToNumerics(_navigateInput.ReadValue<Vector2>()) :
            new System.Numerics.Vector2(0f, 0f);

        public bool LegoSpectaculumCorporis => _spectaculumCorporisInput?.enabled == true && _spectaculumCorporisInput.WasPressedThisFrame();

        public void DebugEnabled() {
            UnityEngine.Debug.Log($"_moveInput.action.enabled={_moveInput.enabled}");
            UnityEngine.Debug.Log($"_sprintInput.action.enabled={_sprintInput.enabled}");
            UnityEngine.Debug.Log($"_crouchInput.action.enabled={_crouchInput.enabled}");
            UnityEngine.Debug.Log($"_clickInput.action.enabled={_clickInput.enabled}");
            UnityEngine.Debug.Log($"_clickRightInput.action.enabled={_clickRightInput.enabled}");
            UnityEngine.Debug.Log($"_submitInput.action.enabled={_submitInput.enabled}");
            UnityEngine.Debug.Log($"_cancelInput.action.enabled={_cancelInput.enabled}");
            UnityEngine.Debug.Log($"_navigateInput.action.enabled={_navigateInput.enabled}");
        }
    }
}
