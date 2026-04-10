using Yulinti.ImperiumDelegatum.Contractus;
using System;
using Yulinti.Officia.Contractus;

namespace Yulinti.Officia.Ministeria {
    internal sealed class OstiumCivisMutabile : IOstiumCivisMutabile {
        private readonly MinisteriumCivis _miCivis;

        public OstiumCivisMutabile(MinisteriumCivis miCivis) {
            _miCivis = miCivis;
        }

        public void Incarnare(int id) {
            _miCivis.Incarnare(id);
        }

        public void Spirituare(int id) {
            _miCivis.Spirituare(id);
        }

        public int[] IDs => _miCivis.IDs;
        public int Longitudo => _miCivis.Longitudo;
        public bool EstActivum(int id) => _miCivis.EstActivum(id);
    }
}