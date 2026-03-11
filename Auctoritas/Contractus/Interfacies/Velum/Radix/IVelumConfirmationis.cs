using System;

namespace Yulinti.Auctoritas.Contractus {
    public interface IVelumConfirmationis {
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