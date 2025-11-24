using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.Nucleus;
using UnityEngine;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class Ministeria : IPulsabilis, IPulsabilisPrimum, IPulsabilisFixus, IPulsabilisFixusPrimum, IPulsabilisTardus {
        private readonly FasciculusOstiorumRationis _ostiorumRationis;
        private readonly FonsTemporis _fonsTemporis;
        private readonly ITemporis _temporis;

        // Civisテスト　後で消すこと。 ----
        private readonly MinisteriumCivis _ministeriumCivis;
        // ----------------------------

        public Ministeria(FasciculusConfigurationum configurationum) {
            if (configurationum == null) {
                ModeratorErrorum.Fatal("MinisteriaのConfigurationumがnullです。");
            }
            _fonsTemporis = new FonsTemporis();
            _temporis = new Temporis(_fonsTemporis);
            _ostiorumRationis = new FasciculusOstiorumRationis(configurationum, _temporis);

            // Civisテスト　後で消すこと。 ----
            IConfiguratioCivisOrdinatae config = configurationum.Civis.ConfiguratioCivisSimplicis.Evolvare();
            IFabricaCivis _fabricaCivis = new FabricaCivisOrdinatae(config);
            _ministeriumCivis = MinisteriumCivis.CreareInstantia(_fabricaCivis).Evolvare();

            Debug.Log("MinisteriumCivis生成成功");
            Debug.Log("tCivis: " + _ministeriumCivis.LegoPositionem());
            Debug.Log("osCaputis: " + _ministeriumCivis.DirectioAspectus());

            // ----------------------------
        }

        public FasciculusOstiorumRationis OstiorumRationis => _ostiorumRationis;
        public FasciculusOstiorumPuellae Puellae => _ostiorumRationis.Puellae;
        public FasciculusOstiorumNuclei Nuclei => _ostiorumRationis.Nuclei;
        public FasciculusOstiorumInput Input => _ostiorumRationis.Input;
        public FasciculusOstiorumCamera Camera => _ostiorumRationis.Camera;


        public void PulsusPrimum() {
            // ここでDeltaTime更新。　-> 以降全てITemporis/OstiumTemporisLegibileにアクセスする。
            _fonsTemporis.Pulsus();
        }
        public void Pulsus() {
            _ostiorumRationis.Pulsus();
        }

        public void PulsusFixusPrimum() {
            // ここでFixedDeltaTime更新。　-> 以降全てITemporis/OstiumTemporisLegibileにアクセスする。
            _fonsTemporis.PulsusFixus();
        }

        public void PulsusFixus() {
            _ostiorumRationis.PulsusFixus();
        }

        public void PulsusTardus() {
            _ostiorumRationis.PulsusTardus();
        }
    }
}
        
