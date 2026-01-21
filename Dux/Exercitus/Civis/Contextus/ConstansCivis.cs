namespace Yulinti.Dux.Exercitus {
    internal static class ConstansCivis {
        // 毎フレーム発行可能なOrdinatioの最大数
        public const int LongitudoOrdinatioAnimationis = 12;
        public const int LongitudoOrdinatioMotus = 6;
        // CivisのNavmesh要求は重複する可能性がある。
        public const int LongitudoOrdinatioNavmesh = 12;
        public const int LongitudoOrdinatioVeletudinisValoris = 32;
        public const int LongitudoOrdinatioMortis = 6;
        public const int LongitudoOrdinatioVeletudinisCondicionis = 12;

        // Custodiaeの各種定数
        public const int LongitudoSigmoidStudiumAmittere = 256;
        public const int LongitudoSigmoidDistantiaeVisus = 256;
        public const int LongitudoSigmoidAnguliVisus = 256;

        // Nudus視認後のsuspecta -> visa変換比率
        public const float RatioSuspectaVisa = 0.75f;

        public const float HysteriaDetectionis = 0.02f;
        public const float HysteriaAudivi = 0.02f;
        public const float HysteriaSuspecta = 0.02f;
    }
}
