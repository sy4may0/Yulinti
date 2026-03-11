using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    public abstract class ConfiguratioCivisStatusCorporisBasis : ScriptableObject, IConfiguratioCivisStatusCorporis {
        [SerializeField] private IDCivisStatusCorporis id;
        [SerializeField] private IDCivisAnimationis idAnimationisIntrare;
        [SerializeField] private IDCivisAnimationis idAnimationisTransere;
        [SerializeField] private IDCivisAnimationis idAnimationisExire;
        [SerializeField] private bool estInterdictaIntrare;
        [SerializeField] private bool estInterdictaTransere;
        [SerializeField] private bool estInterdictaExire;
        [SerializeField] private IDCivisStatusCorporis idStatusProximusAutomaticus;

        [SerializeField] private float consumptioVitae;
        [SerializeField] private float visus;
        [SerializeField] private float visusDistantia;
        [SerializeField] private float auditus;
        [SerializeField] private float auditusDistantia;

        public IDCivisStatusCorporis Id => id;
        public IDCivisAnimationis IdAnimationisIntrare => idAnimationisIntrare;
        public IDCivisAnimationis IdAnimationisTransere => idAnimationisTransere;
        public IDCivisAnimationis IdAnimationisExire => idAnimationisExire;
        public bool EstInterdictaIntrare => estInterdictaIntrare;
        public bool EstInterdictaTransere => estInterdictaTransere;
        public bool EstInterdictaExire => estInterdictaExire;

        public IDCivisStatusCorporis IDStatusProximusAutomaticus => idStatusProximusAutomaticus;

        public float ConsumptioVitae => consumptioVitae;
        public float Visus => visus;
        public float VisusDistantia => visusDistantia;
        public float Auditus => auditus;
        public float AuditusDistantia => auditusDistantia;
    }
}
