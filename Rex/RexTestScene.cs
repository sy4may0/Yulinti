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
        [SerializeField] private ResolvorAnchoraeTestScene _resolvorAnchorae;

        private Ministeria _ministeria;
        private PraefectusDucum _praefectusDucum;

        private void Awake() {
            // アンカーを解決
            _resolvorAnchorae.Resolvo();
            _resolvorAnchorae.Validare();

            VasculumMinisteriiTestScene vasculumMinisteriiTestScene = new VasculumMinisteriiTestScene(
                _configurationum,
                _resolvorAnchorae.AnchoraPuellae,
                _resolvorAnchorae.AnchoraCamera,
                _resolvorAnchorae.AnchoraInput,
                _resolvorAnchorae.AnchoraPuellaeCrinis,
                _resolvorAnchorae.AnchoraCivis,
                _resolvorAnchorae.AnchoraPunctumViae
            );

            // Ministeriaを初期化
            _ministeria = new Ministeria(vasculumMinisteriiTestScene);

            // Runtimeを初期化。
            FasciculusThesaurorum thesaurorum = new FasciculusThesaurorum(_configurationumDucis);

            // Duxを初期化
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
