using System.Numerics;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IResFluidaPuellaeFormaeLegibile {
        bool EstApplicandum { get; }
        Vector3 MagnitudoActualis(IDPuellaeFormae idFormae);
    }
}