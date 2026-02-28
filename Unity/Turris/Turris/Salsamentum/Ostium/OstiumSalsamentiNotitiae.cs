using Yulinti.Exercitus.Contractus;
using System;

namespace Yulinti.Unity.Turris {
    internal sealed class OstiumSalsamentiNotitiae : IOstiumSalsamentiNotitiae {
        private Guid _id;
        private DateTime _timestamp;
        private SalsamentumNotitiaeDto _salsamentumNotitiaeDto;
        private OstiumSalsamentiPuellaeNotitiae _puellaeNotitiae;
        private bool _estActivum;

        public Guid Id => _id;
        public DateTime Timestamp => _timestamp;
        public IOstiumSalsamentiPuellaeNotitiae PuellaeNotitiae => _puellaeNotitiae;

        public OstiumSalsamentiNotitiae() {
            _id = Guid.Empty;
            _timestamp = DateTime.MinValue;
            _salsamentumNotitiaeDto = new SalsamentumNotitiaeDto();
            _puellaeNotitiae = new OstiumSalsamentiPuellaeNotitiae(_salsamentumNotitiaeDto.PuellaeNotitiae);
            _estActivum = false;
        }

        // Thesaurusからのデータ更新
        public void Renovare(Guid id, DateTime timestamp, SalsamentumNotitiaeDto salsamentumNotitiaeDto) {
            _id = id;
            _timestamp = timestamp;
            _salsamentumNotitiaeDto = salsamentumNotitiaeDto;
            _puellaeNotitiae.Renovare(_salsamentumNotitiaeDto.PuellaeNotitiae);
            _estActivum = true;
        }

        // 内部からのデータ更新
        public void Renovare(Guid id, IResFluidaPuellaePersonaeLegibile resFluidaPuellaePersonae) {
            _id = id;
            _timestamp = DateTime.Now;
            _puellaeNotitiae.Renovare(resFluidaPuellaePersonae);
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