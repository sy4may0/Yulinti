using Yulinti.ImperiumDelegatum.Contractus;
using System;

namespace Yulinti.Officia.Turris {
    internal sealed class OstiumSalsamenti : IOstiumSalsamenti {
        private Guid _id;
        private DateTime _timestamp;
        private SalsamentumDto _salsamentumDto;
        private OstiumSalsamentiPuellaePersonae _puellaePersonae;
        private bool _estActivum;

        public Guid Id => _id;
        public DateTime Timestamp => _timestamp;
        public IOstiumSalsamentiPuellaePersonae PuellaePersonae => _puellaePersonae;

        public OstiumSalsamenti() {
            _id = new Guid();
            _timestamp = DateTime.MinValue;
            _salsamentumDto = new SalsamentumDto();
            _puellaePersonae = new OstiumSalsamentiPuellaePersonae(_salsamentumDto.PuellaePersonae);
            _estActivum = false;
        }

        // Thesaurusからのデータ更新
        public void Renovare(Guid id, DateTime timestamp, SalsamentumDto salsamentumDto) {
            _id = id;
            _timestamp = timestamp;
            _salsamentumDto = salsamentumDto;
            _puellaePersonae.Renovare(_salsamentumDto.PuellaePersonae);
            _estActivum = true;
        }

        // 内部からのデータ更新
        public void Renovare(Guid id, IPhantasmaPuellaePersonae phantasmaPuellaePersonae) {
            _id = id;
            _timestamp = DateTime.Now;
            _puellaePersonae.Renovare(phantasmaPuellaePersonae);
            _estActivum = true;
        }

        public void Purgare() {
            _id = Guid.Empty;
            _timestamp = DateTime.MinValue;
            _estActivum = false;
        }

        public SalsamentumDto SalsamentumDto => _salsamentumDto;
        public bool EstActivum => _estActivum;
    }
}
