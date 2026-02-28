namespace Yulinti.Exercitus.Contractus {
    public interface IConfiguratioExercitusCivis {
        IConfiguratioCivisStatuum Statuum { get; }
        IConfiguratioCivisCustodiae Custodiae { get; }
    }
}