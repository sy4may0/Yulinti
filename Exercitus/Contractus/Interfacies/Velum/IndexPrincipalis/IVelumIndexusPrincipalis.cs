using Yulinti.Exercitus.Contractus;

namespace Yulinti.Exercitus.Contractus {
    public interface IVelumIndexusPrincipalis {
        // タイトルUIを表示
        void DemittereIndexusPrincipalis();
        // セーブデータリストUIを表示
        void DemittereSelectorisSalsamenti();
        // オプションUIを表示
        void DemittereOptiones();

        void ActivareButton(ButtonIndexusPrincipalis buttonIndexusPrincipalis);
        void DeactivateButton(ButtonIndexusPrincipalis buttonIndexusPrincipalis);
    }
}