namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IConfiguratioExercitusCivis {
        IConfiguratioCivisStatuum Statuum { get; }
        IConfiguratioCivisCustodiaeIctuum CustodiaeIctuum { get; }
        IConfiguratioCivisGenerationis Generationis { get; }
        IConfiguratioCiviumPersonarum Personae { get; }
    }
}