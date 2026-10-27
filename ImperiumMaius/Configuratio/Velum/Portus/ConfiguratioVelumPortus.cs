using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioVelumPortus", menuName = "Yulinti/Configuratio/Velum/Portus/ConfiguratioVelumPortus")]
    public sealed class ConfiguratioVelumPortus : ScriptableObject, IConfiguratioVelumPortus {
        [SerializeField] private ConfiguratioVelumPuellaeCrinisAnterior[] _puellaeCrinisAnterior;
        [SerializeField] private ConfiguratioVelumPuellaeCrinisPosterior[] _puellaeCrinisPosterior;

        public IConfiguratioVelumPuellaeCrinisAnterior[] PuellaeCrinisAnterior => _puellaeCrinisAnterior;
        public IConfiguratioVelumPuellaeCrinisPosterior[] PuellaeCrinisPosterior => _puellaeCrinisPosterior;
    }
}
