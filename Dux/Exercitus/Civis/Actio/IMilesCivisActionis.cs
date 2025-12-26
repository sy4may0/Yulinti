using Yulinti.Dux.ContractusDucis;

namespace Yulinti.Dux.Exercitus {
    internal interface IMilesCivisActionis {
        void Opero(
          ContextusCivisOstiorumLegibile contextusOstiorum,
          ContextusCivisResFluidaLegibile contextusResFluida
        );

        void RenovareResFluida(ref ResFluidaCivis resFluida);
    }
}