using Yulinti.Dux.ContractusDucis;
using System;
using Yulinti.MinisteriaUnity.ContractusMinisterii;

namespace Yulinti.MinisteriaUnity.MinisteriaRationis {
    internal sealed class OstiumCivisMutabile : IOstiumCivisMutabile {
        private readonly MinisteriumCivis _miCivis;
        private readonly MinisteriumCivisGenerator _miCivisGenerator;

        public OstiumCivisMutabile(MinisteriumCivis miCivis, MinisteriumCivisGenerator miCivisGenerator) {
            _miCivis = miCivis;
        }

        public void Incarnare(int id) {
            _miCivis.Incarnare(id);
        }

        public void Spirituare(int id) {
            _miCivis.Spirituare(id);
        }

        public void TerminareGenerare() {
            _miCivisGenerator.Terminare();
        }

        public int[] IDs => _miCivis.IDs;
        public int Longitudo => _miCivis.Longitudo;
        public bool EstActivum(int id) => _miCivis.EstActivum(id);

        public void PonoAdIncarnare(Action<int> adIncarnare) {
            _miCivis.PonoAdIncarnare(adIncarnare);
        }
        public void PonoAdSpirituare(Action<int> adSpirituare) {
            _miCivis.PonoAdSpirituare(adSpirituare);
        }
    }
}