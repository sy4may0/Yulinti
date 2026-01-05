using UnityEngine;
using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Rex {
    [System.Serializable]
    public class ConfiguratioCivisStatuum : IConfiguratioCivisStatuum {
        [SerializeField] private IDCivisAnimationisContinuata idAnimationisPraedefinitus;
        [SerializeField] private ConfiguratioCivisStatusCorporisBasis[] statuumCorporis;

        public IDCivisAnimationisContinuata IdAnimationisPraedefinitus => idAnimationisPraedefinitus;
        public IConfiguratioCivisStatusCorporis[] StatuumCorporis => statuumCorporis;
    }
}