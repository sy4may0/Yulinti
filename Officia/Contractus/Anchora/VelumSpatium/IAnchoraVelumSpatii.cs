namespace Yulinti.Officia.Contractus {
    public interface IAnchoraVelumSpatii : IAnchora {
        void Incarnare();
        void Spirituare();
        bool EstActivum { get; }

        void IncarnareCorrigere();
        void SpirituareCorrigere();
        bool EstActivumCorrigere { get; }
    }
}