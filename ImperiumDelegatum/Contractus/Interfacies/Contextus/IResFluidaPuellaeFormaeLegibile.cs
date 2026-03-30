using System.Numerics;

namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IResFluidaPuellaeFormaeLegibile {
        bool EstApplicandum { get; }
        float RatioActualis(IDPuellaeFormae idFormae);
    }
}