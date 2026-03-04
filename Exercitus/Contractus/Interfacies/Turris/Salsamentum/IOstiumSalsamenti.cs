using System;

namespace Yulinti.Exercitus.Contractus {
    public interface IOstiumSalsamenti {
        Guid Id { get; }
        DateTime Timestamp { get; }
        IOstiumSalsamentiPuellaePersonae PuellaePersonae { get; }
        bool EstActivum { get; }
    }
}