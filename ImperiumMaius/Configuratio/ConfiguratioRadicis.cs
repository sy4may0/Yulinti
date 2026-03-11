using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioRadicis", menuName = "Yulinti/Configuratio/ConfiguratioRadicis")]
    public sealed class ConfiguratioRadicis : ScriptableObject {
        [Header("Turris")]
        [SerializeField] private ConfiguratioTurris turris;

        public ConfiguratioTurris Turris => turris;
    }
}