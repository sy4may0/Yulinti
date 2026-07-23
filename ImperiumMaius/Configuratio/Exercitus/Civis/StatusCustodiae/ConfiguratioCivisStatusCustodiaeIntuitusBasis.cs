using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    // Intuitus系ステート(Spectans/Sequens)の共通設定。
    public abstract class ConfiguratioCivisStatusCustodiaeIntuitusBasis : ConfiguratioCivisStatusCustodiaeAttendensBasis, IConfiguratioCivisStatusCustodiaeIntuitus {
        [Header("Intentio 増減量(毎秒)")]
        [SerializeField] private float augmentumIntentionisSec = 0.5f;
        [SerializeField] private float deminutioIntentionisSec = 0.3f;

        [Header("Studium 増減量(毎秒)")]
        [SerializeField] private float augmentumStudiumSec = 0.5f;
        [SerializeField] private float deminutioStudiumSec = 0.3f;

        [Header("Studium 特殊減衰(毎秒)")]
        [Tooltip("Anomalia超過によるStudium減衰量")]
        [SerializeField] private float deminutioStudiumAdRecusationemSec = 1.0f;
        [Tooltip("視認無しやAnomalia不足によるStudium減衰量")]
        [SerializeField] private float deminutioStudiumAdAmittensSec = 0.5f;

        [Header("Suspecta がこの割合(対Maximaレシオ)を下回ると Quaerens へ")]
        [SerializeField] private float ratioSuspectaeMinimaAdQuaerens = 0.4f;

        public float AugmentumIntentionisSec => augmentumIntentionisSec;
        public float DeminutioIntentionisSec => deminutioIntentionisSec;
        public float AugmentumStudiumSec => augmentumStudiumSec;
        public float DeminutioStudiumSec => deminutioStudiumSec;
        public float DeminutioStudiumAdRecusationemSec => deminutioStudiumAdRecusationemSec;
        public float DeminutioStudiumAdAmittensSec => deminutioStudiumAdAmittensSec;
        public float RatioSuspectaeMinimaAdQuaerens => ratioSuspectaeMinimaAdQuaerens;
    }
}
