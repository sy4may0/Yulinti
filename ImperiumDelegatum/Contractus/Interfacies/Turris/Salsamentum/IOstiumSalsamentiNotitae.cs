using System;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IOstiumSalsamentiNotitiae {
        Guid Id { get; }
        DateTime Timestamp { get; }
        IOstiumSalsamentiPuellaePersonaeNotitiae PuellaePersonaeNotitiae { get; }
        bool EstActivum { get; }
    }
}