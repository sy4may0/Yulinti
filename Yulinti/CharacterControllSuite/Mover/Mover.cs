using UnityEngine;
using System;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public sealed class Mover {
        private readonly MoverConfig _config;
        private readonly CharacterMover _characterMover;
        private readonly GrounderController _grounderController;

        public Mover(
            MoverConfig config,
        ) {
            _characterMover = new CharacterMover(config.CharacterController);
            _grounderController = new GrounderController(config);
        }

        public void Tick(
            MovePlan movePlan,
            MoveRuntimeWriteable moveRuntimeWO,
            MoveRuntimeReadOnly moveRuntimeRO
        ) {
            _characterMover.ApplyMove(movePlan, moveRuntimeWO, moveRuntimeRO);
        }

        public void LateTick() {
            _grounderController.ForceLegAboveGround();
        }
    }
}