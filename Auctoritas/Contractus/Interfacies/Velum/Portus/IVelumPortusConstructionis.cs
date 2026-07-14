namespace Yulinti.Auctoritas.Contractus {
    public interface IVelumPortusConstructionis {
        void DemittereConstructionis();
        void TollereConstructionis();

        void PonoPermissionemUsus(UsusPortusConstructionis usus, bool permissio);
    }
}