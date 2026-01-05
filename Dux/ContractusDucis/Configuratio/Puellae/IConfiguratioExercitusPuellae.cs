namespace Yulinti.Dux.ContractusDucis {
    public interface IConfiguratioExercitusPuellae {
        IConfiguratioPuellaeStatuum Statuum { get; }
        IConfiguratioPuellaeActionisSecundarius ActionisSecundarius { get; }
        IConfiguratioPuellaeVeletudinis Veletudo { get; }
    }
}