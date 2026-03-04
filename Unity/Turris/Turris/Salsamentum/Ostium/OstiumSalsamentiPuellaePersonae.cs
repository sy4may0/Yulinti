using Yulinti.Exercitus.Contractus;

namespace Yulinti.Unity.Turris {
    internal sealed class OstiumSalsamentiPuellaePersonae : IOstiumSalsamentiPuellaePersonae {
        private SalsamentumPuellaePersonaeDto _puellaePersonaeDto;

        public int GradusLuxuriosus => _puellaePersonaeDto.GradusLuxuriosus;
        public int AnimaLuxuriosus => _puellaePersonaeDto.AnimaLuxuriosus;
        public int GradusExhibitus => _puellaePersonaeDto.GradusExhibitus;
        public int AnimaExhibitus => _puellaePersonaeDto.AnimaExhibitus;
        public int GradusPerversus => _puellaePersonaeDto.GradusPerversus;
        public int AnimaPerversus => _puellaePersonaeDto.AnimaPerversus;
        public int GradusQuaeritDolore => _puellaePersonaeDto.GradusQuaeritDolore;
        public int AnimaQuaeritDolore => _puellaePersonaeDto.AnimaQuaeritDolore;
        public int SensusPapillae => _puellaePersonaeDto.SensusPapillae;
        public int AnimaPapillae => _puellaePersonaeDto.AnimaPapillae;
        public int SensusLandicae => _puellaePersonaeDto.SensusLandicae;
        public int AnimaLandicae => _puellaePersonaeDto.AnimaLandicae;
        public int SensusVaginae => _puellaePersonaeDto.SensusVaginae;
        public int AnimaVaginae => _puellaePersonaeDto.AnimaVaginae;
        public int SensusAni => _puellaePersonaeDto.SensusAni;
        public int AnimaAni => _puellaePersonaeDto.AnimaAni;
        public int SensusAusculum => _puellaePersonaeDto.SensusAusculum;
        public int AnimaAusculum => _puellaePersonaeDto.AnimaAusculum;
        public int SensusCorporis => _puellaePersonaeDto.SensusCorporis;
        public int AnimaCorporis => _puellaePersonaeDto.AnimaCorporis;

        public OstiumSalsamentiPuellaePersonae(SalsamentumPuellaePersonaeDto puellaeDto) {
            _puellaePersonaeDto = puellaeDto;
        }

        // Thesaurusからのデータ更新
        public void Renovare(SalsamentumPuellaePersonaeDto puellaeDto) {
            _puellaePersonaeDto = puellaeDto;
        }

        // 内部からのデータ更新
        public void Renovare(IPhantasmaPuellaePersonae phantasmaPuellaePersonae) {
            _puellaePersonaeDto.Renovare(phantasmaPuellaePersonae);
        }
    }
}
