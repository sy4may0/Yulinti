using Yulinti.Exercitus.Contractus;

namespace Yulinti.Unity.Deus {
    internal sealed class OstiumSalsamentiPuellaePersonae : IOstiumSalsamentiPuellaePersonae {
        private readonly SalsamentumPuellaePersonaeDTO _salsamentumPuellaePersonaeDTO;

        public OstiumSalsamentiPuellaePersonae(SalsamentumPuellaePersonaeDTO salsamentumPuellaePersonaeDTO) {
            _salsamentumPuellaePersonaeDTO = salsamentumPuellaePersonaeDTO;
        }

        public int GradusLuxuriosus => _salsamentumPuellaePersonaeDTO.GradusLuxuriosus;
        public int AnimaLuxuriosus => _salsamentumPuellaePersonaeDTO.AnimaLuxuriosus;
        public int GradusExhibitus => _salsamentumPuellaePersonaeDTO.GradusExhibitus;
        public int AnimaExhibitus => _salsamentumPuellaePersonaeDTO.AnimaExhibitus;
        public int GradusPerversus => _salsamentumPuellaePersonaeDTO.GradusPerversus;
        public int AnimaPerversus => _salsamentumPuellaePersonaeDTO.AnimaPerversus;
        public int GradusQuaeritDolore => _salsamentumPuellaePersonaeDTO.GradusQuaeritDolore;
        public int AnimaQuaeritDolore => _salsamentumPuellaePersonaeDTO.AnimaQuaeritDolore;

        public int SensusPapillae => _salsamentumPuellaePersonaeDTO.SensusPapillae;
        public int AnimaPapillae => _salsamentumPuellaePersonaeDTO.AnimaPapillae;
        public int SensusLandicae => _salsamentumPuellaePersonaeDTO.SensusLandicae;
        public int AnimaLandicae => _salsamentumPuellaePersonaeDTO.AnimaLandicae;
        public int SensusVaginae => _salsamentumPuellaePersonaeDTO.SensusVaginae;
        public int AnimaVaginae => _salsamentumPuellaePersonaeDTO.AnimaVaginae;
        public int SensusAni => _salsamentumPuellaePersonaeDTO.SensusAni;
        public int AnimaAni => _salsamentumPuellaePersonaeDTO.AnimaAni;
        public int SensusAusculum => _salsamentumPuellaePersonaeDTO.SensusAusculum;
        public int AnimaAusculum => _salsamentumPuellaePersonaeDTO.AnimaAusculum;
        public int SensusCorporis => _salsamentumPuellaePersonaeDTO.SensusCorporis;
        public int AnimaCorporis => _salsamentumPuellaePersonaeDTO.AnimaCorporis;
    }
}