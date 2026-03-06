using Newtonsoft.Json;

namespace Yulinti.Unity.Turris {
    internal sealed class SalsamentumDto {
        [JsonProperty("puellae_personae")]
        public SalsamentumPuellaePersonaeDto PuellaePersonae { get; set; }

        public SalsamentumDto() {
            PuellaePersonae = new SalsamentumPuellaePersonaeDto();
        }
    }
}