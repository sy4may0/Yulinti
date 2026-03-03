using System;

namespace Yulinti.Exercitus.Contractus {
    public interface IOstiumSalsamentiNotitiae {
        Guid Id { get; }
        DateTime Timestamp { get; }
        IOstiumSalsamentiPuellaeNotitiae PuellaeNotitiae { get; }
        bool EstActivum { get; }
    }
}