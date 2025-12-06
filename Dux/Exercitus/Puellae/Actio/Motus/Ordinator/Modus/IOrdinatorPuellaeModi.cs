namespace Yulinti.Dux.Exercitus {
    internal interface IOrdinatorPuellaeModi {
        OrdinatioPuellaeMotus Ordinare(
            IResFluidaPuellaeMotusLegibile resFluidaMotus
        );
    }
}