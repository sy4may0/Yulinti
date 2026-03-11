using Yulinti.ImperiumDelegatum.Contractus;
using UnityEngine.SceneManagement;
namespace Yulinti.Officia.Turris {
    public sealed class TurrisMundus : ITurrisMundus {
        public TurrisMundus() {
        }

        public void AdMudum(IDMundi mundus) {
            SceneManager.LoadScene(mundus switch {
                IDMundi.MundusTestScene => "SampleScene",
                IDMundi.MundusMenu => "MenuScene",
                IDMundi.MundusPortus => "PortusScene",
                _ => throw new System.Exception("Invalid IDMundi")
            });
        }
    }
}