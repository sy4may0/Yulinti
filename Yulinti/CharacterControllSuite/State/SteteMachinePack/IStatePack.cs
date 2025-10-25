using UnityEngine;
using Animancer;

using Yulinti.CharacterControllSuite;

namespace Yulinti.CharacterControllSuite {
    public interface IStatePack {
        void Apply(StateMachine stateMachine);
    }
}