using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeCrinisCollectionisAnterior", menuName = "Yulinti/Configuratio/Ministeria/Puella/ConfiguratioPuellaeCrinisCollectionisAnterior")]
    public sealed class ConfiguratioPuellaeCrinisCollectionisAnterior : ScriptableObject, IConfiguratioPuellaeCrinisCollectionisAnterior {
        [SerializeField] private IDPuellaeCrinisCollectionisAnterior _idPuellaeCrinisCollectionisAnterior;
        [SerializeField] private IDPuellaeCrinisAnterior _idPuellaeCrinisAnterior;

        public IDPuellaeCrinisCollectionisAnterior IDPuellaeCrinisCollectionisAnterior => _idPuellaeCrinisCollectionisAnterior;
        public IDPuellaeCrinisAnterior IDPuellaeCrinisAnterior => _idPuellaeCrinisAnterior;
    }
}