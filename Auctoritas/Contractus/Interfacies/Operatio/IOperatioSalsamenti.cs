using System;

namespace Yulinti.Auctoritas.Contractus {
    public interface IOperatioSalsamenti {
        void Executare(UsusSalsamenti usus, Guid id);
        void Executare(UsusSalsamenti usus);
    }
}