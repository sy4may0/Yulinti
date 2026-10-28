using Newtonsoft.Json;

namespace Yulinti.Officia.Turris {
    internal sealed class SalsamentumPuellaePersonaeNotitiaeDto {
        [JsonProperty("gradus_luxuriosus")]
        public int GradusLuxuriosus { get; set; }
        [JsonProperty("gradus_exhibitus")]
        public int GradusExhibitus { get; set; }
        [JsonProperty("gradus_perversus")]
        public int GradusPerversus { get; set; }
        [JsonProperty("gradus_quaerit_dolore")]
        public int GradusQuaeritDolore { get; set; }

        public SalsamentumPuellaePersonaeNotitiaeDto() {
            GradusLuxuriosus = 1;
            GradusExhibitus = 1;
            GradusPerversus = 1;
            GradusQuaeritDolore = 1;
        }
    }
}
