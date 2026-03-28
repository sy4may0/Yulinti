using System.Numerics;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Officia.Turris {
    internal sealed class SalsamentumPuellaeFormaeDto {
        [JsonProperty("ratio")]
        public float Ratio { get; set; }

        public SalsamentumPuellaeFormaeDto() {
            Ratio = 0.5f;
        }
        public void Renovare(float ratio) {
            Ratio = ratio;
        }
    }
    // ここでOnDesirializedはいらない。
    // 辞書型で管理されるvalueであるから、判定はFormarumがやって初期化する。
}