namespace Yulinti.Dux.ContractusDucis {
    public interface IOstiiPuellae {
        IOstiumPuellaeLociLegibile LociLeg { get; }
        IOstiumPuellaeLociMutabile LociMut { get; }
        IOstiumPuellaeOssisLegibile OssisLeg { get; }
        IOstiumPuellaeOssisMutabile OssisMut { get; }
        IOstiumPuellaeFiguraeGenusLegibile FiguraeGenusLeg { get; }
        IOstiumPuellaeFiguraeGenusMutabile FiguraeGenusMut { get; }
        IOstiumPuellaeFiguraePelvisLegibile FiguraePelvisLeg { get; }
        IOstiumPuellaeFiguraePelvisMutabile FiguraePelvisMut { get; }
        IOstiumPuellaeRelationisTerraeLegibile RelationisTerraeLeg { get; }
        IOstiumPuellaeAnimationesMutabile AnimationesMut { get; }
    }
}