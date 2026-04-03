namespace Yulinti.ImperiumDelegatum.Contractus {
    public interface IConfiguratioExercitusPuellae {
        IConfiguratioPuellaeStatuum Statuum { get; }
        IConfiguratioPuellaeActionisSecundarius ActionisSecundarius { get; }
        IConfiguratioPuellaeVeletudinis Veletudo { get; }
    }
}