using UnityEngine;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioImperium", menuName = "Yulinti/Configuratio/ConfiguratioImperium")]
    public sealed class ConfiguratioImperium : ScriptableObject {
        [SerializeField] private ConfiguratioMinisteria ministeria;
        [SerializeField] private ConfiguratioExercitus exercitus;

        public ConfiguratioMinisteria Ministeria => ministeria;
        public ConfiguratioExercitus Exercitus => exercitus;
    }
}