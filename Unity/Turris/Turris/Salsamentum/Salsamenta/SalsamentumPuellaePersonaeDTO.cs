using Yulinti.Exercitus.Contractus;
using System;

namespace Yulinti.Unity.Turris {
    [Serializable]
    internal sealed class SalsamentumPuellaePersonaeDTO {
        public int GradusLuxuriosus;
        public int AnimaLuxuriosus;
        public int GradusExhibitus;
        public int AnimaExhibitus;
        public int GradusPerversus;
        public int AnimaPerversus;
        public int GradusQuaeritDolore;
        public int AnimaQuaeritDolore;

        public int SensusPapillae;
        public int AnimaPapillae;
        public int SensusLandicae;
        public int AnimaLandicae;
        public int SensusVaginae;
        public int AnimaVaginae;
        public int SensusAni;
        public int AnimaAni;
        public int SensusAusculum;
        public int AnimaAusculum;
        public int SensusCorporis;
        public int AnimaCorporis;

        public SalsamentumPuellaePersonaeDTO() {
            GradusLuxuriosus = 0;
            AnimaLuxuriosus = 0;
            GradusExhibitus = 0;
            AnimaExhibitus = 0;
            GradusPerversus = 0;
            AnimaPerversus = 0;
            GradusQuaeritDolore = 0;
            AnimaQuaeritDolore = 0;
            SensusPapillae = 0;
            AnimaPapillae = 0;
            SensusLandicae = 0;
            AnimaLandicae = 0;
            SensusVaginae = 0;
            AnimaVaginae = 0;
            SensusAni = 0;
            AnimaAni = 0;
            SensusAusculum = 0;
            AnimaAusculum = 0;
            SensusCorporis = 0;
            AnimaCorporis = 0;
        }

        public bool Validare() {
            if (GradusLuxuriosus < 0) return false;
            if (AnimaLuxuriosus < 0) return false;
            if (GradusExhibitus < 0) return false;
            if (AnimaExhibitus < 0) return false;
            if (GradusPerversus < 0) return false;
            if (AnimaPerversus < 0) return false;
            if (GradusQuaeritDolore < 0) return false;
            if (AnimaQuaeritDolore < 0) return false;
            if (SensusPapillae < 0) return false;
            if (AnimaPapillae < 0) return false;
            if (SensusLandicae < 0) return false;
            if (AnimaLandicae < 0) return false;
            if (SensusVaginae < 0) return false;
            if (AnimaVaginae < 0) return false;
            if (SensusAni < 0) return false;
            if (AnimaAni < 0) return false;
            if (SensusAusculum < 0) return false;
            if (AnimaAusculum < 0) return false;
            if (SensusCorporis < 0) return false;
            if (AnimaCorporis < 0) return false;
            return true;
        }

        public void Renovere(IResFluidaPuellaePersonaeLegibile resFluida) {
            GradusLuxuriosus = resFluida.GradusLuxuriosus;
            AnimaLuxuriosus = resFluida.AnimaLuxuriosus;
            GradusExhibitus = resFluida.GradusExhibitus;
            AnimaExhibitus = resFluida.AnimaExhibitus;
            GradusPerversus = resFluida.GradusPerversus;
            AnimaPerversus = resFluida.AnimaPerversus;
            GradusQuaeritDolore = resFluida.GradusQuaeritDolore;
            AnimaQuaeritDolore = resFluida.AnimaQuaeritDolore;
            SensusPapillae = resFluida.SensusPapillae;
            AnimaPapillae = resFluida.AnimaPapillae;
            SensusLandicae = resFluida.SensusLandicae;
            AnimaLandicae = resFluida.AnimaLandicae;
            SensusVaginae = resFluida.SensusVaginae;
            AnimaVaginae = resFluida.AnimaVaginae;
            SensusAni = resFluida.SensusAni;
            AnimaAni = resFluida.AnimaAni;
            SensusAusculum = resFluida.SensusAusculum;
            AnimaAusculum = resFluida.AnimaAusculum;
            SensusCorporis = resFluida.SensusCorporis;
            AnimaCorporis = resFluida.AnimaCorporis;
        }
    }
}