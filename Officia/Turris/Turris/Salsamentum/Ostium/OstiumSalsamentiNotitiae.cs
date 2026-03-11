using Yulinti.ImperiumDelegatum.Contractus;
using System;

namespace Yulinti.Officia.Turris {
    internal sealed class OstiumSalsamentiNotitiae : IOstiumSalsamentiNotitiae {
        private Guid _id;
        private DateTime _timestamp;
        private SalsamentumNotitiaeDto _salsamentumNotitiaeDto;
        private OstiumSalsamentiPuellaePersonaeNotitiae _puellaePersonaeNotitiae;
        private bool _estActivum;

        public Guid Id => _id;
        public DateTime Timestamp => _timestamp;
        public IOstiumSalsamentiPuellaePersonaeNotitiae PuellaePersonaeNotitiae => _puellaePersonaeNotitiae;

        public OstiumSalsamentiNotitiae() {
            _id = Guid.Empty;
            _timestamp = DateTime.MinValue;
            _salsamentumNotitiaeDto = new SalsamentumNotitiaeDto();
            _puellaePersonaeNotitiae = new OstiumSalsamentiPuellaePersonaeNotitiae(_salsamentumNotitiaeDto.PuellaePersonaeNotitiae);
            _estActivum = false;
        }

        // Thesaurusからのデータ更新
        public void Renovare(Guid id, DateTime timestamp, SalsamentumNotitiaeDto salsamentumNotitiaeDto) {
            _id = id;
            _timestamp = timestamp;
            _salsamentumNotitiaeDto = salsamentumNotitiaeDto;
            _puellaePersonaeNotitiae.Renovare(_salsamentumNotitiaeDto.PuellaePersonaeNotitiae);
            _estActivum = true;
        }

        // 内部からのデータ更新
        public void Renovare(Guid id, IPhantasmaPuellaePersonae phantasmaPuellaePersonae) {
            _id = id;
            _timestamp = DateTime.Now;
            _puellaePersonaeNotitiae.Renovare(phantasmaPuellaePersonae);
            _estActivum = true;
        }

        public void Purgare() {
            _id = Guid.Empty;
            _timestamp = DateTime.MinValue;
            _estActivum = false;
        }

        public SalsamentumNotitiaeDto SalsamentumNotitiaeDto => _salsamentumNotitiaeDto;
        public bool EstActivum => _estActivum;
    }
}
