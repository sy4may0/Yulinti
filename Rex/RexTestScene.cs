using UnityEngine;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.MinisteriaUnity.ConfiguratioDucis;
using Yulinti.Dux.Thesaurus;
using Yulinti.Dux.Miles;

namespace Yulinti.Rex {
    public sealed class RexTestScene : MonoBehaviour {
        [SerializeField] private FasciculusConfigurationumDucis _configurationumDucis;
        [SerializeField] private ResolvorAnchoraeTestScene _resolvorAnchorae;

        [SerializeField] private ConfiguratioCivis _configuratioCivis;
        [SerializeField] private ConfiguratioPuellae _configuratioPuellae;

        private Ministeria _ministeria;
        private PraefectusDucum _praefectusDucum;

        private void Awake() {
            // 繧｢繝ｳ繧ｫ繝ｼ繧定ｧ｣豎ｺ
            _resolvorAnchorae.Resolvo();
            _resolvorAnchorae.Validare();

            VasculumMinisteriiTestScene vasculumMinisteriiTestScene = new VasculumMinisteriiTestScene(
                _resolvorAnchorae.AnchoraPuellae,
                _resolvorAnchorae.AnchoraCamera,
                _resolvorAnchorae.AnchoraInput,
                _resolvorAnchorae.AnchoraPuellaeCrinis,
                _resolvorAnchorae.AnchoraCivis,
                _resolvorAnchorae.AnchoraPunctumViae,
                _configuratioCivis,
                _configuratioPuellae
            );

            // Ministeria繧貞・譛溷喧
            _ministeria = new Ministeria(vasculumMinisteriiTestScene);

            // Runtime繧貞・譛溷喧縲・
            FasciculusThesaurorum thesaurorum = new FasciculusThesaurorum(_configurationumDucis);

            // Dux繧貞・譛溷喧
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
