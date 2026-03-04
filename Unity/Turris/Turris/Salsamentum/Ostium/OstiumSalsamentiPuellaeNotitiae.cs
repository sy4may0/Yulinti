using Yulinti.Exercitus.Contractus;

namespace Yulinti.Unity.Turris {
    internal sealed class OstiumSalsamentiPuellaeNotitiae : IOstiumSalsamentiPuellaeNotitiae {
        private SalsamentumPuellaeNotitiaeDto _puellaeNotitiaeDto;

        public int GradusLuxuriosus => _puellaeNotitiaeDto.GradusLuxuriosus;
        public int GradusExhibitus => _puellaeNotitiaeDto.GradusExhibitus;
        public int GradusPerversus => _puellaeNotitiaeDto.GradusPerversus;
        public int GradusQuaeritDolore => _puellaeNotitiaeDto.GradusQuaeritDolore;

        public OstiumSalsamentiPuellaeNotitiae(SalsamentumPuellaeNotitiaeDto puellaeNotitiaeDto) {
            _puellaeNotitiaeDto = puellaeNotitiaeDto;
        }

        // Thesaurusからのデータ更新
        public void Renovare(SalsamentumPuellaeNotitiaeDto puellaeNotitiaeDto) {
            _puellaeNotitiaeDto = puellaeNotitiaeDto;
        }

        // 内部からのデータ更新
        public void Renovare(IPhantasmaPuellaePersonae phantasmaPuellaePersonae) {
            _puellaeNotitiaeDto.Renovare(phantasmaPuellaePersonae);
        }
    }
}
