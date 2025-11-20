using UnityEngine;
using Yulinti.MinisteriaUnity;
using Yulinti.MinisteriaUnity.Interna;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Dux.ConfiguratioDucis;
using Yulinti.Rex.Interna;

namespace Yulinti.Rex {
    public sealed class RexTestScene : MonoBehaviour {
        [SerializeField] private FasciculusConfigurationum _configurationum;
        [SerializeField] private FasciculusConfigurationumDucis _configurationumDucis;
        private FonsTemporis _fonsTemporis;
        private Ministeria _ministeria;
        private PraefectusDucum _praefectusDucum;

        private void Awake() {
            _fonsTemporis = new FonsTemporis();
            _ministeria = new Ministeria(_configurationum, _fonsTemporis);
            _praefectusDucum = new PraefectusDucum(_configurationumDucis, _ministeria.OstiorumRationis);
        }

        private void Start() {
        }

        private void Update() {
            _fonsTemporis.Pulsus();
            _praefectusDucum.Pulsus();
            _ministeria.Pulsus();
            _praefectusDucum.PulsusPostRationem();
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