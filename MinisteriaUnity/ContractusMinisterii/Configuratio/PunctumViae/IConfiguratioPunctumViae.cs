using Yulinti.Dux.ContractusDucis;
namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IConfiguratioPunctumViae {
        IDPunctumViaeTypi[] Crematorium { get; }
        IDPunctumViaeTypi[] Natorium { get; }
        IDPunctumViaeTypi[] Aditrium { get; }
    }
}