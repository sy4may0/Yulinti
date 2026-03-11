using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Turris {
    internal sealed class ResolutorPuellaePersonae {
        private readonly int[] _tabulaGradusAnimae;
        private readonly int[] _tabulaSensusAnimae;

        public ResolutorPuellaePersonae(IConfiguratioTurrisPhantasma config) {
            _tabulaGradusAnimae = CreareTabulam(
                config.GradusPuellaePersonaeMaximus,
                config.OffsetPuellaePersonaeAnimae,
                config.CofficiensPuellaePersonaeAnimae
            );
            _tabulaSensusAnimae = CreareTabulam(
                config.SensusPuellaePersonaeMaximus,
                config.OffsetPuellaePersonaeAnimae,
                config.CofficiensPuellaePersonaeAnimae
            );
        }

        public int ResolvereGradum(int anima) {
            return Resolvere(anima, _tabulaGradusAnimae);
        }

        public int ResolvereSensum(int anima) {
            return Resolvere(anima, _tabulaSensusAnimae);
        }

        private static int[] CreareTabulam(int gradusMaximus, int offset, int cofficiens) {
            int[] tabula = new int[gradusMaximus + 1];
            for (int i = 0; i <= gradusMaximus; i++) {
                tabula[i] = FunctioAnimae(i, offset) * cofficiens;
            }
            return tabula;
        }

        private static int FunctioAnimae(int gradus, int offset) {
            return gradus * gradus + 4 * gradus + offset;
        }

        private static int Resolvere(int anima, int[] tabula) {
            for (int i = tabula.Length - 1; i >= 0; i--) {
                if (anima >= tabula[i]) {
                    return i;
                }
            }
            return 0;
        }
    }
}
