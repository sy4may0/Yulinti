namespace Yulinti.Nucleus.Contractus {
    public interface IHorologium {
        bool EstActivum { get; }
        void Activare();
        void Deactivare();
        bool EstExhaurita(float intervullum);
        void Purgere();
    }
}