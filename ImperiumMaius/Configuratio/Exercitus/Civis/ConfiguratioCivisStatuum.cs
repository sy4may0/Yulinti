using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioCivisStatuum", menuName = "Yulinti/Configuratio/Exercitus/Civis/ConfiguratioCivisStatuum")]
    public class ConfiguratioCivisStatuum : ScriptableObject, IConfiguratioCivisStatuum {
        [SerializeField] private IDCivisAnimationis idAnimationisPraedefinitus;
        [SerializeField] private IDCivisStatusCorporis idStatusCorporisIncipalis = IDCivisStatusCorporis.MigrareAditorium;
        [SerializeField] private ConfiguratioCivisStatusCorporisBasis[] statuumCorporis;

        public IDCivisAnimationis IdAnimationisPraedefinitus => idAnimationisPraedefinitus;
        public IDCivisStatusCorporis IDStatusCorporisIncipalis => idStatusCorporisIncipalis;
        public IConfiguratioCivisStatusCorporis[] StatuumCorporis => statuumCorporis;
    }
}
