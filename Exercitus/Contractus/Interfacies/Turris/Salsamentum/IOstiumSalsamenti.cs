using System;

namespace Yulinti.Exercitus.Contractus {
    public interface IOstiumSalsamenti {
        Guid Id { get; }
        DateTime Timestamp { get; }
        IOstiumSalsamentiPuellae Puellae { get; }
        bool EstActivum { get; }
    }
}