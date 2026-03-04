using Yulinti.Exercitus.Contractus;
using System;

namespace Yulinti.Unity.Turris {
    internal sealed class OstiumSalsamenti : IOstiumSalsamenti {
        private Guid _id;
        private DateTime _timestamp;
        private SalsamentumDto _salsamentumDto;
        private OstiumSalsamentiPuellae _puellae;
        private bool _estActivum;

        public Guid Id => _id;
        public DateTime Timestamp => _timestamp;
        public IOstiumSalsamentiPuellae Puellae => _puellae;

        public OstiumSalsamenti() {
            _id = new Guid();
            _timestamp = DateTime.MinValue;
            _salsamentumDto = new SalsamentumDto();
            _puellae = new OstiumSalsamentiPuellae(_salsamentumDto.Puellae);
            _estActivum = false;
        }

        // Thesaurusからのデータ更新
        public void Renovare(Guid id, DateTime timestamp, SalsamentumDto salsamentumDto) {
            _id = id;
            _timestamp = timestamp;
            _salsamentumDto = salsamentumDto;
            _puellae.Renovare(_salsamentumDto.Puellae);
            _estActivum = true;
        }

        // 内部からのデータ更新
        public void Renovare(Guid id, IPhantasmaPuellaePersonae phantasmaPuellaePersonae) {
            _id = id;
            _timestamp = DateTime.Now;
            _puellae.Renovare(phantasmaPuellaePersonae);
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
