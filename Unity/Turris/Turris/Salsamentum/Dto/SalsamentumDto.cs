using Newtonsoft.Json;

namespace Yulinti.Unity.Turris {
    internal sealed class SalsamentumDto {
        [JsonProperty("puellae")]
        public SalsamentumPuellaeDto Puellae { get; set; }

        public SalsamentumDto() {
            Puellae = new SalsamentumPuellaeDto();
        }
    }
}