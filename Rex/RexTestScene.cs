using UnityEngine;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Dux.Exercitus;

namespace Yulinti.Rex {
    public sealed class RexTestScene : MonoBehaviour {
        [SerializeField] private ResolvorAnchoraeTestScene _resolvorAnchorae;

        [SerializeField] private ConfiguratioCivis _configuratioCivis;
        [SerializeField] private ConfiguratioPuellae _configuratioPuellae;
        [SerializeField] private ConfiguratioExercitusPuellae _configuratioExercitusPuellae;

        private Ministeria _ministeria;
        private DuxExercitus _dux;

        private void Awake() {
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

            _ministeria = new Ministeria(vasculumMinisteriiTestScene);

            _dux = new DuxExercitus(
                _configuratioExercitusPuellae.Statuum,
                _configuratioExercitusPuellae.Statuum.StatusCorporum,
                _configuratioExercitusPuellae.ActionisSecundarius,
                _ministeria.Input.MotusLeg,
                _ministeria.Nuclei.TempusLeg,
                _ministeria.Camera.PrincepsLeg,
                _ministeria.Puellae.AnimatioMut,
                _ministeria.Puellae.LocusMut,
                _ministeria.Puellae.LocusLeg,
                _ministeria.Puellae.RelatioTerraeLeg,
                _ministeria.Puellae.OsMut,
                _ministeria.Puellae.OsLeg,
                _ministeria.Puellae.FiguraPelvisMut,
                _ministeria.Puellae.FiguraGenusMut,
                _ministeria.OstiorumRationis.PuellaeCrinis.OsPuellaeCrinisAdiunctionisMut
            );
        }

        private void Start() {
        }

        private void Update() {
            _ministeria.PulsusPrimum();
            _ministeria.Pulsus();
            _dux.Pulsus();
        }

        private void FixedUpdate() {
            _ministeria.PulsusFixusPrimum();
            _ministeria.PulsusFixus();
        }

        private void LateUpdate() {
            _ministeria.PulsusTardus();
            _dux.PulsusTardus();
        }
    }
}
