namespace Yulinti.Dux.Exercitus {
    internal sealed class TabulaCivisVitae {
        // Civisの寿命をパーセントで管理する。
        private readonly int[] _vitae;

        public TabulaCivisVitae(
            int[] idCivis
        ) {
            foreach (int id in idCivis) {
                _vitae[id] = 100;
            }
        }

        public void ConsumereVitam(int idCivis, int vita) {
            _vitae[idCivis] -= vita;
        }

        public void AddereVitam(int idCivis, int vita) {
            _vitae[idCivis] += vita;
        }

        public bool EstExhaurita(int idCivis) {
            return _vitae[idCivis] <= 0;
        }
    }
}