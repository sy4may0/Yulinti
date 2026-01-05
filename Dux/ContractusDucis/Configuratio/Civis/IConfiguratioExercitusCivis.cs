namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioExercitusCivis {
        IConfiguratioCivisStatuum Statuum { get; }
        IConfiguratioCivisCustodiae Custodiae { get; }
    }
}