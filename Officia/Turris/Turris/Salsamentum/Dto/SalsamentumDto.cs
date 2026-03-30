using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Yulinti.Officia.Turris {
    internal sealed class SalsamentumDto {
        [JsonProperty("puellae_personae")]
        public SalsamentumPuellaePersonaeDto PuellaePersonae { get; set; }
        [JsonProperty("puellae_formarum")]
        public SalsamentumPuellaeFormarumDto PuellaeFormarum { get; set; }

        public SalsamentumDto() {
            PuellaePersonae = new SalsamentumPuellaePersonaeDto();
            PuellaeFormarum = new SalsamentumPuellaeFormarumDto();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context) {
            PuellaePersonae ??= new SalsamentumPuellaePersonaeDto();
            PuellaeFormarum ??= new SalsamentumPuellaeFormarumDto();
        }
    }
}