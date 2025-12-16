namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IConfiguratioCivisAnimationisContinuata {
        IDCivisAnimationisStratum Stratum { get; }
        IDCivisAnimationisContinuata Id { get; }
        IConfiguratioCivisAnimationisUnicae[] Animationes { get; }
    }
}