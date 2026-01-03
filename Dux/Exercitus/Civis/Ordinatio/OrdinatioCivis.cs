namespace Yulinti.Dux.Exercitus {
    internal readonly struct OrdinatioCivis {
        public readonly int IdCivis { get; }
        private readonly OrdinatioCivisActionis? _actionis;
        private readonly OrdinatioCivisAnimationis? _animationis;
        private readonly OrdinatioCivisVeletudinisValoris? _veletudinisValoris;
        private readonly OrdinatioCivisVeletudinisMortis? _veletudinisMortis;

        public OrdinatioCivis(
            int idCivis,
            OrdinatioCivisActionis? actionis = null,
            OrdinatioCivisAnimationis? animationis = null,
            OrdinatioCivisVeletudinisValoris? veletudinisValoris = null,
            OrdinatioCivisVeletudinisMortis? veletudinisMortis = null
        ) {
            IdCivis = idCivis;
            _actionis = actionis;
            _animationis = animationis;
            _veletudinisValoris = veletudinisValoris;
            _veletudinisMortis = veletudinisMortis;
        }

        public bool EstApplicandumActionis => _actionis.HasValue;
        public bool EstApplicandumAnimationis => _animationis.HasValue;
        public bool EstApplicandumVeletudinisValoris => _veletudinisValoris.HasValue;
        public bool EstApplicandumVeletudinisMortis => _veletudinisMortis.HasValue;

        public static OrdinatioCivis Nihil(int idCivis) {
            return new OrdinatioCivis(idCivis);
        }

        public bool ConareLegoActionis(out OrdinatioCivisActionis actionis) {
            if (!_actionis.HasValue) {
                actionis = default;
                return false;
            }
            actionis = _actionis.Value;
            return true;
        }

        public bool ConareLegoAnimationis(out OrdinatioCivisAnimationis animationis) {
            if (!_animationis.HasValue) {
                animationis = default;
                return false;
            }
            animationis = _animationis.Value;
            return true;
        }

        public bool ConareLegoVeletudinisValoris(out OrdinatioCivisVeletudinisValoris veletudinisValoris) {
            if (!_veletudinisValoris.HasValue) { 
                veletudinisValoris = default;
                return false;
            }
            veletudinisValoris = _veletudinisValoris.Value;
            return true;
        }

        public bool ConareLegoVeletudinisMortis(out OrdinatioCivisVeletudinisMortis veletudinisMortis) {
            if (!_veletudinisMortis.HasValue) {
                veletudinisMortis = default;
                return false;
            }
            veletudinisMortis = _veletudinisMortis.Value;
            return true;
        }
    }
}