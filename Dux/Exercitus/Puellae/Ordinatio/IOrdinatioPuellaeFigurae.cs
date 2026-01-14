using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.Dux.Exercitus {
    internal enum LatusPuellaeGenus {
        Sinistra,
        Dextra
    }

    internal interface IOrdinatioPuellaeFiguraeGenus : IOrdinatioPuellae {
        IDPuellaeFiguraeGenus IdFiguraeGenus { get; }
        LatusPuellaeGenus Latus { get; }
        float Pondus { get; }

        void Pono(
            IDPuellaeFiguraeGenus idFiguraeGenus,
            float pondus
        );
    }

    internal interface IOrdinatioPuellaeFiguraePelvis : IOrdinatioPuellae {
        IDPuellaeFiguraePelvis IdFiguraePelvis { get; }
        float Pondus { get; }

        void Pono(
            IDPuellaeFiguraePelvis idFiguraePelvis,
            float pondus
        );
    }
}