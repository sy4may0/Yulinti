using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(
        fileName = "ConfiguratioCivisCustodiaeStatus",
        menuName = "Yulinti/Configuratio/Exercitus/Civis/CustodiaeStatus/CustodiaeStatus")]
    public sealed class ConfiguratioCivisCustodiaeStatus : ScriptableObject, IConfiguratioCivisCustodiaeStatus {
        [SerializeField] private ConfiguratioCivisCustodiaeStatusCommunis communis;
        [SerializeField] private ConfiguratioCivisCustodiaeStatusCircumitus circumitus;
        [SerializeField] private ConfiguratioCivisCustodiaeStatusVigilantia vigilantia;
        [SerializeField] private ConfiguratioCivisCustodiaeStatusSpectans spectans;
        [SerializeField] private ConfiguratioCivisCustodiaeStatusSequens sequens;
        [SerializeField] private ConfiguratioCivisCustodiaeStatusQuaerens quaerens;
        [SerializeField] private ConfiguratioCivisCustodiaeStatusDiscedens discedens;
        [SerializeField] private ConfiguratioCivisCustodiaeStatusRefrigerationis refrigerationis;

        public IConfiguratioCivisCustodiaeStatusCommunis ConfiguratioCustodiaeStatusCommunis => communis;
        public IConfiguratioCivisCustodiaeStatusCircumitus ConfiguratioCustodiaeStatusCircumitus => circumitus;
        public IConfiguratioCivisCustodiaeStatusVigilantia ConfiguratioCustodiaeStatusVigilantia => vigilantia;
        public IConfiguratioCivisCustodiaeStatusSpectans ConfiguratioCustodiaeStatusSpectans => spectans;
        public IConfiguratioCivisCustodiaeStatusSequens ConfiguratioCustodiaeStatusSequens => sequens;
        public IConfiguratioCivisCustodiaeStatusQuaerens ConfiguratioCustodiaeStatusQuaerens => quaerens;
        public IConfiguratioCivisCustodiaeStatusDiscedens ConfiguratioCustodiaeStatusDiscedens => discedens;
        public IConfiguratioCivisCustodiaeStatusRefrigerationis ConfiguratioCustodiaeStatusRefrigerationis => refrigerationis;
    }
}
