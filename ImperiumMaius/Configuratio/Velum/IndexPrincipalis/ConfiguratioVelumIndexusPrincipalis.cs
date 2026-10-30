using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioVelumIndexusPrincipalis", menuName = "Yulinti/Configuratio/Velum/IndexPrincipalis/ConfiguratioVelumIndexusPrincipalis")]
    public sealed class ConfiguratioVelumIndexusPrincipalis : ScriptableObject, IConfiguratioVelumIndexusPrincipalis {
        [SerializeField] private ConfiguratioParsPulsabulumIndexusPrincipalis[] _parsPulsabulumIndexusPrincipalis;

        public IConfiguratioParsPulsabulumIndexusPrincipalis[] ParsPulsabulumIndexusPrincipalis => _parsPulsabulumIndexusPrincipalis;
    }
}
