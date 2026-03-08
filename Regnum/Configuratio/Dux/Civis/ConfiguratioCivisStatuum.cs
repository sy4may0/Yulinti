using UnityEngine;
using Yulinti.Exercitus.Contractus;
using Yulinti.Unity.Contractus;

namespace Yulinti.Regnum.Configuratio {
    [System.Serializable]
    public class ConfiguratioCivisStatuum : IConfiguratioCivisStatuum {
        [SerializeField] private IDCivisAnimationis idAnimationisPraedefinitus;
        [SerializeField] private IDCivisStatusCorporis idStatusCorporisIncipalis = IDCivisStatusCorporis.MigrareAditorium;
        [SerializeField] private ConfiguratioCivisStatusCorporisBasis[] statuumCorporis;

        public IDCivisAnimationis IdAnimationisPraedefinitus => idAnimationisPraedefinitus;
        public IDCivisStatusCorporis IDStatusCorporisIncipalis => idStatusCorporisIncipalis;
        public IConfiguratioCivisStatusCorporis[] StatuumCorporis => statuumCorporis;
    }
}
