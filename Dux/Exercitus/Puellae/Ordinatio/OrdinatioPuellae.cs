namespace Yulinti.Dux.Exercitus {
    internal readonly struct OrdinatioPuellae {
        private readonly OrdinatioPuellaeActionis? _actionis;
        private readonly OrdinatioPuellaeAnimationis? _animationis;
        private readonly OrdinatioPuellaeVeletudinis? _veletudinis;

        public OrdinatioPuellae(
            OrdinatioPuellaeActionis? actionis = null,
            OrdinatioPuellaeAnimationis? animationis = null,
            OrdinatioPuellaeVeletudinis? veletudinis = null
        ) {
            _actionis = actionis;
            _animationis = animationis;
            _veletudinis = veletudinis;
        }

        public bool EstApplicandumActionis => _actionis.HasValue;
        public bool EstApplicandumAnimationis => _animationis.HasValue;
        public bool EstApplicandumVeletudinis => _veletudinis.HasValue;

        public static OrdinatioPuellae Nihil() {
            return new OrdinatioPuellae();
        }

        public bool ConareLegoActionis(out OrdinatioPuellaeActionis actionis) {
            if (!_actionis.HasValue) {
                actionis = default;
                return false;
            }
            actionis = _actionis.Value;
            return true;
        }

        public bool ConareLegoAnimationis(out OrdinatioPuellaeAnimationis animationis) {
            if (!_animationis.HasValue) {
                animationis = default;
                return false;
            }
            animationis = _animationis.Value;
            return true;
        }

        public bool ConareLegoVeletudinis(out OrdinatioPuellaeVeletudinis veletudinis) {
            if (!_veletudinis.HasValue) {
                veletudinis = default;
                return false;
            }
            veletudinis = _veletudinis.Value;
            return true;
        }
    }
}