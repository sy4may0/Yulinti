using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(
        fileName = "ConfiguratioCivisStatusCustodiaeQuaerens",
        menuName = "Yulinti/Configuratio/Exercitus/Civis/StatusCustodiae/Quaerens")]
    public sealed class ConfiguratioCivisStatusCustodiaeQuaerens : ConfiguratioCivisStatusCustodiaeAttendensBasis, IConfiguratioCivisStatusCustodiaeQuaerens {
        [Header("捜索(諦め)への Studium 減衰(毎秒)")]
        [SerializeField] private float deminutioStudiumAdCassationemSec = 0.5f;

        public float DeminutioStudiumAdCassationemSec => deminutioStudiumAdCassationemSec;
    }
}
