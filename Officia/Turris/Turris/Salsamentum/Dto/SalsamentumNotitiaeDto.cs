using Newtonsoft.Json;

namespace Yulinti.Officia.Turris {
    internal sealed class SalsamentumNotitiaeDto {
        [JsonProperty("puellae_personae_notitiae")]
        public SalsamentumPuellaePersonaeNotitiaeDto PuellaePersonaeNotitiae { get; set; }

        public SalsamentumNotitiaeDto() {
            PuellaePersonaeNotitiae = new SalsamentumPuellaePersonaeNotitiaeDto();
        }
    }
}