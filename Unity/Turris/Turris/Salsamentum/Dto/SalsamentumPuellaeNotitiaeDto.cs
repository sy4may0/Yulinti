using Newtonsoft.Json;
using Yulinti.Exercitus.Contractus;

namespace Yulinti.Unity.Turris {
    internal sealed class SalsamentumPuellaeNotitiaeDto {
        [JsonProperty("gradus_luxuriosus")]
        public int GradusLuxuriosus { get; set; }
        [JsonProperty("gradus_exhibitus")]
        public int GradusExhibitus { get; set; }
        [JsonProperty("gradus_perversus")]
        public int GradusPerversus { get; set; }
        [JsonProperty("gradus_quaerit_dolore")]
        public int GradusQuaeritDolore { get; set; }

        public SalsamentumPuellaeNotitiaeDto() {
            GradusLuxuriosus = 1;
            GradusExhibitus = 1;
            GradusPerversus = 1;
            GradusQuaeritDolore = 1;
        }

        public void Renovare(IResFluidaPuellaePersonaeLegibile resFluidaPuellaePersonae) {
            GradusLuxuriosus = resFluidaPuellaePersonae.GradusLuxuriosus;
            GradusExhibitus = resFluidaPuellaePersonae.GradusExhibitus;
            GradusPerversus = resFluidaPuellaePersonae.GradusPerversus;
            GradusQuaeritDolore = resFluidaPuellaePersonae.GradusQuaeritDolore;
        }
    }
}