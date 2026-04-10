namespace Yulinti.Auctoritas.Contractus.Velum.Portus {
    public interface IVelumPortusConstructionis {
        // Assembly画面を表示
        void DemitterePortusConstructionis();
        // Assembly画面を非表示
        void TollerePortusConstructionis();

        void PonoPermissionemUsus(UsusPortusConstructionis usus, bool permissio);
    }
}