using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(
        fileName = "ConfiguratioCivisStatusCustodiae",
        menuName = "Yulinti/Configuratio/Exercitus/Civis/StatusCustodiae/StatusCustodiae")]
    public sealed class ConfiguratioCivisStatusCustodiae : ScriptableObject, IConfiguratioCivisStatusCustodiae {
        [SerializeField] private ConfiguratioCivisStatusCustodiaeCommunis communis;
        [SerializeField] private ConfiguratioCivisStatusCustodiaeCircumitus circumitus;
        [SerializeField] private ConfiguratioCivisStatusCustodiaeVigilantia vigilantia;
        [SerializeField] private ConfiguratioCivisStatusCustodiaeSpectans spectans;
        [SerializeField] private ConfiguratioCivisStatusCustodiaeSequens sequens;
        [SerializeField] private ConfiguratioCivisStatusCustodiaeQuaerens quaerens;
        [SerializeField] private ConfiguratioCivisStatusCustodiaeDiscedens discedens;
        [SerializeField] private ConfiguratioCivisStatusCustodiaeRefrigerationis refrigerationis;

        public IConfiguratioCivisStatusCustodiaeCommunis ConfiguratioStatusCustodiaeCommunis => communis;
        public IConfiguratioCivisStatusCustodiaeCircumitus ConfiguratioStatusCustodiaeCircumitus => circumitus;
        public IConfiguratioCivisStatusCustodiaeVigilantia ConfiguratioStatusCustodiaeVigilantia => vigilantia;
        public IConfiguratioCivisStatusCustodiaeSpectans ConfiguratioStatusCustodiaeSpectans => spectans;
        public IConfiguratioCivisStatusCustodiaeSequens ConfiguratioStatusCustodiaeSequens => sequens;
        public IConfiguratioCivisStatusCustodiaeQuaerens ConfiguratioStatusCustodiaeQuaerens => quaerens;
        public IConfiguratioCivisStatusCustodiaeDiscedens ConfiguratioStatusCustodiaeDiscedens => discedens;
        public IConfiguratioCivisStatusCustodiaeRefrigerationis ConfiguratioStatusCustodiaeRefrigerationis => refrigerationis;
    }
}
