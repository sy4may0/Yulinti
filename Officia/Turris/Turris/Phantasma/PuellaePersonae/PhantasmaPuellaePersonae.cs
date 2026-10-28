using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.Officia.Turris {
    internal sealed class PhantasmaPuellaePersonae : IPhantasmaPuellaePersonaeLegibile, IPhantasmaSalsamenti {
        private readonly ResolutorPuellaePersonae _resolutorPuellaePersonae;

        private int _gradusLuxuriosus;
        private int _animaLuxuriosus;
        private int _gradusExhibitus;
        private int _animaExhibitus;
        private int _gradusPerversus;
        private int _animaPerversus;
        private int _gradusQuaeritDolore;
        private int _animaQuaeritDolore;

        private int _sensusPapillae;
        private int _animaPapillae;
        private int _sensusLandicae;
        private int _animaLandicae;
        private int _sensusVaginae;
        private int _animaVaginae;
        private int _sensusAni;
        private int _animaAni;
        private int _sensusAusculum;
        private int _animaAusculum;
        private int _sensusCorporis;
        private int _animaCorporis;

        public PhantasmaPuellaePersonae(ResolutorPuellaePersonae resolutorPuellaePersonae) {
            _resolutorPuellaePersonae = resolutorPuellaePersonae;
            Purgare();
        }

        public int GradusLuxuriosus => _gradusLuxuriosus;
        public int AnimaLuxuriosus => _animaLuxuriosus;
        public int GradusExhibitus => _gradusExhibitus;
        public int AnimaExhibitus => _animaExhibitus;
        public int GradusPerversus => _gradusPerversus;
        public int AnimaPerversus => _animaPerversus;
        public int GradusQuaeritDolore => _gradusQuaeritDolore;
        public int AnimaQuaeritDolore => _animaQuaeritDolore;
        public int SensusPapillae => _sensusPapillae;
        public int AnimaPapillae => _animaPapillae;
        public int SensusLandicae => _sensusLandicae;
        public int AnimaLandicae => _animaLandicae;
        public int SensusVaginae => _sensusVaginae;
        public int AnimaVaginae => _animaVaginae;
        public int SensusAni => _sensusAni;
        public int AnimaAni => _animaAni;
        public int SensusAusculum => _sensusAusculum;
        public int AnimaAusculum => _animaAusculum;
        public int SensusCorporis => _sensusCorporis;
        public int AnimaCorporis => _animaCorporis;

        public void Renovare(SalsamentumDto dto) {
            _gradusLuxuriosus = dto.PuellaePersonae.GradusLuxuriosus;
            _animaLuxuriosus = dto.PuellaePersonae.AnimaLuxuriosus;
            _gradusExhibitus = dto.PuellaePersonae.GradusExhibitus;
            _animaExhibitus = dto.PuellaePersonae.AnimaExhibitus;
            _gradusPerversus = dto.PuellaePersonae.GradusPerversus;
            _animaPerversus = dto.PuellaePersonae.AnimaPerversus;
            _gradusQuaeritDolore = dto.PuellaePersonae.GradusQuaeritDolore;
            _animaQuaeritDolore = dto.PuellaePersonae.AnimaQuaeritDolore;

            _sensusPapillae = dto.PuellaePersonae.SensusPapillae;
            _animaPapillae = dto.PuellaePersonae.AnimaPapillae;
            _sensusLandicae = dto.PuellaePersonae.SensusLandicae;
            _animaLandicae = dto.PuellaePersonae.AnimaLandicae;
            _sensusVaginae = dto.PuellaePersonae.SensusVaginae;
            _animaVaginae = dto.PuellaePersonae.AnimaVaginae;
            _sensusAni = dto.PuellaePersonae.SensusAni;
            _animaAni = dto.PuellaePersonae.AnimaAni;
            _sensusAusculum = dto.PuellaePersonae.SensusAusculum;
            _animaAusculum = dto.PuellaePersonae.AnimaAusculum;
            _sensusCorporis = dto.PuellaePersonae.SensusCorporis;
            _animaCorporis = dto.PuellaePersonae.AnimaCorporis;
        }

        public void Imple(SalsamentumDto dto) {
            dto.PuellaePersonae.GradusLuxuriosus = _gradusLuxuriosus;
            dto.PuellaePersonae.AnimaLuxuriosus = _animaLuxuriosus;
            dto.PuellaePersonae.GradusExhibitus = _gradusExhibitus;
            dto.PuellaePersonae.AnimaExhibitus = _animaExhibitus;
            dto.PuellaePersonae.GradusPerversus = _gradusPerversus;
            dto.PuellaePersonae.AnimaPerversus = _animaPerversus;
            dto.PuellaePersonae.GradusQuaeritDolore = _gradusQuaeritDolore;
            dto.PuellaePersonae.AnimaQuaeritDolore = _animaQuaeritDolore;
            dto.PuellaePersonae.SensusPapillae = _sensusPapillae;
            dto.PuellaePersonae.AnimaPapillae = _animaPapillae;
            dto.PuellaePersonae.SensusLandicae = _sensusLandicae;
            dto.PuellaePersonae.AnimaLandicae = _animaLandicae;
            dto.PuellaePersonae.SensusVaginae = _sensusVaginae;
            dto.PuellaePersonae.AnimaVaginae = _animaVaginae;
            dto.PuellaePersonae.SensusAni = _sensusAni;
            dto.PuellaePersonae.AnimaAni = _animaAni;
            dto.PuellaePersonae.SensusAusculum = _sensusAusculum;
            dto.PuellaePersonae.AnimaAusculum = _animaAusculum;
            dto.PuellaePersonae.SensusCorporis = _sensusCorporis;
            dto.PuellaePersonae.AnimaCorporis = _animaCorporis;
        }

        internal void Imple(SalsamentumNotitiaeDto dto) {
            dto.PuellaePersonaeNotitiae.GradusLuxuriosus = _gradusLuxuriosus;
            dto.PuellaePersonaeNotitiae.GradusExhibitus = _gradusExhibitus;
            dto.PuellaePersonaeNotitiae.GradusPerversus = _gradusPerversus;
            dto.PuellaePersonaeNotitiae.GradusQuaeritDolore = _gradusQuaeritDolore;
        }

        public void Purgare() {
            _gradusLuxuriosus = 1;
            _animaLuxuriosus = 0;
            _gradusExhibitus = 1;
            _animaExhibitus = 0;
            _gradusPerversus = 1;
            _animaPerversus = 0;
            _gradusQuaeritDolore = 1;
            _animaQuaeritDolore = 0;

            _sensusPapillae = 1;
            _animaPapillae = 0;
            _sensusLandicae = 1;
            _animaLandicae = 0;
            _sensusVaginae = 1;
            _animaVaginae = 0;
            _sensusAni = 1;
            _animaAni = 0;
            _sensusAusculum = 1;
            _animaAusculum = 0;
            _sensusCorporis = 1;
            _animaCorporis = 0;
        }

        internal void Normare() {
            _gradusLuxuriosus = _resolutorPuellaePersonae.ResolvereGradum(_animaLuxuriosus);
            _gradusExhibitus = _resolutorPuellaePersonae.ResolvereGradum(_animaExhibitus);
            _gradusPerversus = _resolutorPuellaePersonae.ResolvereGradum(_animaPerversus);
            _gradusQuaeritDolore = _resolutorPuellaePersonae.ResolvereGradum(_animaQuaeritDolore);

            _sensusPapillae = _resolutorPuellaePersonae.ResolvereSensum(_animaPapillae);
            _sensusLandicae = _resolutorPuellaePersonae.ResolvereSensum(_animaLandicae);
            _sensusVaginae = _resolutorPuellaePersonae.ResolvereSensum(_animaVaginae);
            _sensusAni = _resolutorPuellaePersonae.ResolvereSensum(_animaAni);
            _sensusAusculum = _resolutorPuellaePersonae.ResolvereSensum(_animaAusculum);
            _sensusCorporis = _resolutorPuellaePersonae.ResolvereSensum(_animaCorporis);
        }

        internal void RenovareAnimumGradusLuxuriosus(int animaLuxuriosus) {
            _animaLuxuriosus = animaLuxuriosus;
        }

        internal void RenovareAnimumGradusExhibitus(int animaExhibitus) {
            _animaExhibitus = animaExhibitus;
        }

        internal void RenovareAnimumGradusPerversus(int animaPerversus) {
            _animaPerversus = animaPerversus;
        }

        internal void RenovareAnimumGradusQuaeritDolore(int animaQuaeritDolore) {
            _animaQuaeritDolore = animaQuaeritDolore;
        }

        internal void RenovareAnimumSensusPapillae(int animaPapillae) {
            _animaPapillae = animaPapillae;
        }

        internal void RenovareAnimumSensusLandicae(int animaLandicae) {
            _animaLandicae = animaLandicae;
        }

        internal void RenovareAnimumSensusVaginae(int animaVaginae) {
            _animaVaginae = animaVaginae;
        }

        internal void RenovareAnimumSensusAni(int animaAni) {
            _animaAni = animaAni;
        }

        internal void RenovareAnimumSensusAusculum(int animaAusculum) {
            _animaAusculum = animaAusculum;
        }

        internal void RenovareAnimumSensusCorporis(int animaCorporis) {
            _animaCorporis = animaCorporis;
        }
    }
}
