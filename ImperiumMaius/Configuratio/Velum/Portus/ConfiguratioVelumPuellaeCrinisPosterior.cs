using UnityEngine;
using UnityEngine.AddressableAssets;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioVelumPuellaeCrinisPosterior", menuName = "Yulinti/Configuratio/Velum/Portus/ConfiguratioVelumPuellaeCrinisPosterior")]
    public sealed class ConfiguratioVelumPuellaeCrinisPosterior : ScriptableObject, IConfiguratioVelumPuellaeCrinisPosterior {
        [SerializeField] private IDPuellaeCrinisCollectionisPosterior _idPuellaeCrinisCollectionis;
        [SerializeField] private Sprite _imagoPulsabuli;
        [SerializeField] private IDTextus _nomen;

        public IDPuellaeCrinisCollectionisPosterior IDPuellaeCrinisCollectionis => _idPuellaeCrinisCollectionis;
        public Sprite ImagoPulsabuli => _imagoPulsabuli;
        public IDTextus Nomen => _nomen;
    }
}
