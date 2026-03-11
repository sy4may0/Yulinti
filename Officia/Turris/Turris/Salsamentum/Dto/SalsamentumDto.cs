using Newtonsoft.Json;

namespace Yulinti.Officia.Turris {
    internal sealed class SalsamentumDto {
        [JsonProperty("puellae_personae")]
        public SalsamentumPuellaePersonaeDto PuellaePersonae { get; set; }

        public SalsamentumDto() {
            PuellaePersonae = new SalsamentumPuellaePersonaeDto();
        }
    }
}