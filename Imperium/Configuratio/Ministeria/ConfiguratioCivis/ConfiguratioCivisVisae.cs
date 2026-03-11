using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.Imperium.Configuratio {
    [System.Serializable]
    public sealed class ConfiguratioCivisVisae : IConfiguratioCivisVisae {
        [SerializeField] private LayerMask stratumObstaculum;

        public LayerMask StratumObstaculum => stratumObstaculum;
    }
}