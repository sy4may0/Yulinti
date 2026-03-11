using Yulinti.ImperiumDelegatum.Contractus;
namespace Yulinti.Officia.Contractus {
    public interface IConfiguratioPunctumViae {
        IDPunctumViaeTypi[] Crematorium { get; }
        IDPunctumViaeTypi[] Natorium { get; }
        IDPunctumViaeTypi[] Aditrium { get; }
    }
}