using Newtonsoft.Json;

namespace Yulinti.Unity.Turris {
    internal sealed class SalsamentumNotitiaeDto {
        [JsonProperty("puellae_notitiae")]
        public SalsamentumPuellaeNotitiaeDto PuellaeNotitiae { get; set; }

        public SalsamentumNotitiaeDto() {
            PuellaeNotitiae = new SalsamentumPuellaeNotitiaeDto();
        }
    }
}