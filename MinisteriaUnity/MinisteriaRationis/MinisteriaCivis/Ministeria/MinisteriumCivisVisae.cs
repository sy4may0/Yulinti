using UnityEngine;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumCivisVisae {
        private readonly TabulaCivis _tabulaCivis;
        private LayerMask _stratumObstaculum;

        public MinisteriumCivisVisae(TabulaCivis tabulaCivis, IConfiguratioCivisVisae configVisae) {
            _tabulaCivis = tabulaCivis;
            _stratumObstaculum = configVisae.StratumObstaculum;
        }

        private bool ConareLegoActivum(int idCivis, out IAnchoraCivis anchora) {
            IAnchoraCivis anchoraP = null;
            if (_tabulaCivis.ConareLego(idCivis, out anchoraP)) {
                if (anchoraP.EstActivum) {
                    anchora = anchoraP;
                    return true;
                }
            }
            anchora = null;
            return false;
        }

        public bool ConareLegoPositioCapitis(int idCivis, out Vector3 positio) {
            if (!ConareLegoActivum(idCivis, out IAnchoraCivis anchora)) {
                positio = default;
                return false;
            }
            positio = anchora.Capitis.position;
            return true;
        }

        public bool ConareLegoDirectioCapitis(int idCivis, out Vector3 directio) {
            if (!ConareLegoActivum(idCivis, out IAnchoraCivis anchora)) {
                directio = default;
                return false;
            }
            directio = anchora.Capitis.forward;
            return true;
        }

        // RayCastヒットチェック
        public bool EstVisa(int idCivis, Vector3 positio) {
            if (!ConareLegoActivum(idCivis, out IAnchoraCivis anchora)) return false;
            Vector3 positioCapitis = anchora.Capitis.position;
            Vector3 dt = positio - positioCapitis;
            float distantia = dt.magnitude;
            if (distantia <= Numerus.Epsilon) return true;
            Vector3 directio = dt / distantia;

            // positioまでにhit無しならtrueを返す
            return !Physics.Raycast(
                positioCapitis,
                directio,
                distantia,
                _stratumObstaculum,
                QueryTriggerInteraction.Ignore
            );
        }
    }
}