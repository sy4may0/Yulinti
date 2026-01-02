using System;

namespace Yulinti.Dux.Exercitus {
    internal readonly struct OrdinatioPuellaeVeletudinis {
        public readonly float DtVigoris { get; }
        public readonly float DtPatientiae { get; }
        public readonly float DtClaritatis { get; }
        public readonly float DtAetheris { get; }
        public readonly float DtIntentionis { get; }

        public OrdinatioPuellaeVeletudinis(
            float dtVigoris = 0f,
            float dtPatientiae = 0f,
            float dtClaritatis = 0f,
            float dtAetheris = 0f,
            float dtIntentionis = 0f
        ) {
            DtVigoris = dtVigoris;
            DtPatientiae = dtPatientiae;
            DtClaritatis = dtClaritatis;
            DtAetheris = dtAetheris;
            DtIntentionis = dtIntentionis;
        }
    }
}