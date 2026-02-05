using UnityEngine;
using UnityEngine.InputSystem;
using Yulinti.Nucleus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Unity.Anchora {
    public sealed class AnchoraInput : MonoBehaviour, IAnchora, IAnchoraInput {
        [SerializeField] private InputActionReference _moveInput;
        [SerializeField] private InputActionReference _sprintInput;
        [SerializeField] private InputActionReference _crouchInput;

        // UI Input
        [SerializeField] private InputActionReference _click;
        [SerializeField] private InputActionReference _clickRight;
        [SerializeField] private InputActionReference _submit;
        [SerializeField] private InputActionReference _cancel;
        [SerializeField] private InputActionReference _navigate;

        public InputActionReference MoveInput => _moveInput;
        public InputActionReference SprintInput => _sprintInput;
        public InputActionReference CrouchInput => _crouchInput;

        public InputActionReference ClickInput => _click;
        public InputActionReference ClickRightInput => _clickRight;
        public InputActionReference SubmitInput => _submit;
        public InputActionReference CancelInput => _cancel;
        public InputActionReference NavigateInput => _navigate;

        public Vector3 Positio => transform.position;
        public Quaternion Rotatio => transform.rotation;
        public Vector3 Scala => transform.localScale;

        public bool Validare() {
            bool result = true;
            if (_moveInput == null) {
                Errorum.Fatal(IDErrorum.ANCHORAINPUT_MOVEINPUT_NULL);
                result = false;
            }
            if (_sprintInput == null) {
                Errorum.Fatal(IDErrorum.ANCHORAINPUT_SPRINTINPUT_NULL);
                result = false;
            }
            if (_crouchInput == null) {
                Errorum.Fatal(IDErrorum.ANCHORAINPUT_CROUCHINPUT_NULL);
                result = false;
            }
            if (_click == null) {
                Errorum.Fatal(IDErrorum.ANCHORAINPUT_CLICKINPUT_NULL);
                result = false;
            }
            if (_clickRight == null) {
                Errorum.Fatal(IDErrorum.ANCHORAINPUT_CLICKRIGHTINPUT_NULL);
                result = false;
            }
            if (_submit == null) {
                Errorum.Fatal(IDErrorum.ANCHORAINPUT_SUBMITINPUT_NULL);
                result = false;
            }
            if (_cancel == null) {
                Errorum.Fatal(IDErrorum.ANCHORAINPUT_CANCELINPUT_NULL);
                result = false;
            }
            if (_navigate == null) {
                Errorum.Fatal(IDErrorum.ANCHORAINPUT_NAVIGATEINPUT_NULL);
                result = false;
            }
            return result;
        }
    }
}
