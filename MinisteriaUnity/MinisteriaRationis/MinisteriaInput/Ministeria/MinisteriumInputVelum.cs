using UnityEngine;
using Yulinti.Dux.ContractusDucis;
using UnityEngine.InputSystem;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumInputVelum {
        private readonly InputActionReference _clickInput;
        private readonly InputActionReference _clickRightInput;
        private readonly InputActionReference _submitInput;
        private readonly InputActionReference _cancelInput;
        private readonly InputActionReference _navigateInput;

        public MinisteriumInputVelum(IAnchoraInput anchoraInput) {
            _clickInput = anchoraInput.ClickInput;
            _clickRightInput = anchoraInput.ClickRightInput;
            _submitInput = anchoraInput.SubmitInput;
            _cancelInput = anchoraInput.CancelInput;
            _navigateInput = anchoraInput.NavigateInput;
        }

        public bool LegoClick => _clickInput?.action?.enabled == true && _clickInput.action.IsPressed();
        public bool LegoClickRight => _clickRightInput?.action?.enabled == true && _clickRightInput.action.IsPressed();
        public bool LegoSubmit => _submitInput?.action?.enabled == true && _submitInput.action.IsPressed();
        public bool LegoCancel => _cancelInput?.action?.enabled == true && _cancelInput.action.IsPressed();
        public bool LegoNavigate => _navigateInput?.action?.enabled == true && _navigateInput.action.IsPressed();
    }
}