using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(
        fileName = "ConfiguratioCivisCustodiaeStatusQuaerens",
        menuName = "Yulinti/Configuratio/Exercitus/Civis/CustodiaeStatus/Quaerens")]
    public sealed class ConfiguratioCivisCustodiaeStatusQuaerens : ConfiguratioCivisCustodiaeStatusAttendensBasis, IConfiguratioCivisCustodiaeStatusQuaerens {
        [Header("捜索(諦め)への Studium 減衰(毎秒)")]
        [SerializeField] private float deminutioStudiumAdCassationemSec = 0.5f;

        public float DeminutioStudiumAdCassationemSec => deminutioStudiumAdCassationemSec;
    }
}
