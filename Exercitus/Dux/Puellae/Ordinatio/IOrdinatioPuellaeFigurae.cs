using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Dux {
    internal enum LatusPuellaeGenus {
        Sinistra,
        Dextra
    }

    internal interface IOrdinatioPuellaeFiguraeGenus : IOrdinatioPuellae {
        IDPuellaeFiguraeGenus IdFiguraeGenus { get; }
        LatusPuellaeGenus Latus { get; }
        float Pondus { get; }
    }

    internal interface IOrdinatioPuellaeFiguraePelvis : IOrdinatioPuellae {
        IDPuellaeFiguraePelvis IdFiguraePelvis { get; }
        float Pondus { get; }
    }
}