using Yulinti.Exercitus.Contractus;
using UnityEngine.SceneManagement;
namespace Yulinti.Unity.Turris {
    public sealed class TurrisMundus : ITurrisMundus {
        public TurrisMundus() {
        }

        public void AdMudum(IDMundi mundus) {
            SceneManager.LoadScene(mundus switch {
                IDMundi.MundusTestScene => "SampleScene",
                IDMundi.MundusMenu => "MenuScene",
                _ => throw new System.Exception("Invalid IDMundi")
            });
        }
    }
}