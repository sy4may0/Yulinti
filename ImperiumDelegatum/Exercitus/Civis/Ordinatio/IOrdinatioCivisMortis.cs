namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal enum SpeciesOrdinationisCivisMortis {
        Nihil,
        Spirituare,
        Incarnare,
        Deleto,
    }
    internal interface IOrdinatioCivisMortis : IOrdinatioCivis {
        SpeciesOrdinationisCivisMortis SpeciesMortis { get; }
    }
}