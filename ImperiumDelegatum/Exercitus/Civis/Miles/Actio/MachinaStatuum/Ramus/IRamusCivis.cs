using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal interface IRamusCivis {
        int Prioritas { get; }
        bool Condicio(
            int idCivis,
            ContextusCivisOstiorumLegibile contextus,
            IResFluidaCivisLegibile resFluida
        );
    }
}