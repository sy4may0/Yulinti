using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeCrinisCollectionisPosterior", menuName = "Yulinti/Configuratio/Ministeria/Puella/ConfiguratioPuellaeCrinisCollectionisPosterior")]
    public sealed class ConfiguratioPuellaeCrinisCollectionisPosterior : ScriptableObject, IConfiguratioPuellaeCrinisCollectionisPosterior {
        [SerializeField] private IDPuellaeCrinisCollectionisPosterior _idPuellaeCrinisCollectionisPosterior;
        [SerializeField] private IDPuellaeCrinisBasis _idPuellaeCrinisBasis;
        [SerializeField] private IDPuellaeCrinisPosterior _idPuellaeCrinisPosterior;

        public IDPuellaeCrinisCollectionisPosterior IDPuellaeCrinisCollectionisPosterior => _idPuellaeCrinisCollectionisPosterior;
        public IDPuellaeCrinisBasis IDPuellaeCrinisBasis => _idPuellaeCrinisBasis;
        public IDPuellaeCrinisPosterior IDPuellaeCrinisPosterior => _idPuellaeCrinisPosterior;
    }
}