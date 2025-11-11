using UnityEngine;
using Yulinti.MinisteriaUnity.MinisteriaNuclei;
using Yulinti.UnityServices.ServiceConfig;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class MinisteriumInputMotus {
        private readonly IMoveInputConfig _moveInputConfig;

        public MinisteriumInputMotus(IMoveInputConfig moveInputConfig) {
            if (moveInputConfig == null) {
                ModeratorErrorum.Fatal("MinisteriumInputMotusのMoveInputConfigがnullです。");
            }
            _moveInputConfig = moveInputConfig;
        }

        public Vector2 LegoMotus => _moveInputConfig.MoveInput?.action?.enabled == true ? _moveInputConfig.MoveInput.action.ReadValue<Vector2>() : Vector2.zero;
        public bool LegoCursus => _moveInputConfig.SprintInput?.action?.enabled == true && _moveInputConfig.SprintInput.action.IsPressed();
        public bool LegoIncumbo => _moveInputConfig.CrouchInput?.action?.enabled == true && _moveInputConfig.CrouchInput.action.IsPressed();
    }
}