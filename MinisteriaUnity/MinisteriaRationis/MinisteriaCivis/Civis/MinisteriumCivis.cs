using Yulinti.Nucleus;
using UnityEngine;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using System;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class MinisteriumCivis : IDisposable {
        private readonly GameObject _civis;
        private readonly Transform _tCivis;
        private readonly Transform _osCaputis;
        private readonly IFabricaCivis _fabrica;

        public MinisteriumCivis(NihilAut<ConfiguratioCivisSimplicis> config, IFabricaCivis fabrica) {
            ConfiguratioCivisSimplicis configuratio = config.EvolvareNuncium(
                "MinisteriumCivisのConfiguratioCivisSimplicisがnullです。"
            );
            _fabrica = fabrica;
            _civis = _fabrica.ManifestatioCivis().EvolvareNuncium("MinisteriumCivisのCivisがnullです。");
            _tCivis = _civis.transform;
            _osCaputis = _tCivis.Find(configuratio.IterAdCapitis);
        }


        public Vector3 LegoPositionem() => _tCivis.position;
        public Quaternion LegoRotationem() => _tCivis.rotation;
        public Vector3 LegoScalam() => _tCivis.localScale;

        public void PonoPositionem(Vector3 pos) => _tCivis.position = pos;
        public void PonoRotationem(Quaternion rot) => _tCivis.rotation = rot;
        public void PonoScalam(Vector3 scala) => _tCivis.localScale = scala;

        public Vector3 DirectioAspectus() => _osCaputis.forward;

        public void Dispose() {
            _fabrica.DeletioCivis(new NihilAut<GameObject>(_civis));
        }
    }
}