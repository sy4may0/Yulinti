using UnityEngine;
using Yulinti.Officia.Contractus;

namespace Yulinti.ImperiumMaius.Configuratio {
    [CreateAssetMenu(fileName = "ConfiguratioPuellaeReferensCapitis", menuName = "Yulinti/Configuratio/Ministeria/Puella/ConfiguratioPuellaeReferensCapitis")]
    internal sealed class ConfiguratioPuellaeReferensCapitis : ScriptableObject, IConfiguratioPuellaeReferensCapitis {
        [Tooltip("頭部の位置からのズレ量。これを超えたらReferensを頭部に合わせる。")]
        [SerializeField] private float zonaMortua = 0.3f;
        [Tooltip("追従終了のズレ量。追従中にこれを下回ったら追従を停止する。ZonaMortuaより小さくすること。")]
        [SerializeField] private float zonaMortuaExitus = 0.05f;
        [Tooltip("頭部位置合わせのSmoothTime。")]
        [SerializeField] private float tempusLevigatum = 0.15f;

        public float ZonaMortua => zonaMortua;
        public float ZonaMortuaExitus => zonaMortuaExitus;
        public float TempusLevigatum => tempusLevigatum;
    }
}