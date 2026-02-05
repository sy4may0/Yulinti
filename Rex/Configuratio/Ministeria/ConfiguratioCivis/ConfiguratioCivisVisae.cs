using UnityEngine;
using Yulinti.Unity.Contractus;

namespace Yulinti.Rex {
    [System.Serializable]
    public sealed class ConfiguratioCivisVisae : IConfiguratioCivisVisae {
        [SerializeField] private LayerMask stratumObstaculum;

        public LayerMask StratumObstaculum => stratumObstaculum;
    }
}