using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioCorrectrix", menuName = "Yulinti/Configuratio/Turris/Correctrix/ConfiguratioCorrectrix")]
    public class ConfiguratioCorrectrix : ScriptableObject, IConfiguratioCorrectrix {
        [SerializeField] private bool _estCorrigere;

        public bool EstCorrigere => _estCorrigere;
    }
}

