namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IConfiguratioPuellaeAnimationisContinuata {
        IDPuellaeAnimationisStratum Stratum { get; }
        IDPuellaeAnimationisContinuata Id { get; }
        IConfiguratioPuellaeAnimationisUnicae[] Animationes { get; }
    }
}