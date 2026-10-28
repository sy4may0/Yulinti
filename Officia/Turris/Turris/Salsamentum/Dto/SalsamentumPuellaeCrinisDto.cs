using Newtonsoft.Json;
using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Officia.Turris {
    internal sealed class SalsamentumPuellaeCrinisDto {
        [JsonProperty("crinis_anterior")]
        public IDPuellaeCrinisCollectionisAnterior CrinisAnterior { get; set; }

        [JsonProperty("crinis_posterior")]
        public IDPuellaeCrinisCollectionisPosterior CrinisPosterior { get; set; }

        public SalsamentumPuellaeCrinisDto() {
            CrinisAnterior = IDPuellaeCrinisCollectionisAnterior.Nihil;
            CrinisPosterior = IDPuellaeCrinisCollectionisPosterior.Nihil;
        }
    }
}