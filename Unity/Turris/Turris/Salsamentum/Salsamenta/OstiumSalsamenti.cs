using Yulinti.Exercitus.Contractus;

namespace Yulinti.Unity.Turris {
    internal sealed class OstiumSalsamenti : IOstiumSalsamenti {
        private readonly SalsamentumDTO _salsamentumDTO;
        private readonly IOstiumSalsamentiPuellaePersonae _puellaePersonae;

        public OstiumSalsamenti(SalsamentumDTO salsamentumDTO) {
            _salsamentumDTO = salsamentumDTO;
            _puellaePersonae = new OstiumSalsamentiPuellaePersonae(_salsamentumDTO.PuellaePersonae);
        }

        public int IdDatumServatum => _salsamentumDTO.IdDatumServatum;
        public int Versio => _salsamentumDTO.Versio;
        public long Revisio => _salsamentumDTO.Revisio;
        public string Dies => _salsamentumDTO.Dies;
        public IOstiumSalsamentiPuellaePersonae PuellaePersonae => _puellaePersonae;
    }
}