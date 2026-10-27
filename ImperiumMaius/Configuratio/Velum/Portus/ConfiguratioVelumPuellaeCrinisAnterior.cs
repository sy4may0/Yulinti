using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioVelumPuellaeCrinisAnterior", menuName = "Yulinti/Configuratio/Velum/Portus/ConfiguratioVelumPuellaeCrinisAnterior")]
    public sealed class ConfiguratioVelumPuellaeCrinisAnterior : ScriptableObject, IConfiguratioVelumPuellaeCrinisAnterior {
        [SerializeField] private IDPuellaeCrinisCollectionisAnterior _idPuellaeCrinisCollectionis;
        [SerializeField] private Sprite _imagoPulsabuli;
        [SerializeField] private IDTextus _nomen;

        public IDPuellaeCrinisCollectionisAnterior IDPuellaeCrinisCollectionis => _idPuellaeCrinisCollectionis;
        public Sprite ImagoPulsabuli => _imagoPulsabuli;
        public IDTextus Nomen => _nomen;
    }
}
