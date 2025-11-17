using UnityEngine;
using Yulinti.MinisteriaUnity;
using Yulinti.MinisteriaUnity.Interna;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.ContractusMinisterii.Puellae;

namespace Yulinti.Rex {
    public sealed class RexTestScene : MonoBehaviour {
        [SerializeField] private FasciculusConfigurationum _configurationum;
        private FonsTemporis _fonsTemporis;
        private Ministeria _ministeria;

        private void Awake() {
            _fonsTemporis = new FonsTemporis();
            _ministeria = new Ministeria(_configurationum, _fonsTemporis);
        }

        private void Start() {
        }

        private void Update() {
            _fonsTemporis.Pulsus();
            _ministeria.Pulsus();
            // MoveTest
            _ministeria.Puellae.LocusMut.AddoVelocitatemHorizontalisLate(1f, 0.1f, _fonsTemporis.Intervalum);

            // AnimationTest
            _ministeria.Puellae.AnimatioMut.PostulareFundamenti(
                IDPuellaeAnimationisBasis.StandardBase, 
                null,
                false
            );
            _ministeria.Puellae.AnimatioMut.InjicereVelocitatem(1f);

        }

        private void FixedUpdate() {
            _fonsTemporis.PulsusFixus();
            _ministeria.PulsusFixus();
        }

        private void LateUpdate() {
            _ministeria.PulsusTardus();
        }
    }
}