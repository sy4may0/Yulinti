using System.Numerics;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Officia.Turris {
    internal sealed class SalsamentumPuellaeFormaeDto {
        [JsonProperty("magnitudo_x")]
        public float MagnitudoX { get; set; }
        [JsonProperty("magnitudo_y")]
        public float MagnitudoY { get; set; }
        [JsonProperty("magnitudo_z")]
        public float MagnitudoZ { get; set; }

        public SalsamentumPuellaeFormaeDto() {
            MagnitudoX = 1f;
            MagnitudoY = 1f;
            MagnitudoZ = 1f;
        }
        public void Renovare(Vector3 magnitudoActualis) {
            MagnitudoX = magnitudoActualis.X;
            MagnitudoY = magnitudoActualis.Y;
            MagnitudoZ = magnitudoActualis.Z;
        }
    }
    // ここでOnDesirializedはいらない。
    // 辞書型で管理されるvalueであるから、判定はFormarumがやって初期化する。
}