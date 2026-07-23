using UnityEngine;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(
        fileName = "ConfiguratioCivisStatusCustodiaeRefrigerationis",
        menuName = "Yulinti/Configuratio/Exercitus/Civis/StatusCustodiae/Refrigerationis")]
    public sealed class ConfiguratioCivisStatusCustodiaeRefrigerationis : ConfiguratioCivisStatusCustodiaeAttendensBasis, IConfiguratioCivisStatusCustodiaeRefrigerationis {
        [Header("クールダウン解除距離")]
        [SerializeField] private float distantiaRefrigerationis = 20f;

        [Header("クールダウン中の Studium 減衰(毎秒)")]
        [SerializeField] private float deminutioStudiumAdRefrigerationemSec = 0.2f;

        public float DistantiaRefrigerationis => distantiaRefrigerationis;
        public float DeminutioStudiumAdRefrigerationemSec => deminutioStudiumAdRefrigerationemSec;
    }
}
