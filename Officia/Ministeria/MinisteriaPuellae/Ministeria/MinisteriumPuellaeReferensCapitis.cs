using UnityEngine;
using Yulinti.Officia.Contractus;
using Yulinti.ImperiumDelegatum.Contractus;
using Yulinti.Nucleus.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class MinisteriumPuellaeReferensCapitis : IMinisteriumIncipabilis, IMinisteriumPulsabilisTardus {
        private readonly IAnchoraPuellae _anchoraPuellae;
        private readonly IConfiguratioPuellaeReferensCapitis _configReferensCapitis;
        private readonly IOstiumTemporisLegibile _ostiumTemporisLegibile;

        private Vector3 _velocitas;
        private bool _sequens;

        public MinisteriumPuellaeReferensCapitis(
            IAnchoraPuellae anchoraPuellae,
            IConfiguratioPuellaeReferensCapitis configReferensCapitis,
            IOstiumTemporisLegibile ostiumTemporisLegibile
        ) {
            _anchoraPuellae = anchoraPuellae;
            _configReferensCapitis = configReferensCapitis;
            _ostiumTemporisLegibile = ostiumTemporisLegibile;
        }

        public void Incipere() {
            // 初期位置を頭に合わせて親をrootにする。
            _anchoraPuellae.LocusReferensCapitis.position = _anchoraPuellae.OsHead.position;
            _anchoraPuellae.LocusReferensCapitis.parent = _anchoraPuellae.OsRadix;

            _velocitas = Vector3.zero;
            _sequens = false;
        }

        public void PulsusTardus() {
            Transform locus = _anchoraPuellae.LocusReferensCapitis;
            Vector3 positioCapitis = _anchoraPuellae.OsRadix.InverseTransformPoint(_anchoraPuellae.OsHead.position);
            float distantiaSq = (positioCapitis - locus.localPosition).sqrMagnitude;

            float zonaMortua = _configReferensCapitis.ZonaMortua;
            float zonaMortuaExitus = _configReferensCapitis.ZonaMortuaExitus;

            // ZonaMortuaを超えたら追従開始、ZonaMortuaExitusを下回ったら追従終了。
            if (!_sequens && distantiaSq > zonaMortua * zonaMortua) {
                _sequens = true;
            } else if (_sequens && distantiaSq < zonaMortuaExitus * zonaMortuaExitus) {
                _sequens = false;
                _velocitas = Vector3.zero;
            }

            if (!_sequens) {
                return;
            }

            locus.localPosition = Vector3.SmoothDamp(
                locus.localPosition,
                positioCapitis,
                ref _velocitas,
                _configReferensCapitis.TempusLevigatum,
                Mathf.Infinity,
                _ostiumTemporisLegibile.Intervallum
            );
        }
    }
}
