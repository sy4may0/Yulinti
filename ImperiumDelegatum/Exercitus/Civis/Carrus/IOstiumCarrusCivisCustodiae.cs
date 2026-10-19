using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOstiumCarrusCivisCustodiae {
        void PostulareCustodiaeDistantia(
            int idCivis,
            float distantiaPuellae,
            bool estCustodiaeVisae,
            bool estCustodiaeAuditae
        );

        void PostulareCustodiaeIctuumVisae(
            int idCivis,
            float visaCapitis,
            float visaCorporis
        );

        void PostulareCustodiaeIctuumAuditae(
            int idCivis,
            float audita
        );

        void PostulareSpectareNudus(
            int idCivis,
            bool? estSpectareNudusAnterior = null,
            bool? estSpectareNudusPosterior = null
        );
    }
}
