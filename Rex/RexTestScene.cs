using UnityEngine;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.MinisteriaUnity.ConfiguratioDucis;
using Yulinti.Dux.Thesaurus;
using Yulinti.Dux.Miles;

namespace Yulinti.Rex {
    public sealed class RexTestScene : MonoBehaviour {
        [SerializeField] private FasciculusConfigurationum _configurationum;
        [SerializeField] private FasciculusConfigurationumDucis _configurationumDucis;
        private Ministeria _ministeria;
        private PraefectusDucum _praefectusDucum;

        private void Awake() {
            _ministeria = new Ministeria(_configurationum);
            FasciculusThesaurorum thesaurorum = new FasciculusThesaurorum(_configurationumDucis);
            _praefectusDucum = new PraefectusDucum(thesaurorum, _ministeria.OstiorumRationis);
        }

        private void Start() {
        }

        private void Update() {
            _ministeria.PulsusPrimum();

            _praefectusDucum.Pulsus();
            _ministeria.Pulsus();
            _praefectusDucum.PulsusPostRationem();
        }

        private void FixedUpdate() {
            _ministeria.PulsusFixusPrimum();

            _ministeria.PulsusFixus();
        }

        private void LateUpdate() {
            _praefectusDucum.PulsusTardus();
            _ministeria.PulsusTardus();
        }
    }
}
