using System;
using Newtonsoft.Json;
using Yulinti.Exercitus.Contractus;

namespace Yulinti.Unity.Turris {
    internal sealed class SalsamentumPuellaeDto {
        [JsonProperty("gradus_luxuriosus")]
        public int GradusLuxuriosus { get; set; }
        [JsonProperty("anima_luxuriosus")]
        public int AnimaLuxuriosus { get; set; }
        [JsonProperty("gradus_exhibitus")]
        public int GradusExhibitus { get; set; }
        [JsonProperty("anima_exhibitus")]
        public int AnimaExhibitus { get; set; }
        [JsonProperty("gradus_perversus")]
        public int GradusPerversus { get; set; }
        [JsonProperty("anima_perversus")]
        public int AnimaPerversus { get; set; }
        [JsonProperty("gradus_quaerit_dolore")]
        public int GradusQuaeritDolore { get; set; }
        [JsonProperty("anima_quaerit_dolore")]
        public int AnimaQuaeritDolore { get; set; }
        [JsonProperty("sensus_papillae")]
        public int SensusPapillae { get; set; }
        [JsonProperty("anima_papillae")]
        public int AnimaPapillae { get; set; }
        [JsonProperty("sensus_landicae")]
        public int SensusLandicae { get; set; }
        [JsonProperty("anima_landicae")]
        public int AnimaLandicae { get; set; }
        [JsonProperty("sensus_vaginae")]
        public int SensusVaginae { get; set; }
        [JsonProperty("anima_vaginae")]
        public int AnimaVaginae { get; set; }
        [JsonProperty("sensus_ani")]
        public int SensusAni { get; set; }
        [JsonProperty("anima_ani")]
        public int AnimaAni { get; set; }
        [JsonProperty("sensus_ausculum")]
        public int SensusAusculum { get; set; }
        [JsonProperty("anima_ausculum")]
        public int AnimaAusculum { get; set; }
        [JsonProperty("sensus_corporis")]
        public int SensusCorporis { get; set; }
        [JsonProperty("anima_corporis")]
        public int AnimaCorporis { get; set; }

        public SalsamentumPuellaeDto() {
            GradusLuxuriosus = 1;
            AnimaLuxuriosus = 0;
            GradusExhibitus = 1;
            AnimaExhibitus = 0;
            GradusPerversus = 1;
            AnimaPerversus = 0;
            GradusQuaeritDolore = 1;
            AnimaQuaeritDolore = 0;
            SensusPapillae = 1;
            AnimaPapillae = 0;
            SensusLandicae = 1;
            AnimaLandicae = 0;
            SensusVaginae = 1;
            AnimaVaginae = 0;
            SensusAni = 1;
            AnimaAni = 0;
            SensusAusculum = 1;
            AnimaAusculum = 0;
            SensusCorporis = 1;
            AnimaCorporis = 0;
        }

        public void Renovare(IResFluidaPuellaePersonaeLegibile resFluidaPuellaePersonae) {
            GradusLuxuriosus = resFluidaPuellaePersonae.GradusLuxuriosus;
            AnimaLuxuriosus = resFluidaPuellaePersonae.AnimaLuxuriosus;
            GradusExhibitus = resFluidaPuellaePersonae.GradusExhibitus;
            AnimaExhibitus = resFluidaPuellaePersonae.AnimaExhibitus;
            GradusPerversus = resFluidaPuellaePersonae.GradusPerversus;
            AnimaPerversus = resFluidaPuellaePersonae.AnimaPerversus;
            GradusQuaeritDolore = resFluidaPuellaePersonae.GradusQuaeritDolore;
            AnimaQuaeritDolore = resFluidaPuellaePersonae.AnimaQuaeritDolore;
            SensusPapillae = resFluidaPuellaePersonae.SensusPapillae;
            AnimaPapillae = resFluidaPuellaePersonae.AnimaPapillae;
            SensusLandicae = resFluidaPuellaePersonae.SensusLandicae;
            AnimaLandicae = resFluidaPuellaePersonae.AnimaLandicae;
            SensusVaginae = resFluidaPuellaePersonae.SensusVaginae;
            AnimaVaginae = resFluidaPuellaePersonae.AnimaVaginae;
            SensusAni = resFluidaPuellaePersonae.SensusAni;
            AnimaAni = resFluidaPuellaePersonae.AnimaAni;
            SensusAusculum = resFluidaPuellaePersonae.SensusAusculum;
            AnimaAusculum = resFluidaPuellaePersonae.AnimaAusculum;
            SensusCorporis = resFluidaPuellaePersonae.SensusCorporis;
            AnimaCorporis = resFluidaPuellaePersonae.AnimaCorporis;
        }
    }
}