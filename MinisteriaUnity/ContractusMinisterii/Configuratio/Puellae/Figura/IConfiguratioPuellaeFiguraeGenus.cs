namespace Yulinti.MinisteriaUnity.ContractusMinisterii {
    public interface IConfiguratioPuellaeFiguraeGenus {
        string X90BlendShapeName { get; }
        string X150BlendShapeName { get; }
        string X120OffsetBlendShapeName { get; }
    }

    // VContainerのため。分割する。
    public interface IConfiguratioPuellaeFiguraeGenusSinister : IConfiguratioPuellaeFiguraeGenus {
    }
    public interface IConfiguratioPuellaeFiguraeGenusDexter : IConfiguratioPuellaeFiguraeGenus {
    }
}
