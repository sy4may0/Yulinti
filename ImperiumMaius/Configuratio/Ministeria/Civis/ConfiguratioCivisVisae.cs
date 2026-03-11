using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioCivisVisae", menuName = "Yulinti/Configuratio/Ministeria/Civis/ConfiguratioCivisVisae")]
    public sealed class ConfiguratioCivisVisae : ScriptableObject, IConfiguratioCivisVisae {
        [SerializeField] private LayerMask stratumObstaculum;

        public LayerMask StratumObstaculum => stratumObstaculum;
    }
}