using UnityEngine;
using Yulinti.Dux.ContractusDucis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Rex {
    public abstract class ConfiguratioCivisStatusCorporisBasis : ScriptableObject, IConfiguratioCivisStatusCorporis {
        [SerializeField] private IDCivisStatusCorporis id;
        [SerializeField] private IDCivisAnimationisContinuata idAnimationisIntrare;
        [SerializeField] private IDCivisAnimationisContinuata idAnimationisExire;
        [SerializeField] private bool ludereExire;

        [SerializeField] private float consumptioVitae;
        [SerializeField] private float visus;
        [SerializeField] private float visusDistantia;
        [SerializeField] private float auditus;
        [SerializeField] private float auditusDistantia;

        public IDCivisStatusCorporis Id => id;
        public IDCivisAnimationisContinuata IdAnimationisIntrare => idAnimationisIntrare;
        public IDCivisAnimationisContinuata IdAnimationisExire => idAnimationisExire;
        public bool LudereExire => ludereExire;

        public float ConsumptioVitae => consumptioVitae;
        public float Visus => visus;
        public float VisusDistantia => visusDistantia;
        public float Auditus => auditus;
        public float AuditusDistantia => auditusDistantia;
    }
}