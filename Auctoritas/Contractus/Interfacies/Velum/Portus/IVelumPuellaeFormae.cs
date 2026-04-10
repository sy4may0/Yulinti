namespace Yulinti.Auctoritas.Contractus.Velum.Portus {
    public interface IVelumPortusPuellaeFormae {
        // Assembly - PuellaeFormae画面を表示
        void DemitterePortusPuellaeFormae();
        // Assembly - PuellaeFormae画面を非表示
        void TollerePortusPuellaeFormae();

        void PonoPermissionemUsus(UsusPortusPuellaeFormae usus, bool permissio);
    }
}