using System;

namespace Yulinti.Auctoritas.Contractus {
    public interface IVelumMonitionis {
        void DemittereMonitionis(
            string titulus,
            string textus,
            string buttonIta,
            Action adPremereIta = null
        );
        void TollereMonitionis();
    }
}