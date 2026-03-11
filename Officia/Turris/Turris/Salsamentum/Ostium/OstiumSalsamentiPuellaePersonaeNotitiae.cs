using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Officia.Turris {
    internal sealed class OstiumSalsamentiPuellaePersonaeNotitiae : IOstiumSalsamentiPuellaePersonaeNotitiae {
        private SalsamentumPuellaePersonaeNotitiaeDto _puellaePersonaeNotitiaeDto;

        public int GradusLuxuriosus => _puellaePersonaeNotitiaeDto.GradusLuxuriosus;
        public int GradusExhibitus => _puellaePersonaeNotitiaeDto.GradusExhibitus;
        public int GradusPerversus => _puellaePersonaeNotitiaeDto.GradusPerversus;
        public int GradusQuaeritDolore => _puellaePersonaeNotitiaeDto.GradusQuaeritDolore;

        public OstiumSalsamentiPuellaePersonaeNotitiae(SalsamentumPuellaePersonaeNotitiaeDto puellaeNotitiaeDto) {
            _puellaePersonaeNotitiaeDto = puellaeNotitiaeDto;
        }

        // Thesaurusからのデータ更新
        public void Renovare(SalsamentumPuellaePersonaeNotitiaeDto puellaeNotitiaeDto) {
            _puellaePersonaeNotitiaeDto = puellaeNotitiaeDto;
        }

        // 内部からのデータ更新
        public void Renovare(IPhantasmaPuellaePersonae phantasmaPuellaePersonae) {
            _puellaePersonaeNotitiaeDto.Renovare(phantasmaPuellaePersonae);
        }
    }
}
