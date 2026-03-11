using System;

namespace Yulinti.Auctoritas.Contractus {
    public interface IVelumMonitionis {
        void Initare();
        void DemittereMonitionis(
            string titulus,
            string textus,
            string buttonIta,
            Action adPremereIta = null
        );
        void TollereMonitionis();
    }
}