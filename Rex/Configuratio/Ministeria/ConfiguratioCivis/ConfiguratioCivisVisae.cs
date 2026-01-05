using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Rex {
    [System.Serializable]
    public sealed class ConfiguratioCivisVisae : IConfiguratioCivisVisae {
        [SerializeField] private LayerMask stratumObstaculum;

        public LayerMask StratumObstaculum => stratumObstaculum;
    }
}