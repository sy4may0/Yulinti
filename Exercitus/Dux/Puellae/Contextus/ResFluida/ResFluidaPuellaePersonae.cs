using Yulinti.Exercitus.Contractus;
namespace Yulinti.Exercitus.Dux {
    // このクラスは特殊: Exercitus内に限りWrite-Onlyになる。
    // ILesFluidaPuellaePersonaeLegibileはランタイムで使用してはならない。値は参照できない。
    // シーン内のキャッシュ値として機能し、リザルト画面でSalsamentumに反映する。
    // 各種値取得はSalsamentumから取得すること。
    internal interface IResolutorPuellaeAnimae {
        int ResolvereGradusLuxuriosus(int animaLuxuriosus);
        int ResolvereGradusExhibitus(int animaExhibitus);
        int ResolvereGradusPerversus(int animaPerversus);
        int ResolvereGradusQuaeritDolore(int animaQuaeritDolore);
        int ResolvereSensusPapillae(int animaPapillae);
        int ResolvereSensusLandicae(int animaLandicae);
        int ResolvereSensusVaginae(int animaVaginae);
        int ResolvereSensusAni(int animaAni);
        int ResolvereSensusAusculum(int animaAusculum);
        int ResolvereSensusCorporis(int animaCorporis);
    }

    internal sealed class ResFluidaPuellaePersonae : IResFluidaPuellaePersonaeLegibile {
        // レベルとかのステータス

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

        public ResFluidaPuellaePersonae() {
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

        // Animaのみ更新可能。Gradus/SensusはAnimaの値によって自動更新。
        public void RenovareAnimaGradus(
            int animaLuxuriosus,
            int animaExhibitus,
            int animaPerversus,
            int animaQuaeritDolore
        ) {
            _animaLuxuriosus = animaLuxuriosus;
            _animaExhibitus = animaExhibitus;
            _animaPerversus = animaPerversus;
            _animaQuaeritDolore = animaQuaeritDolore;
        }

        public void RenovareAnimaSensus(
            int animaPapillae,
            int animaLandicae,
            int animaVaginae,
            int animaAni,
            int animaAusculum,
            int animaCorporis
        ) {
            _animaPapillae = animaPapillae;
            _animaLandicae = animaLandicae;
            _animaVaginae = animaVaginae;
            _animaAni = animaAni;
            _animaAusculum = animaAusculum;
            _animaCorporis = animaCorporis;
        }

        public void ResolvereGradus(IResolutorPuellaeAnimae resolutorPuellaeAnimae) {
            _gradusLuxuriosus = resolutorPuellaeAnimae.ResolvereGradusLuxuriosus(_animaLuxuriosus);
            _gradusExhibitus = resolutorPuellaeAnimae.ResolvereGradusExhibitus(_animaExhibitus);
            _gradusPerversus = resolutorPuellaeAnimae.ResolvereGradusPerversus(_animaPerversus);
            _gradusQuaeritDolore = resolutorPuellaeAnimae.ResolvereGradusQuaeritDolore(_animaQuaeritDolore);
        }

        public void ResolvereSensus(IResolutorPuellaeAnimae resolutorPuellaeAnimae) {
            _sensusPapillae = resolutorPuellaeAnimae.ResolvereSensusPapillae(_animaPapillae);
            _sensusLandicae = resolutorPuellaeAnimae.ResolvereSensusLandicae(_animaLandicae);
            _sensusVaginae = resolutorPuellaeAnimae.ResolvereSensusVaginae(_animaVaginae);
            _sensusAni = resolutorPuellaeAnimae.ResolvereSensusAni(_animaAni);
            _sensusAusculum = resolutorPuellaeAnimae.ResolvereSensusAusculum(_animaAusculum);
            _sensusCorporis = resolutorPuellaeAnimae.ResolvereSensusCorporis(_animaCorporis);
        }

        public void Purgare() {
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
        }
    }
}