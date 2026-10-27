using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeCrinisCollectionis", menuName = "Yulinti/Configuratio/Ministeria/Puella/ConfiguratioPuellaeCrinisCollectio")]
    public sealed class ConfiguratioPuellaeCrinisCollectionis : ScriptableObject, IConfiguratioPuellaeCrinisCollectionis {
        [SerializeField] private ConfiguratioPuellaeCrinisCollectionisAnterior[] _anterior;
        [SerializeField] private ConfiguratioPuellaeCrinisCollectionisPosterior[] _posterior;

        public IConfiguratioPuellaeCrinisCollectionisAnterior[] Anterior => _anterior;
        public IConfiguratioPuellaeCrinisCollectionisPosterior[] Posterior => _posterior;
    }
}