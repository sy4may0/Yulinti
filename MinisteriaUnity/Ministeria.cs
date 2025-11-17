using Yulinti.MinisteriaUnity.Interna;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.MinisteriaRationis;
using Yulinti.Nucleus.Interfacies;

namespace Yulinti.MinisteriaUnity {
    public sealed class Ministeria : IPulsabilis, IPulsabilisFixus, IPulsabilisTardus {
        private readonly FasciculusOstiorumRationis _ostiorumRationis;
        private readonly ITemporis _temporis;

        public Ministeria(FasciculusConfigurationum configurationum, FonsTemporis fonsTempus) {
            if (configurationum == null) {
                ModeratorErrorum.Fatal("MinisteriaのConfigurationumがnullです。");
            }
            if (fonsTempus == null) {
                ModeratorErrorum.Fatal("MinisteriaのFonsTempusがnullです。");
            }
            _temporis = new Temporis(fonsTempus);
            _ostiorumRationis = new FasciculusOstiorumRationis(configurationum, _temporis);
        }

        public FasciculusOstiorumPuellae Puellae => _ostiorumRationis.Puellae;
        public FasciculusOstiorumNuclei Nuclei => _ostiorumRationis.Nuclei;
        public FasciculusOstiorumInput Input => _ostiorumRationis.Input;
        public FasciculusOstiorumCamera Camera => _ostiorumRationis.Camera;

        public void Pulsus() {
            _ostiorumRationis.Pulsus();
        }

        public void PulsusFixus() {
            _ostiorumRationis.PulsusFixus();
        }

        public void PulsusTardus() {
            _ostiorumRationis.PulsusTardus();
        }
    }
}
        