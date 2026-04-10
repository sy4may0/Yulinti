namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IConfiguratioExercitusCivis {
        IConfiguratioCivisStatuum Statuum { get; }
        IConfiguratioCivisCustodiae Custodiae { get; }
        IConfiguratioCivisGenerationis Generationis { get; }
    }
}