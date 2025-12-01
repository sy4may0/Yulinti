using Yulinti.Nucleus;
using Yulinti.Dux.Thesaurus;
using Yulinti.Dux.Miles;

namespace Yulinti.Dux.Miles {
    public sealed class DuxPuellae : IPulsabilis, IPulsabilisFixus, IPulsabilisTardus, IPulsabilisPostRationem {
        private readonly MachinaStatuumPuellae _machinaStatuumPuellae;
        private readonly InTerrae _inTerrae;
        private readonly Figura _figura;
        private readonly Crinis _crinis;

        internal DuxPuellae(
            FasciculusThesaurorumPuellae thesaurorumPuellae,
            FasciculusOstiorumPuellae ostia
        ) {
            _machinaStatuumPuellae = new MachinaStatuumPuellae(thesaurorumPuellae.Status, ostia);
            _inTerrae = new InTerrae(
                ostia.PuellaeRelationisTerraeLeg, 
                ostia.PuellaeOssisMut, ostia.PuellaeOssisLeg, 
                thesaurorumPuellae.InTerrae
            );
            _figura = new Figura(
                ostia.PuellaeOssisLeg,
                ostia.PuellaeFiguraePelvisMut,
                ostia.PuellaeFiguraeGenusMut
            );
            _crinis = new Crinis(ostia.PuellaeCrinisAdiunctionisMut);
        }

        public void Pulsus() {
            _machinaStatuumPuellae.Opero();
        }
        public void PulsusPostRationem() {
        }

        public void PulsusFixus() {
        }

        public void PulsusTardus() {
            _inTerrae.ElevoPelvis();
            _figura.ApplicareFiguram();
        }
    }
}
