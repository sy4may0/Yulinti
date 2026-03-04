using Yulinti.Exercitus.Contractus;

namespace Yulinti.Unity.Turris {
    // 更新データを保持するクラス。
    internal sealed class PhantasmaPuellaePersonae : IPhantasmaPuellaePersonae {
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

        private bool _estNormalis;

        public PhantasmaPuellaePersonae(ResolutorPuellaePersonae resolutorPuellaePersonae) {
            _resolutorPuellaePersonae = resolutorPuellaePersonae;
            _gradusLuxuriosus = 0;
            _animaLuxuriosus = 0;
            _gradusExhibitus = 0;
            _animaExhibitus = 0;
            _gradusPerversus = 0;
            _animaPerversus = 0;
            _gradusQuaeritDolore = 0;
            _animaQuaeritDolore = 0;

            _sensusPapillae = 0;
            _animaPapillae = 0;
            _sensusLandicae = 0;
            _animaLandicae = 0;
            _sensusVaginae = 0;
            _animaVaginae = 0;
            _sensusAni = 0;
            _animaAni = 0;
            _sensusAusculum = 0;
            _animaAusculum = 0;
            _sensusCorporis = 0;
            _animaCorporis = 0;

            _estNormalis = false;
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

        public void Initare(IOstiumSalsamentiPuellaePersonae ostiumSalsamentiPuellae) {
            _gradusLuxuriosus = ostiumSalsamentiPuellae.GradusLuxuriosus;
            _animaLuxuriosus = ostiumSalsamentiPuellae.AnimaLuxuriosus;
            _gradusExhibitus = ostiumSalsamentiPuellae.GradusExhibitus;
            _animaExhibitus = ostiumSalsamentiPuellae.AnimaExhibitus;
            _gradusPerversus = ostiumSalsamentiPuellae.GradusPerversus;
            _animaPerversus = ostiumSalsamentiPuellae.AnimaPerversus;
            _gradusQuaeritDolore = ostiumSalsamentiPuellae.GradusQuaeritDolore;
            _animaQuaeritDolore = ostiumSalsamentiPuellae.AnimaQuaeritDolore;

            _sensusPapillae = ostiumSalsamentiPuellae.SensusPapillae;
            _animaPapillae = ostiumSalsamentiPuellae.AnimaPapillae;
            _sensusLandicae = ostiumSalsamentiPuellae.SensusLandicae;
            _animaLandicae = ostiumSalsamentiPuellae.AnimaLandicae;
            _sensusVaginae = ostiumSalsamentiPuellae.SensusVaginae;
            _animaVaginae = ostiumSalsamentiPuellae.AnimaVaginae;   
            _sensusAni = ostiumSalsamentiPuellae.SensusAni;
            _animaAni = ostiumSalsamentiPuellae.AnimaAni;
            _sensusAusculum = ostiumSalsamentiPuellae.SensusAusculum;
            _animaAusculum = ostiumSalsamentiPuellae.AnimaAusculum;
            _sensusCorporis = ostiumSalsamentiPuellae.SensusCorporis;
            _animaCorporis = ostiumSalsamentiPuellae.AnimaCorporis;

            Normare();
        }

        public void Normare() {
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

            _estNormalis = true;
        }

        public bool EstNormalis() => _estNormalis;

        public void RenovareAnimumGradusLuxuriosus(int animaLuxuriosus) {
            _animaLuxuriosus = animaLuxuriosus;
            _estNormalis = false;
        }

        public void RenovareAnimumGradusExhibitus(int animaExhibitus) {
            _animaExhibitus = animaExhibitus;
            _estNormalis = false;
        }

        public void RenovareAnimumGradusPerversus(int animaPerversus) {
            _animaPerversus = animaPerversus;
            _estNormalis = false;
        }

        public void RenovareAnimumGradusQuaeritDolore(int animaQuaeritDolore) {
            _animaQuaeritDolore = animaQuaeritDolore;
            _estNormalis = false;
        }

        public void RenovareAnimumSensusPapillae(int animaPapillae) {
            _animaPapillae = animaPapillae;
            _estNormalis = false;
        }

        public void RenovareAnimumSensusLandicae(int animaLandicae) {
            _animaLandicae = animaLandicae;
            _estNormalis = false;
        }

        public void RenovareAnimumSensusVaginae(int animaVaginae) {
            _animaVaginae = animaVaginae;
            _estNormalis = false;
        }

        public void RenovareAnimumSensusAni(int animaAni) {
            _animaAni = animaAni;
            _estNormalis = false;
        }

        public void RenovareAnimumSensusAusculum(int animaAusculum) {
            _animaAusculum = animaAusculum;
            _estNormalis = false;
        }

        public void RenovareAnimumSensusCorporis(int animaCorporis) {
            _animaCorporis = animaCorporis;
            _estNormalis = false;
        }

    }
}
