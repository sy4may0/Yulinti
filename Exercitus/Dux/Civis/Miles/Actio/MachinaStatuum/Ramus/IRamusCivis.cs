using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal interface IRamusCivis {
        int Prioritas { get; }
        bool Condicio(
            int idCivis,
            ContextusCivisOstiorumLegibile contextus,
            IResFluidaCivisLegibile resFluida
        );
    }
}