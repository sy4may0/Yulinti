using UnityEngine;
using System;

namespace Yulinti.CharacterControllSuite {
    [System.Serializable]
    public sealed class PlayerMover {
        private readonly CharacterMover _characterMover;

        public PlayerMover(
            MoverConfig config,
            GrounderConfig grounderConfig
        ) {
            _characterMover = new CharacterMover(config.CharacterController);
        }

        public void Tick(
            MovePlan movePlan,
            MoveRuntimeCommands moveRuntimeCmds,
            MoveRuntimeReadOnly moveRuntimeRO
        ) {
            _characterMover.ApplyMove(movePlan, moveRuntimeCmds, moveRuntimeRO);
        }
    }
}