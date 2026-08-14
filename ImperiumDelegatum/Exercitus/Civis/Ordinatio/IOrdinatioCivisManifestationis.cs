using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IOrdinatioCivisManifestationis {
        IDCivisPersonae IdCivisPersonae { get; }
        bool EstApplicandum { get; }
        void Initare();
        void Liberare();
        void Purgere();
    }
}
