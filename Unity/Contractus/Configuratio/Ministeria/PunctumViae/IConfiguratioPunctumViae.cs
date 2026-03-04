using Yulinti.Exercitus.Contractus;
namespace Yulinti.Unity.Contractus {
    public interface IConfiguratioPunctumViae {
        IDPunctumViaeTypi[] Crematorium { get; }
        IDPunctumViaeTypi[] Natorium { get; }
        IDPunctumViaeTypi[] Aditrium { get; }
    }
}