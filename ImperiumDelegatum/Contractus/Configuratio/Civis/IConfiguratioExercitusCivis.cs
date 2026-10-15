namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IConfiguratioExercitusCivis {
        IConfiguratioCivisStatuum Statuum { get; }
        IConfiguratioCivisCustodiaeIctuum CustodiaeIctuum { get; }
        IConfiguratioCivisCustodiaeStatuum CustodiaeStatuum { get; }
        IConfiguratioCivisGenerationis Generationis { get; }
        IConfiguratioCiviumPersonarum Personae { get; }
    }
}