using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal interface IRamusCivis {
        int Prioritas { get; }
        bool Condicio(
            ContextusCivisOstiorumLegibile contextusOstiorum,
            ContextusCivisResFluidaLegibile contextusResFluida
        );
    }
}
