namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IConfiguratioExercitusCivis {
        IConfiguratioCivisStatuum Statuum { get; }
        IConfiguratioCivisCustodiaeIctuum CustodiaeIctuum { get; }
        IConfiguratioCivisCustodiaeStatus CustodiaeStatus { get; }
        IConfiguratioCivisGenerationis Generationis { get; }
    }
}