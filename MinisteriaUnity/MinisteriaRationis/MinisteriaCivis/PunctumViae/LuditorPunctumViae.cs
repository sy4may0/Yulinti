using System;
using System.Collections.Generic;
using UnityEngine;
using Yulinti.Nucleus;
using Yulinti.MinisteriaUnity.ConfiguratioMinisterii;
using Yulinti.MinisteriaUnity.ContractusMinisterii;
using Yulinti.MinisteriaUnity.Anchora;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal class LuditorPunctumViae
    {
        private TabulaPunctumViae _tabulaPunctumViae;
        private PunctumViae[] _punctaOmnia;
        private PunctumViae[] _punctaTransitorium;
        private PunctumViae[] _punctaCrematorium;
        private PunctumViae[] _punctaNatorium;

        public LuditorPunctumViae(AnchoraPunctumViae[] anchoraPunctumViae)
        {
            _tabulaPunctumViae = new TabulaPunctumViae(anchoraPunctumViae);

            List<PunctumViae> punctaOmnia = new List<PunctumViae>();
            List<PunctumViae> punctaTransitorium = new List<PunctumViae>();
            List<PunctumViae> punctaCrematorium = new List<PunctumViae>();
            List<PunctumViae> punctaNatorium = new List<PunctumViae>();

            foreach (var anc in anchoraPunctumViae) {
                PunctumViae p = _tabulaPunctumViae.Lego(anc); 
                p.Initio();
                punctaOmnia.Add(p);
                switch (anc.Typus) {
                    case IDPunctumViaeTypi.Transitorium:
                        punctaTransitorium.Add(p);
                        break;
                    case IDPunctumViaeTypi.Crematorium:
                        punctaCrematorium.Add(p);
                        break;
                    case IDPunctumViaeTypi.Natorium:
                        punctaNatorium.Add(p);
                        break;
                }
            }

            _punctaOmnia = punctaOmnia.ToArray();
            _punctaTransitorium = punctaTransitorium.ToArray();
            _punctaCrematorium = punctaCrematorium.ToArray();
            _punctaNatorium = punctaNatorium.ToArray();
        }

        public PunctumViae[] PunctaOmnia => _punctaOmnia;
        public PunctumViae[] PunctaTransitorium => _punctaTransitorium;
        public PunctumViae[] PunctaCrematorium => _punctaCrematorium;
        public PunctumViae[] PunctaNatorium => _punctaNatorium;
    }
}
