namespace Yulinti.Exercitus.Dux {
    internal static class ConstansPuellae {
        // 毎フレーム発行可能なOrdinatioの最大数
        public const int LongitudoOrdinatioAnimationis = 12;
        public const int LongitudoOrdinatioCrinis = 6;
        public const int LongitudoOrdinatioFiguraeGenus = 24;
        public const int LongitudoOrdinatioFiguraePelvis = 12;
        public const int LongitudoOrdinatioMotus = 6;
        public const int LongitudoOrdinatioNavmesh = 12;
        public const int LongitudoOrdinatioVeletudinis = 32;
        public const int LongitudoOrdinatioVeletudinisNudi = 6;

        public const int GradusMaximus = 10;
        public const int SensusMaximus = 10;

        public static int FunctioAnimae(int gradus, int offset) {
            // 必要経験値の伸びを計算する関数。
            // x^2 + 4x + 4
            return gradus * gradus + 4 * gradus + offset;
        }
    }
}