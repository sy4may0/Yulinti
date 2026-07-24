using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    // Attendens系ステート(Circumitus/Discedens/Quaerens/Refrigerationis/Intuitus系)の共通設定。
    public abstract class ConfiguratioCivisCustodiaeStatusAttendensBasis : ScriptableObject, IConfiguratioCivisCustodiaeStatusAttendens {
        [Header("Suspecta 増減量(毎秒)")]
        [SerializeField] private float augmentumSuspectaeVisaeSec = 0.5f;
        [SerializeField] private float augmentumSuspectaeAuditaeSec = 0.3f;
        [SerializeField] private float deminutioSuspectaeSec = 0.3f;

        [Header("Suspecta 上限(条件別)")]
        [Tooltip("Anomaliaが0の時の上限")]
        [SerializeField] private float suspectaMaximaNihilAnomaliae = 0.3f;
        [Tooltip("視認無し、音のみでの上限")]
        [SerializeField] private float suspectaMaximaAuditaeSolus = 0.5f;
        [Tooltip("視認あり、Anomalia不足でVigilantia到達不可状態の上限")]
        [SerializeField] private float suspectaMaximaAnomaliaeDeest = 0.8f;

        [Header("Vigilantia に必要な最小 Anomalia")]
        [SerializeField] private float anomaliaeMinimaAdVigilantiam = 200f;

        public float AugmentumSuspectaeVisaeSec => augmentumSuspectaeVisaeSec;
        public float AugmentumSuspectaeAuditaeSec => augmentumSuspectaeAuditaeSec;
        public float DeminutioSuspectaeSec => deminutioSuspectaeSec;
        public float SuspectaMaximaNihilAnomaliae => suspectaMaximaNihilAnomaliae;
        public float SuspectaMaximaAuditaeSolus => suspectaMaximaAuditaeSolus;
        public float SuspectaMaximaAnomaliaeDeest => suspectaMaximaAnomaliaeDeest;
        public float AnomaliaeMinimaAdVigilantiam => anomaliaeMinimaAdVigilantiam;
    }
}
