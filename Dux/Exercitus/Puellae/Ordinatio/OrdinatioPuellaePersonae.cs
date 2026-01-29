namespace Yulinti.Dux.Exercitus {
    internal sealed class OrdinatioPuellaePersonae : OrdinatioPuellae, IOrdinatioPuellaePersonae {
        private int _dtAnimaeLuxuriosus;
        private int _dtAnimaeExhibitus;
        private int _dtAnimaePerversus;
        private int _dtAnimaeQuaeritDolore;
        private int _dtAnimaePapillae;
        private int _dtAnimaeLandicae;
        private int _dtAnimaeVaginae;
        private int _dtAnimaeAni;
        private int _dtAnimaeAusculum;
        private int _dtAnimaeCorporis;

        public OrdinatioPuellaePersonae()
            : base(true, SpeciesOrdinatioPuellae.Personae) {
            _dtAnimaeLuxuriosus = 0;
            _dtAnimaeExhibitus = 0;
            _dtAnimaePerversus = 0;
            _dtAnimaeQuaeritDolore = 0;
            _dtAnimaePapillae = 0;
            _dtAnimaeLandicae = 0;
            _dtAnimaeVaginae = 0;
            _dtAnimaeAni = 0;
            _dtAnimaeAusculum = 0;
            _dtAnimaeCorporis = 0;
        }

        public int DtAnimaeLuxuriosus => _dtAnimaeLuxuriosus;
        public int DtAnimaeExhibitus => _dtAnimaeExhibitus;
        public int DtAnimaePerversus => _dtAnimaePerversus;
        public int DtAnimaeQuaeritDolore => _dtAnimaeQuaeritDolore;
        public int DtAnimaePapillae => _dtAnimaePapillae;
        public int DtAnimaeLandicae => _dtAnimaeLandicae;
        public int DtAnimaeVaginae => _dtAnimaeVaginae;
        public int DtAnimaeAni => _dtAnimaeAni;
        public int DtAnimaeAusculum => _dtAnimaeAusculum;
        public int DtAnimaeCorporis => _dtAnimaeCorporis;

        public override void Purgere() {
            _estApplicandum = false;
            _dtAnimaeLuxuriosus = 0;
            _dtAnimaeExhibitus = 0;
            _dtAnimaePerversus = 0;
            _dtAnimaeQuaeritDolore = 0;
            _dtAnimaePapillae = 0;
            _dtAnimaeLandicae = 0;
            _dtAnimaeVaginae = 0;
            _dtAnimaeAni = 0;
            _dtAnimaeAusculum = 0;
            _dtAnimaeCorporis = 0;
        }

        public void Pono(
            int dtAnimaeLuxuriosus,
            int dtAnimaeExhibitus,
            int dtAnimaePerversus,
            int dtAnimaeQuaeritDolore,
            int dtAnimaePapillae,
            int dtAnimaeLandicae,
            int dtAnimaeVaginae,
            int dtAnimaeAni,
            int dtAnimaeAusculum,
            int dtAnimaeCorporis
        ) {
            _dtAnimaeLuxuriosus = dtAnimaeLuxuriosus;
            _dtAnimaeExhibitus = dtAnimaeExhibitus;
            _dtAnimaePerversus = dtAnimaePerversus;
            _dtAnimaeQuaeritDolore = dtAnimaeQuaeritDolore;
            _dtAnimaePapillae = dtAnimaePapillae;
            _dtAnimaeLandicae = dtAnimaeLandicae;
            _dtAnimaeVaginae = dtAnimaeVaginae;
            _dtAnimaeAni = dtAnimaeAni;
            _dtAnimaeAusculum = dtAnimaeAusculum;
            _dtAnimaeCorporis = dtAnimaeCorporis;

            _estApplicandum = true;
        }
    }
}
