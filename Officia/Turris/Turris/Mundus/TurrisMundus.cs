using Yulinti.ImperiumDelegatum.Contractus;
using UnityEngine.SceneManagement;
namespace Yulinti.Officia.Turris {
    public sealed class TurrisMundus : ITurrisMundus, ITurrisIncipabilis {
        public TurrisMundus() {
        }

        // メニューからの遷移はここで行う。
        public void Incipere() {
            AdMundum(IDMundi.MundusMenu);
        }

        public void AdMundum(IDMundi mundus) {
            SceneManager.LoadScene(mundus switch {
                IDMundi.MundusTestScene => "SampleScene",
                IDMundi.MundusMenu => "MenuScene",
                IDMundi.MundusPortus => "PortusScene",
                _ => throw new System.Exception("Invalid IDMundi")
            });
        }
    }
}