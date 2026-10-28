using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;
using UnityEngine;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioTurrisPhantasmaeInitialis", menuName = "Yulinti/Configuratio/Turris/Phantasma/ConfiguratioTurrisPhantasmaeInitialis")]
    internal sealed class ConfiguratioTurrisPhantasmaeInitialis : ScriptableObject, IConfiguratioTurrisPhantasmaeInitialis {
        [SerializeField] private IDPuellaeCrinisCollectionisAnterior crinisAnteriorInitialis;
        [SerializeField] private IDPuellaeCrinisCollectionisPosterior crinisPosteriorInitialis;

        public IDPuellaeCrinisCollectionisAnterior CrinisAnteriorInitialis => crinisAnteriorInitialis;
        public IDPuellaeCrinisCollectionisPosterior CrinisPosteriorInitialis => crinisPosteriorInitialis;
    }
}