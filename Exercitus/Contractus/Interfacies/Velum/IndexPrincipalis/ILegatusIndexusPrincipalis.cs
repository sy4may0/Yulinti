namespace Yulinti.Exercitus.Contractus {
    // メニューUIからDuxへコマンドを送る口。
    public interface ILegatusIndexusPrincipalis {
        // NewGameトリガ
        void PostulareLudusNovus();
        // Continueトリガ
        void PostularePergeLudum();
        // LoadGameトリガ
        void PostulareOneraLudum();
        // Optionsトリガ
        void PostulareOptiones();
        // Exitトリガ
        void PostulareExi();
    }
}