using UnityEngine;
using Yulinti.Unity.Contractus;

namespace Yulinti.Regnum.Configuratio {
    [System.Serializable]
    public sealed class ConfiguratioCivisVisae : IConfiguratioCivisVisae {
        [SerializeField] private LayerMask stratumObstaculum;

        public LayerMask StratumObstaculum => stratumObstaculum;
    }
}