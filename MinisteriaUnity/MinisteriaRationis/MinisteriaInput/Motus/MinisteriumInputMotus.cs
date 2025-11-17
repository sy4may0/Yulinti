using UnityEngine;
using Yulinti.MinisteriaUnity.Interna;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class MinisteriumInputMotus {
        private readonly IConfiguratioInputMotus _configuratioInputMotus;

        public MinisteriumInputMotus(IConfiguratioInputMotus configuratioInputMotus) {
            if (configuratioInputMotus == null) {
                ModeratorErrorum.Fatal("MinisteriumInputMotusのConfiguratioInputMotusがnullです。");
            }
            _configuratioInputMotus = configuratioInputMotus;
        }

        public Vector2 LegoMotus => _configuratioInputMotus.MoveInput?.action?.enabled == true ? _configuratioInputMotus.MoveInput.action.ReadValue<Vector2>() : Vector2.zero;
        public bool LegoCursus => _configuratioInputMotus.SprintInput?.action?.enabled == true && _configuratioInputMotus.SprintInput.action.IsPressed();
        public bool LegoIncumbo => _configuratioInputMotus.CrouchInput?.action?.enabled == true && _configuratioInputMotus.CrouchInput.action.IsPressed();
    }
}