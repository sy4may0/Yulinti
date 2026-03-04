using Yulinti.Exercitus.Contractus;

namespace Yulinti.Unity.Turris {
    internal sealed class OstiumSalsamentiPuellae : IOstiumSalsamentiPuellae {
        private SalsamentumPuellaeDto _puellaeDto;

        public int GradusLuxuriosus => _puellaeDto.GradusLuxuriosus;
        public int AnimaLuxuriosus => _puellaeDto.AnimaLuxuriosus;
        public int GradusExhibitus => _puellaeDto.GradusExhibitus;
        public int AnimaExhibitus => _puellaeDto.AnimaExhibitus;
        public int GradusPerversus => _puellaeDto.GradusPerversus;
        public int AnimaPerversus => _puellaeDto.AnimaPerversus;
        public int GradusQuaeritDolore => _puellaeDto.GradusQuaeritDolore;
        public int AnimaQuaeritDolore => _puellaeDto.AnimaQuaeritDolore;
        public int SensusPapillae => _puellaeDto.SensusPapillae;
        public int AnimaPapillae => _puellaeDto.AnimaPapillae;
        public int SensusLandicae => _puellaeDto.SensusLandicae;
        public int AnimaLandicae => _puellaeDto.AnimaLandicae;
        public int SensusVaginae => _puellaeDto.SensusVaginae;
        public int AnimaVaginae => _puellaeDto.AnimaVaginae;
        public int SensusAni => _puellaeDto.SensusAni;
        public int AnimaAni => _puellaeDto.AnimaAni;
        public int SensusAusculum => _puellaeDto.SensusAusculum;
        public int AnimaAusculum => _puellaeDto.AnimaAusculum;
        public int SensusCorporis => _puellaeDto.SensusCorporis;
        public int AnimaCorporis => _puellaeDto.AnimaCorporis;

        public OstiumSalsamentiPuellae(SalsamentumPuellaeDto puellaeDto) {
            _puellaeDto = puellaeDto;
        }

        // Thesaurusからのデータ更新
        public void Renovare(SalsamentumPuellaeDto puellaeDto) {
            _puellaeDto = puellaeDto;
        }

        // 内部からのデータ更新
        public void Renovare(IPhantasmaPuellaePersonae phantasmaPuellaePersonae) {
            _puellaeDto.Renovare(phantasmaPuellaePersonae);
        }
    }
}
