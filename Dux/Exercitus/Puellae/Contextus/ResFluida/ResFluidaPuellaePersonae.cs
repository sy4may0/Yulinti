using Yulinti.Dux.ContractusDucis;
namespace Yulinti.Dux.Exercitus {
    internal sealed class ResFluidaPuellaePersonae : IResFluidaPuellaePersonaeLegibile {
        // レベルとかのステータス

        private int _gradusLuxuriosus;
        private int _gradusExhibitus;
        private int _gradusPerversus;
        private int _gradusQuaeritDolore;

        private int _sensusPapillae;
        private int _sensusLandicae;
        private int _sensusVaginae;
        private int _sensusAni;
        private int _sensusAusculum;
        private int _sensusCorporis;

        public ResFluidaPuellaePersonae() {
            _gradusLuxuriosus = 0;
            _gradusExhibitus = 0;
            _gradusPerversus = 0;
            _gradusQuaeritDolore = 0;

            _sensusPapillae = 0;
            _sensusLandicae = 0;
            _sensusVaginae = 0;
            _sensusAni = 0;
            _sensusAusculum = 0;
            _sensusCorporis = 0;
        }

        public int GradusLuxuriosus => _gradusLuxuriosus;
        public int GradusExhibitus => _gradusExhibitus;
        public int GradusPerversus => _gradusPerversus;
        public int GradusQuaeritDolore => _gradusQuaeritDolore;

        public int SensusPapillae => _sensusPapillae;
        public int SensusLandicae => _sensusLandicae;
        public int SensusVaginae => _sensusVaginae;
        public int SensusAni => _sensusAni;
        public int SensusAusculum => _sensusAusculum;
        public int SensusCorporis => _sensusCorporis;

        public void RenovareGradus(
            int gradusLuxuriosus,
            int gradusExhibitus,
            int gradusPerversus,
            int gradusQuaeritDolore
        ) {
            _gradusLuxuriosus = DuxMath.Clamp(gradusLuxuriosus, 0, ConstansPuellae.GradusMaximus);
            _gradusExhibitus = DuxMath.Clamp(gradusExhibitus, 0, ConstansPuellae.GradusMaximus);
            _gradusPerversus = DuxMath.Clamp(gradusPerversus, 0, ConstansPuellae.GradusMaximus);
            _gradusQuaeritDolore = DuxMath.Clamp(gradusQuaeritDolore, 0, ConstansPuellae.GradusMaximus);
        }

        public void RenovareSensus(
            int sensusPapillae,
            int sensusLandicae,
            int sensusVaginae,
            int sensusAni,
            int sensusAusculum,
            int sensusCorporis
        ) {
            _sensusPapillae = DuxMath.Clamp(sensusPapillae, 0, ConstansPuellae.SensusMaximus);
            _sensusLandicae = DuxMath.Clamp(sensusLandicae, 0, ConstansPuellae.SensusMaximus);
            _sensusVaginae = DuxMath.Clamp(sensusVaginae, 0, ConstansPuellae.SensusMaximus);
            _sensusAni = DuxMath.Clamp(sensusAni, 0, ConstansPuellae.SensusMaximus);
            _sensusAusculum = DuxMath.Clamp(sensusAusculum, 0, ConstansPuellae.SensusMaximus);
            _sensusCorporis = DuxMath.Clamp(sensusCorporis, 0, ConstansPuellae.SensusMaximus);
        }

        public void Purgare() {
            _gradusLuxuriosus = 0;
            _gradusExhibitus = 0;
            _gradusPerversus = 0;
            _gradusQuaeritDolore = 0;

            _sensusPapillae = 0;
            _sensusLandicae = 0;
            _sensusVaginae = 0;
            _sensusAni = 0;
            _sensusAusculum = 0;
            _sensusCorporis = 0;
        }
    }
}