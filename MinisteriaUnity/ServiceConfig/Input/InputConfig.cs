using UnityEngine;

namespace Yulinti.UnityServices.ServiceConfig {
    [System.Serializable]
    public sealed class InputConfig {
        [SerializeField] private MoveInputConfig _moveInputConfig;

        public MoveInputConfig MoveInputConfig => _moveInputConfig;
    }
}