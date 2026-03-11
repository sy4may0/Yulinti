namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal enum SpeciesOrdinationisCivisMortis {
        Nihil,
        Spirituare,
        Incarnare,
    }
    internal interface IOrdinatioCivisMortis : IOrdinatioCivis {
        SpeciesOrdinationisCivisMortis SpeciesMortis { get; }
    }
}