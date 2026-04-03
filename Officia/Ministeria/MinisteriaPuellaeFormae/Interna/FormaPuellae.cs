using UnityEngine;
using Yulinti.Nucleus;
using Yulinti.Nucleus.Instrumentarium;
using Yulinti.Nucleus.Contractus;
using Yulinti.Officia.Contractus;
using Yulinti.ImperiumDelegatum.Contractus;
using System.Collections.Generic;

namespace Yulinti.Officia.Ministeria {
    internal sealed class FormaPuellaeFigurae {
        private readonly SkinnedMeshRenderer _figurae;
        private readonly int _index;

        public FormaPuellaeFigurae(SkinnedMeshRenderer figurae, string nomenFigurae) {
            _figurae = figurae;
            var sharedMesh = _figurae.sharedMesh;
            if (sharedMesh == null) {
                Carnifex.Intermissio(LogTextus.FormaPuellaeFigurae_FORMATPUELLAEFIGURAE_SHARED_MESH_NOT_FOUND);
            }

            _index = sharedMesh.GetBlendShapeIndex(nomenFigurae);

            if (_index < 0) {
                Carnifex.Error(nomenFigurae);
                Carnifex.Intermissio(LogTextus.FormaPuellaeFigurae_FORMATPUELLAEFIGURAE_BLEND_SHAPE_NOT_FOUND);
            }
        }

        public void Applicare(float ratio)
        {
            float pondus = Mathematica.Lerp(0f, 100f, Mathematica.Clamp01(ratio));
            _figurae.SetBlendShapeWeight(_index, pondus);
        }
    }

    internal sealed class FormaPuellaeOssisCorrectorium {
        private readonly Transform _os;

        private readonly Vector3 _magnitudoMaxima;
        private readonly Vector3 _magnitudoMedia;
        private readonly Vector3 _magnitudoMinima;

        public FormaPuellaeOssisCorrectorium(
            Transform os, 
            Vector3 magnitudoMaxima, 
            Vector3 magnitudoMedia,
            Vector3 magnitudoMinima
        ) {
            _os = os;
            _magnitudoMaxima = magnitudoMaxima;
            _magnitudoMedia = magnitudoMedia;
            _magnitudoMinima = magnitudoMinima;
        }

        private Vector3 ComputareMagnitudonis(float ratio) {
            // 以下の通りLerpを使用して計算する。
            // 0.0 - 0.5 - 1.0
            // minima - media - maxima
            float ratio01 = Mathematica.Clamp01(ratio);

            if (ratio01 <= 0.5f) {
                return Vector3.Lerp(_magnitudoMinima, _magnitudoMedia, (ratio01/0.5f));
            } else {
                return Vector3.Lerp(_magnitudoMedia, _magnitudoMaxima, (ratio01-0.5f)/0.5f);
            }
        }

        public void Applicare(float ratio) {
            _os.localScale = ComputareMagnitudonis(ratio);
        }
    }

    internal sealed class FormaPuellae {
        private readonly IDPuellaeFormae _forma;
        private readonly List<FormaPuellaeFigurae> _figurae;
        private readonly List<FormaPuellaeOssisCorrectorium> _ossa;
        private readonly ApplicatorPuellaeFormae _applicator;

        public FormaPuellae(IDPuellaeFormae forma) {
            _forma = forma;
            _figurae = new List<FormaPuellaeFigurae>();
            _ossa = new List<FormaPuellaeOssisCorrectorium>();
            _applicator = new ApplicatorPuellaeFormae(_figurae, _ossa);
        }

        // コンストラクタ(Awake/Incipere)以外で呼ぶな。
        public void AddereFigurae(
            IConfiguratioPuellaeFormaeFigurae config,
            TabulaRedittorPuellaeFigurae tabula
        ) {
            if (config.Forma != _forma) {
                Carnifex.Intermissio(LogTextus.FormaPuellae_FORMATPUELLAE_FORMA_INVALID);
            }

            foreach (var scopus in config.Scopus) {
                _figurae.Add(new FormaPuellaeFigurae(
                    tabula.Lego(scopus),
                    config.NomenFigurae
                ));
            }
        }

        // コンストラクタ(Awake/Incipere)以外で呼ぶな。
        public void AddereOssa(
            IConfiguratioPuellaeFormaeOssis config,
            TabulaRedittorPuellaeOssisCorrectorium tabula
        ) {
            if (config.Forma != _forma) {
                Carnifex.Intermissio(LogTextus.FormaPuellae_FORMATPUELLAE_FORMA_INVALID);
            }

            foreach (var scopus in config.Scopus) {
                _ossa.Add(new FormaPuellaeOssisCorrectorium(
                    tabula.Lego(scopus), 
                    config.MagnitudoMaxima, 
                    config.MagnitudoMedia,
                    config.MagnitudoMinima)
                );
            }
        }

        public void Applicare(float ratio) {
            _applicator.Applicare(ratio);
        }
    }
}
