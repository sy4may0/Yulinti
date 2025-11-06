using UnityEngine;
using System;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public sealed class PlayerMover {
        private readonly CharacterMover _characterMover;
        private readonly GrounderController _grounderController;

        public PlayerMover(
            MoverConfig config,
            GrounderConfig grounderConfig
        ) {
            _characterMover = new CharacterMover(config.CharacterController);
            _grounderController = new GrounderController(grounderConfig);
        }

        public void Tick(
            MovePlan movePlan,
            MoveRuntimeCommands moveRuntimeCmds,
            MoveRuntimeReadOnly moveRuntimeRO
        ) {
            _characterMover.ApplyMove(movePlan, moveRuntimeCmds, moveRuntimeRO);
        }

        public void LateTick() {
            _grounderController.ForceLegAboveGround();
        }
    }
}