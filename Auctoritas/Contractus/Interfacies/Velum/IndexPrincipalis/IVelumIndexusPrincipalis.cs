namespace Yulinti.Auctoritas.Contractus {
    public interface IVelumIndexusPrincipalis {
        // タイトルUIを表示
        void DemittereIndexusPrincipalis();
        // タイトルUIを非表示
        void TollereIndexusPrincipalis();

        void ActivareUsus(UsusIndexusPrincipalis usus);
        void DeactivareUsus(UsusIndexusPrincipalis usus);
    }
}
