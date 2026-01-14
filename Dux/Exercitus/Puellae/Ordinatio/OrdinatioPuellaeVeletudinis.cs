using System;

namespace Yulinti.Dux.Exercitus {
    internal readonly struct OrdinatioPuellaeVeletudinis {
        public readonly float DtVigoris { get; }
        public readonly float DtPatientiae { get; }
        public readonly float DtAetheris { get; }
        public readonly float DtIntentio { get; }
        public readonly float DtClaritas { get; }

        public OrdinatioPuellaeVeletudinis(
            float dtVigoris = 0f,
            float dtPatientiae = 0f,
            float dtAetheris = 0f,
            float dtIntentio = 0f,
            float dtClaritas = 0f
        ) {
            DtVigoris = dtVigoris;
            DtPatientiae = dtPatientiae;
            DtAetheris = dtAetheris;
            DtIntentio = dtIntentio;
            DtClaritas = dtClaritas;
        }
    }
}