using Newtonsoft.Json;

namespace Yulinti.Unity.Turris {
    internal sealed class SalsamentumNotitiaeDto {
        [JsonProperty("puellae_personae_notitiae")]
        public SalsamentumPuellaePersonaeNotitiaeDto PuellaePersonaeNotitiae { get; set; }

        public SalsamentumNotitiaeDto() {
            PuellaePersonaeNotitiae = new SalsamentumPuellaePersonaeNotitiaeDto();
        }
    }
}