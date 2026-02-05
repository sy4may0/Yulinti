using Yulinti.Exercitus.Contractus;
using System;

namespace Yulinti.Unity.Deus {
    [Serializable]
    internal sealed class SalsamentumDTO {
        public int IdDatumServatum;
        public int Versio;
        public long Revisio;
        public string Dies;
        public SalsamentumPuellaePersonaeDTO PuellaePersonae;

        public SalsamentumDTO(
            int idDatumServatum, int versio, long revisio, string dies
        ) {
            IdDatumServatum = idDatumServatum;
            Versio = versio;
            Dies = dies;
            Revisio = 0;
            PuellaePersonae = new SalsamentumPuellaePersonaeDTO();
        }

        public bool Validare() {
            if (IdDatumServatum >= ConstansDeus.MaximusNumerusDatumServatum || IdDatumServatum < 0) return false;
            if (Versio < 0) return false;
            if (Revisio < 0) return false;
            if (string.IsNullOrEmpty(Dies)) return false;
            if (PuellaePersonae == null) return false;
            if (!PuellaePersonae.Validare()) return false;
            return true;
        }
    }
}