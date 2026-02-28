using Yulinti.Exercitus.Contractus;
using System;

namespace Yulinti.Exercitus.Contractus {
    public interface IVelumConfirmationis {
        void Initare();
        void DemittereConfirmationis(
            string titulus,
            string textus,
            string buttonIta,
            string buttonNon,
            Action adPremereIta = null,
            Action adPremereNon = null
        );
        void TollereConfirmationis();
    }
}