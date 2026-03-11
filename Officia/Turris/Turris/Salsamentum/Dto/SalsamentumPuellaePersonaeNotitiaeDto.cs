using Newtonsoft.Json;
using Yulinti.ImperiumDelegatum.Contractus;

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

        public void Renovare(IPhantasmaPuellaePersonae phantasmaPuellaePersonae) {
            GradusLuxuriosus = phantasmaPuellaePersonae.GradusLuxuriosus;
            GradusExhibitus = phantasmaPuellaePersonae.GradusExhibitus;
            GradusPerversus = phantasmaPuellaePersonae.GradusPerversus;
            GradusQuaeritDolore = phantasmaPuellaePersonae.GradusQuaeritDolore;
        }
    }
}
