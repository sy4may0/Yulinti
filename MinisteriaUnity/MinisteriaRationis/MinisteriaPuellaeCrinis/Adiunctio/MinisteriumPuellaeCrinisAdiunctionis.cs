using UnityEngine;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.Nucleus;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    public sealed class MinisteriumPuellaeCrinisAdiunctionis {
        private readonly FasciculusConfigurationumPuellaeCrinis _configurationum;
        private readonly TabulaPuellaeCrinis _tabulaCrinis;
        private readonly Transform _osCapitis;

        private CrinisPuellae _crinisActualis;

        public MinisteriumPuellaeCrinisAdiunctionis(FasciculusConfigurationumPuellaeCrinis configurationum) {
            if (configurationum == null) {
                Errorum.Fatal(IDErrorum.MINISTERIUMPUELLAECRINISADIUNCTIONIS_CONFIG_NULL);
            }
            _configurationum = configurationum;
            _tabulaCrinis = new TabulaPuellaeCrinis(_configurationum);
            _crinisActualis = null;
            _osCapitis = _configurationum.OsCapitis;
        }

        public void Manifestatio(IDPuellaeCrinis idCrinis) {
            if (_crinisActualis != null) {
                _crinisActualis.Deletio();
            }
            _crinisActualis = _tabulaCrinis.Lego(idCrinis);
            _crinisActualis.Manifestatio(_osCapitis);
        }

        public void Deletio() {
            if (_crinisActualis != null) {
                _crinisActualis.Deletio();
            }
            _crinisActualis = null;
        }
    }
}
