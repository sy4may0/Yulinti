namespace Yulinti.Nucleus.Contractus {
    public static class PuellaVeletudinis {
        public static readonly float VigorMaximaBasis = 100f;
        public static readonly float PatientiaMaximaBasis = 100f;
        public static readonly float AetherMaximaBasis = 100f;
        public static readonly float ClaritasMaximaBasis = 100f;
        public static readonly float AnomaliaMaximaBasis = 100f;
        public static readonly float IntentioMaximaBasis = 100f;
        public static readonly float DedecusMaximaBasis = 100f;
        public static readonly float SonusQuietesMaximaBasis = 100f;
        public static readonly float SonusMotusMaximaBasis = 100f;
        // Dedecusを無制限と扱う条件。UI表示とかでこれ以上なら∞。
        public static readonly float RimenDedecorisInfinitionis = 1000000f;
        // Dedecusを無制限とする際の値。変に減算されて999999表示とかにならないように2倍にしておく。
        public static readonly float DedecusInfinitionis = 1000000f * 2;
    }
}