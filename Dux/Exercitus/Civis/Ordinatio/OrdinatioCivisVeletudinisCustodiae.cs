using System;
using Yulinti.Nucleus;

namespace Yulinti.Dux.Exercitus {
    internal enum SpeciesOrdinationisCivisCustodiae {
        Nihil,
        Visa,
        Detectio
    }

    internal readonly struct OrdinatioCivisCustodiaeVisa {
        public readonly float DtVisa { get; }

        public OrdinatioCivisCustodiaeVisa(float dtVisa) {
            DtVisa = dtVisa;
        }
    }

    internal readonly struct OrdinatioCivisCustodiaeDetectio {
        public readonly bool EstVigilantia { get; }
        public readonly bool EstDetectio { get; }

        public OrdinatioCivisCustodiaeDetectio(bool estVigilantia, bool estDetectio) {
            EstVigilantia = estVigilantia;
            EstDetectio = estDetectio;
        }
    }

    internal readonly struct OrdinatioCivisVeletudinisCustodiae {
        public readonly SpeciesOrdinationisCivisCustodiae Species { get; }
        private readonly int _idCivis;
        private readonly OrdinatioCivisCustodiaeVisa _visa;
        private readonly OrdinatioCivisCustodiaeDetectio _detectio;

        private OrdinatioCivisVeletudinisCustodiae(
            int idCivis,
            OrdinatioCivisCustodiaeVisa visa
        ) {
            Species = SpeciesOrdinationisCivisCustodiae.Visa;
            _idCivis = idCivis;
            _visa = visa;
            _detectio = default;
        }

        private OrdinatioCivisVeletudinisCustodiae(
            int idCivis,
            OrdinatioCivisCustodiaeDetectio detectio
        ) {
            Species = SpeciesOrdinationisCivisCustodiae.Detectio;
            _idCivis = idCivis;
            _visa = default;
            _detectio = detectio;
        }

        // Nihil生成
        private OrdinatioCivisVeletudinisCustodiae(int idCivis) {
            Species = SpeciesOrdinationisCivisCustodiae.Nihil;
            _idCivis = idCivis;
            _visa = default;
            _detectio = default;
        }

        public bool EstApplicandum {
            get {
                return Species != SpeciesOrdinationisCivisCustodiae.Nihil;
            }
        }

        public static OrdinatioCivisVeletudinisCustodiae FromVisa(int idCivis, OrdinatioCivisCustodiaeVisa visa) {
            return new(idCivis, visa);
        }
        public static OrdinatioCivisVeletudinisCustodiae FromDetectio(int idCivis, OrdinatioCivisCustodiaeDetectio detectio) {
            return new(idCivis, detectio);
        }
        public static OrdinatioCivisVeletudinisCustodiae Nihil(int idCivis) {
            return new(idCivis);
        }

        public int IdCivis {
            get {
                return _idCivis;
            }
        }

        public OrdinatioCivisCustodiaeVisa Visa {
            get {
                return _visa;
            }
        }
        public OrdinatioCivisCustodiaeDetectio Detectio {
            get {
                return _detectio;
            }
        }

        public void Match(
            Action<OrdinatioCivisCustodiaeVisa> visa,
            Action<OrdinatioCivisCustodiaeDetectio> detectio
        ) {
            switch (Species) {
                case SpeciesOrdinationisCivisCustodiae.Visa:
                    visa(Visa);
                    return;
                case SpeciesOrdinationisCivisCustodiae.Detectio:
                    detectio(Detectio);
                    return;
                case SpeciesOrdinationisCivisCustodiae.Nihil:
                    return;
                default:
                    Memorator.MemorareErrorum(IDErrorum.ORDINATIOCIVISVELETUDINISCUSTODIAE_INVALID_SPECIES);
                    return;
            }
        }
    }
}