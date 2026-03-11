using Yulinti.ImperiumDelegatum.Contractus;

namespace Yulinti.ImperiumDelegatum.Exercitus {
    internal sealed class MilesPuellaeCrinis {
        private readonly ContextusPuellaeOstiorumLegibile _contextusOstiorum;

        // VContainer注入
        public MilesPuellaeCrinis(
            ContextusPuellaeOstiorumLegibile contextusOstiorum
        ) {
            _contextusOstiorum = contextusOstiorum;
        }

        public void Initare() {
            // Default Hair
            _contextusOstiorum.Carrus.PostulareCrinis(IDPuellaeCrinis.Resiliens);
        }

        public void MutareComam(IDPuellaeCrinis idCrinis) {
            _contextusOstiorum.Carrus.PostulareCrinis(idCrinis);
        }
    }
}