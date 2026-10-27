namespace Yulinti.Officia.Contractus {
    public interface IConfiguratioPuellaeCrinisCollectionis {
        IConfiguratioPuellaeCrinisCollectionisAnterior[] Anterior { get; }
        IConfiguratioPuellaeCrinisCollectionisPosterior[] Posterior { get; }
    }
}